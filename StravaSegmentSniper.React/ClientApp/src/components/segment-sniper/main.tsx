import React, { useEffect, useLayoutEffect, useState } from "react";
import "../../../src/custom.css";
import { Link } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import { WebAppUser } from "./models/webAppUser";
import { ApplicationPaths } from "../api-authorization/ApiAuthorizationConstants";
import "react-toastify/dist/ReactToastify.css";
import { useNonInitialEffect } from "react-cork";
import { Button, Card, Col, Container, Row } from "react-bootstrap";
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
    console.log(authToken);

    setLoading(false);
  }

  useEffect(() => {
    const _subscription = authService.subscribe(() => populateState());
    populateState();
    return () => {
      authService.unsubscribe(_subscription);
    };
  });

  async function fetchUser() {
    if (isAuthenticated && authToken) {
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
    }
  }

  useNonInitialEffect(() => {
    fetchUser();
  }, [isAuthenticated]);

  return (
    <>
      {loading ? (
        <Container
          className="d-flex flex-column justify-content-center mb-2 bg-light text-dark border rounded mx-auto "
          style={{ width: "50%" }}
        >
          <div className="loader"></div>
        </Container>
      ) : isAuthenticated && appUser?.stravaAthleteId ? (
        <Container
          className="d-flex flex-column justify-content-center mb-2 bg-light text-dark border rounded mx-auto "
          style={{ width: "50%" }}
        >
          <Row>
            <Col md={12} className="d-flex p-2 mb-2 justify-content-center">
              <Link to="./activities" className="rounded-button">
                Segment Sniper
              </Link>
            </Col>
          </Row>
          <Row>
            <Col md={12} className="d-flex p-2 mb-2 justify-content-center">
              <Link to="./athlete" className="rounded-button">
                Athlete Details
              </Link>
            </Col>
          </Row>

          <Row>
            <Col md={12} className="d-flex p-2 mb-2 justify-content-center">
              <Link to="./token-maintenance" className="rounded-button">
                Admin
              </Link>
            </Col>
          </Row>
        </Container>
      ) : !appUser?.stravaAthleteId || appUser.stravaAthleteId === 0 ? (
        <ConnectWithStrava />
      ) : (
        <div className="d-flex justify-content-center">
          <Card style={{ width: "30rem" }}>
            <Card.Body className="flex-column justify-content-center mx-auto align-items-center">
              <Row>
                <p>You must be logged in to access this app.</p>
              </Row>
              <Row className="justify-content-between">
                <Link to={loginPath}>
                  <Button>Login</Button>
                </Link>
                <span className="mx-2">Or</span>
                <Link to={loginPath}>
                  <Button>Register</Button>
                </Link>
              </Row>
            </Card.Body>
          </Card>
        </div>
      )}
    </>
  );
}
export default SegmentSniper;
