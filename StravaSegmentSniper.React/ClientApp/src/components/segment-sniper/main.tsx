import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import { WebAppUser } from "./models/webAppUser";
import { ApplicationPaths } from "../api-authorization/ApiAuthorizationConstants";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useNonInitialEffect } from "react-cork";
import { Button, Col, Container, Row } from "react-bootstrap";
//import ConnectWithStravaImage from "../assets/stravaImages/btn_strava_connectwith_orange/btn_strava_connectwith_orange@2x.png";
import ConnectWithStravaImage from "../segment-sniper/assets/stravaImages/btn_strava_connectwith_orange/btn_strava_connectwith_orange@2x.png";

function SegmentSniper() {
  const [userName, setUsername] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const loginPath = `${ApplicationPaths.Login}`;
  const connectWithStravaPAth = "./";
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
        <Container
          className="flex-column justify-content-center p-2 mb-2 bg-light text-dark border rounded"
          style={{ width: "50%" }}
        >
          <Row>
            <Col md={9} className="d-flex p-2 mb-2 justify-content-center">
              <Link to="./athlete">
                <Button style={{ cursor: "pointer" }}>Athlete Details</Button>
              </Link>
            </Col>
          </Row>
          <Row>
            <Col md={9} className="d-flex p-2 mb-2 justify-content-center">
              <Link to="./activities">
                <Button style={{ cursor: "pointer" }}>Segment Sniper</Button>
              </Link>
            </Col>
          </Row>
          <Row>
            <Col md={9} className="d-flex p-2 mb-2 justify-content-center">
              <Link to="./token-maintenance">
                <Button style={{ cursor: "pointer" }}>Admin</Button>
              </Link>
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
                <Link to="./connect">
                  <img src={ConnectWithStravaImage} />
                </Link>
                to being.
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
