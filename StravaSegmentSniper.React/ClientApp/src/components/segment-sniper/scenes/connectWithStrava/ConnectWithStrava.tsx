import React from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import { Link } from "react-router-dom";
//import connectWithStravaImage from "../../../segment-sniper/assets/stravaImages/btn_strava_connectwith_orange/btn_strava_connectwith_orange@2x.png"

const connectWithStravaImage = require("../../assets/stravaImages/btn_strava_connectwith_orange/btn_strava_connectwith_orange@2x.png");

const ConnectWithStrava = () => {
  return (
    <Container className="d-flex flex-column align-items-center justify-content-center">
      <Row>
        <Col>
          <p className="text-center">
            YBefore you can start sniping segments, we'll need you to authorize
            us to access your Strava data. Click the button below to get
            started.
          </p>
        </Col>
      </Row>
      <Row>
        <Col>
          <Link to="primary">
            <img src={connectWithStravaImage} />
          </Link>
        </Col>
      </Row>
    </Container>
  );
};

export default ConnectWithStrava;
