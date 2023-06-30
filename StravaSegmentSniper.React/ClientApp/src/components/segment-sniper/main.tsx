import React, { useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import { WebAppUser } from "./models/webAppUser";
import { ApplicationPaths } from "../api-authorization/ApiAuthorizationConstants";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useNonInitialEffect } from "react-cork";
import { Col, Container, Row } from "react-bootstrap";

function SegmentSniper() {
  const [userName, setUsername] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const loginPath = `${ApplicationPaths.Login}`;
  const [appUser, setAppUser] = useState<WebAppUser>();
  const [authToken, setAuthToken] = useState("");

  async function populateState() {
    const [isAuthenticated, user] = await Promise.all([
      authService.isAuthenticated(),
      authService.getUser(),
    ]);
    setIsAuthenticated(isAuthenticated);
    setUsername(user && user.name);

    const authTokenRes = await authService
      .getAccessToken()
      .then((res) => setAuthToken(res));
  }

  useEffect(() => {
    const _subscription = authService.subscribe(() => populateState());
    populateState();
    return () => {
      authService.unsubscribe(_subscription);
    };
  });

  useNonInitialEffect(() => {
    const fetchData = async () => {
      const response = await fetch("/user", {
        headers: { Authorization: `Bearer ${authToken}` },
      });
      if (!response.ok) {
        toast.error("There was an error calling the API", {
          autoClose: 1500,
          position: "bottom-center",
        });
      } else {
        const data: Promise<WebAppUser> = response.json();
        data
          .then((resolvedData) => setAppUser(resolvedData))
          .catch((error) =>
            console.log(`There was an error fetching the data. ${error}`)
          );
      }
    };
    fetchData();
  }, [userName]);

  async function callAPI(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) {
    const token = await authService.getAccessToken();
    console.log(token);
    const response = await fetch("/user", {
      headers: { Authorization: `Bearer ${token}` },
    });
    if (!response.ok) {
      toast.error("There was an error calling the API", {
        autoClose: 1500,
        position: "bottom-center",
      });
    } else {
      const data: Promise<WebAppUser> = response.json();
      data
        .then((resolvedData) => setAppUser(resolvedData))
        .catch((error) =>
          console.log(`There was an error fetching the data. ${error}`)
        );
    }
  }

  return (
    <>
      {isAuthenticated && appUser?.stravaAthleteId ? (
        <Container>
          <Row>
            <Col>
              <Link to="./athlete" style={{ cursor: "pointer" }}>
                View Athlete Details
              </Link>
            </Col>
          </Row>
          <Row>
            <Col>
              <Link to="./activities" style={{ cursor: "pointer" }}>
                Segment Sniper
              </Link>
            </Col>
          </Row>
          <Row>
            <Col>
              <Link to="./token-maintenance" style={{ cursor: "pointer" }}>
                Token Maintenance
              </Link>
            </Col>
          </Row>
          <Row>
            <Col className="d-flex p-3">
              <p>testing button:</p>
              <button onClick={(e) => callAPI(e)}>Call API</button>
              <p>webappuser: {appUser?.id}</p>
              <p>stravaAthleteId: {appUser?.stravaAthleteId}</p>
            </Col>
          </Row>
        </Container>
      ) : isAuthenticated &&
        (!appUser?.stravaAthleteId || appUser.stravaAthleteId === 0) ? (
        <main className="container">
          <div className="row justify-content-center mt-3 mb-3">
            <div className="col-6">
              <p>You need to connect your Strava Account</p>
              <p>
                Click
                <Link to={loginPath}> here </Link>
                to login.
              </p>
            </div>
          </div>
        </main>
      ) : (
        <main className="container">
          <div className="row justify-content-center mt-3 mb-3">
            <div className="col-6">
              <p>You must be logged in to access this app.</p>
              <p>
                Click
                <Link to={loginPath}> here </Link>
                to login.
              </p>
            </div>
          </div>
        </main>
      )}
    </>
  );
}
export default SegmentSniper;
