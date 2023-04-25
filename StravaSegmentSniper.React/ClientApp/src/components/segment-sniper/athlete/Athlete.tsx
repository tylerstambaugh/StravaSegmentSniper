import React from "react";
import useGetAthleteDetails from "../hooks/useGetAthleteDetails";

import authService from "../../api-authorization/AuthorizeService";

const Athlete = () => {
  function handleClick(e: any) {}

  return (
    <div>
      <h1>This is where we'll deal with athlete datas.</h1>
      <div>
        <p>testing button:</p>
        <button onClick={(e) => handleClick(e)}>Call API</button>
      </div>
      <h2>Athlete name from local DB: </h2>
    </div>
  );
};

export default Athlete;
