import React, { useEffect } from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import "../../../../custom.css";
import useGetClientId, {
  ClientIdResponse,
} from "../../hooks/connectWithStrava/useGetClientId";
import { toast } from "react-toastify";

const connectWithStravaImage = require("../../assets/stravaImages/btn_strava_connectwith_orange/btn_strava_connectwith_orange@2x.png");

function ConnectWithStrava() {
  const connect = useGetClientId();
  let ClientId;

  async function getClientId() {
    console.log("calling strava to connect");
    const response: ClientIdResponse | Error = await connect.fetchClientId();
    if (response instanceof Error) {
      toast.error(`There was an error fetching the client Id: ${response}`, {
        autoClose: 1500,
        position: "bottom-center",
      });
    } else {
      ClientId = response;
      console.log(ClientId);
    }
  }

  async function handleConnectWithStrava() {
    window.open(
      `http://www.strava.com/oauth/authorize?client_id=${ClientId}&response_type=code&redirect_uri=http://localhost/api/ConnectWithStrava/PostExchangeToken&approval_prompt=force&scope=activity:read_all,activity:write,profile:read_all,profile:write`
    );
  }

  useEffect(() => {
    getClientId();
  }, []);

  return (
    <Container className="d-flex flex-column align-items-center justify-content-center">
      <Row sm={3} className="text-center ">
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
