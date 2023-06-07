import React, { useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import { WebAppUser } from "./models/webAppUser";
import { ApplicationPaths } from "../api-authorization/ApiAuthorizationConstants";

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
  }

  async function callAPI(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) {
    const token = await authService.getAccessToken();
    console.log(token);
    const response = await fetch("/user", {
      headers: !token ? {} : { Authorization: `Bearer ${token}` },
    });
    const data = await response.json();
    if (data instanceof Error) {
      console.log(`there was an error fetching the data. ${data}`);
    } else {
      setAppUser(data);
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
