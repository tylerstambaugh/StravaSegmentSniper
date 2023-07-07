import React from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import "../../../../custom.css";
import useConnectWithStrava from "../../hooks/connectWithStrava/useConnectWithStrava";

const connectWithStravaImage = require("../../assets/stravaImages/btn_strava_connectwith_orange/btn_strava_connectwith_orange@2x.png");

const ConnectWithStrava = () => {
  const connect = useConnectWithStrava();

  async function handleConnectWithStrava() {
    console.log("calling strava to connect");
    const clientId = connect.fetchConnectWithStrava();
    console.log(clientId);
  }

  return (
    <Container className="d-flex flex-column align-items-center justify-content-center">
      <Row sm={1} className="text-center ">
        <Col className="mx-auto">
          <p>
            Before you can start sniping segments, we'll need you to authorize
            us to access your Strava data. When you click the below button,
            you'll be redirected to Strava and asked to grant this app
            permission to view our data. After accepting the agreement, you'll
            be redirected here and can begin sniping segments.
          </p>
        </Col>
      </Row>
      <Row>
        <Col>
          <Button onClick={() => handleConnectWithStrava()}>
            <img src={connectWithStravaImage} />
          </Button>
        </Col>
      </Row>
    </Container>
  );
};

export default ConnectWithStrava;
