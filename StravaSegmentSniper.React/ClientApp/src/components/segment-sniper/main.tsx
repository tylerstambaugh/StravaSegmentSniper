import React, { useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import { WebAppUser } from "./models/webAppUser";
import { ApplicationPaths } from "../api-authorization/ApiAuthorizationConstants";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function SegmentSniper() {
  const [userName, setUsername] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  const loginPath = `${ApplicationPaths.Login}`;
  const [appUser, setAppUser] = useState<WebAppUser>();

  useEffect(() => {
    const _subscription = authService.subscribe(() => populateState());
    populateState();

    return () => {
      authService.unsubscribe(_subscription);
    };
  });

  async function populateState() {
    const [isAuthenticated, user] = await Promise.all([
      authService.isAuthenticated(),
      authService.getUser(),
    ]);
    setIsAuthenticated(isAuthenticated);
    setUsername(user && user.name);
    console.log(`user from populate state = ${JSON.stringify(user, null, 4)}`);
    const authToken = await authService
      .getAccessToken()
      .then((res) => console.log(`user token: ${res}`));
  }

  async function callAPI(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) {
    const token = await authService.getAccessToken();
    console.log(token);
    const response = await toast.promise(
      fetch("/user", {
        headers: { Authorization: `Bearer ${token}` },
      }),
      {
        pending: "fetch is pending",
        success: "fetch resolved 👌",
        error: "fetch rejected 🤯",
      },
      {
        autoClose: 1500,
        position: "bottom-center",
      }
    );

    if (!response.ok) {
      console.log(
        `There was an error fetching the data. ${JSON.stringify(
          response,
          null,
          4
        )}`
      );
      toast.error("There was an error calling the API", {
        autoClose: 1500,
        position: "bottom-center",
      });
    } else {
      const data: Promise<WebAppUser> = toast.promise(response.json(), {
        pending: "get data is pending",
        success: "get data resolved 👌",
        error: "get data rejected 🤯",
      });
      data
        .then((resolvedData) => setAppUser(resolvedData))
        .catch((error) =>
          console.log(`There was an error fetching the data. ${error}`)
        );
    }
  }

  if (isAuthenticated) {
    return (
      <main className="container">
        <div className="row justify-content-center mt-3 mb-3">
          <div className="main-tile">
            <ul>
              <li style={{ cursor: "pointer" }}>
                <Link to="./athlete">View Athlete Details</Link>
              </li>
              <li style={{ cursor: "pointer" }}>
                <Link to="./activities">Segment Sniper</Link>
              </li>
              <li style={{ cursor: "pointer" }}>
                <Link to="./token-maintenance">Token Maintenance</Link>
              </li>
            </ul>
          </div>
          <div>
            <p>testing button:</p>
            <button onClick={(e) => callAPI(e)}>Call API</button>
            <h3>webappuser: {appUser?.id}</h3>
            <h3>stravaAthleteId: {appUser?.stravaAthleteId}</h3>
          </div>
        </div>
      </main>
    );
  } else {
    return (
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
    );
  }
}

export default SegmentSniper;
