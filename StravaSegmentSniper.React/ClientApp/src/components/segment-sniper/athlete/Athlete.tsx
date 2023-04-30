import React, { useEffect, useState } from "react";
import useGetAthleteDetails from "../hooks/useGetAthleteDetails";

import authService from "../../api-authorization/AuthorizeService";
import useApiGet from "../hooks/useApiFunction";

const Athlete = () => {
  const [userName, setUsername] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

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
  }

  function HandleClick(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) {
    let response = useGetAthleteDetails();
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
