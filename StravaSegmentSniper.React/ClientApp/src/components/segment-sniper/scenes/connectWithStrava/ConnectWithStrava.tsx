import React, { useEffect, useLayoutEffect, useState } from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import "../../../../custom.css";
import useGetClientId, {
  ClientIdResponse,
} from "../../hooks/connectWithStrava/useGetClientId";
import { toast } from "react-toastify";
import { useNonInitialEffect } from "react-cork";
import { log } from "console";

const connectWithStravaImage = require("../../assets/stravaImages/btn_strava_connectwith_orange/btn_strava_connectwith_orange@2x.png");

function ConnectWithStrava() {
  const connect = useGetClientId();
  const [clientId, setClientId] = useState<string>();

  async function handleConnectWithStrava() {
    const response: any = await connect.fetchClientId();
    if (response instanceof Error) {
      toast.error(`There was an error fetching the client Id: ${response}`, {
        autoClose: 1500,
        position: "bottom-center",
      });
    } else {
      setClientId(response.clientId);
      console.log(response.ClientId);
    }
  }

  useEffect(() => {
    if (clientId) {
      window.open(
        `http://www.strava.com/oauth/authorize?client_id=${clientId}&response_type=code&redirect_uri=http://localhost/api/ConnectWithStrava/PostExchangeToken&approval_prompt=force&scope=activity:read_all,activity:write,profile:read_all,profile:write`
      );
    }
  }, [clientId]);

  return (
    <Container className="d-flex flex-column align-items-center justify-content-center">
      <Row sm={2} className="text-center ">
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
          <Button
            variant="outline-secondary"
            onClick={() => handleConnectWithStrava()}
          >
            <img src={connectWithStravaImage} />
          </Button>
        </Col>
      </Row>
    </Container>
  );
}

export default ConnectWithStrava;
