import React, { useEffect, useState } from "react";
import useGetAthleteDetails from "../hooks/useGetAthleteDetails";
import authService from "../../api-authorization/AuthorizeService";
import { WebAppUser } from "../models/webAppUser";

const Athlete = () => {
  const [userName, setUsername] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  const [appUser, setAppUser] = useState<WebAppUser>();
  let token: string = "";

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
      (token = await authService.getAccessToken()),
    ]);
    setIsAuthenticated(isAuthenticated);
    setUsername(user && user.name);
  }

  async function getAppUser() {
    console.log(token);
    const response = await fetch("/user", {
      headers: !token ? {} : { Authorization: `Bearer ${token}` },
    });
    const data = await response.json();
    setAppUser(data);
  }

  function HandleClick(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) {
    // let response = useGetAthleteDetails(appUser?.stravaAthleteId ?? 0);
  }

  return (
    <div>
      <h1>This is where we'll deal with athlete datas.</h1>
      <div>
        <p>testing button:</p>
        <button onClick={(e) => HandleClick(e)}>
          Call Get Athlete Details
        </button>
      </div>
      <h2>Athlete name from local DB: </h2>
    </div>
  );
};

export default Athlete;
