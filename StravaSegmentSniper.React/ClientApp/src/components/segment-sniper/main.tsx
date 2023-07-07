import React, { useEffect, useState } from "react";
import "../../../src/custom.css";
import { Link } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import { WebAppUser } from "./models/webAppUser";
import { ApplicationPaths } from "../api-authorization/ApiAuthorizationConstants";
import "react-toastify/dist/ReactToastify.css";
import { useNonInitialEffect } from "react-cork";
import { Button, Col, Container, Row } from "react-bootstrap";
import ConnectWithStrava from "./scenes/connectWithStrava/ConnectWithStrava";

function SegmentSniper() {
  const [userName, setUsername] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const loginPath = `${ApplicationPaths.Login}`;
  const [appUser, setAppUser] = useState<WebAppUser>();
  const [authToken, setAuthToken] = useState("");
  const [loading, setLoading] = useState(true);

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

  useEffect(() => {
    if (userName) setLoading(false);
  }, [userName]);

  useNonInitialEffect(() => {
    const fetchData = async () => {
      const response = await fetch("/user", {
        headers: { Authorization: `Bearer ${authToken}` },
      });
      if (!response.ok) {
        console.log(
          `non initial use effect response not 'OK': ${response.json()}`
        );
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

  return (
    <>
      {loading ? (
        <div className="loader"></div>
      ) : isAuthenticated && appUser?.stravaAthleteId ? (
        <Container
          className="d-flex flex-column justify-content-center p-2 mb-2 bg-light text-dark border rounded "
          style={{ width: "50%" }}
        >
          <Row>
            <Col
              md={9}
              sm={2}
              className="d-flex p-2 mb-2 justify-content-center"
            >
              <Link to="./athlete" className="rounded-button">
                Athlete Details
              </Link>
            </Col>
          </Row>
          <Row>
            <Col md={9} className="d-flex p-2 mb-2 justify-content-center">
              <Link to="./activities" className="rounded-button">
                Segment Sniper
              </Link>
            </Col>
          </Row>
          <Row>
            <Col md={9} className="d-flex p-2 mb-2 justify-content-center">
              <Link to="./token-maintenance" className="rounded-button">
                Admin
              </Link>
            </Col>
          </Row>
        </Container>
      ) : isAuthenticated &&
        (!appUser?.stravaAthleteId || appUser.stravaAthleteId === 0) ? (
        <ConnectWithStrava />
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
