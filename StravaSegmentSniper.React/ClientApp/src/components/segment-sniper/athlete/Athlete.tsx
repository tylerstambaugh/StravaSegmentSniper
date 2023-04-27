import React from "react";
import useGetAthleteDetails from "../hooks/useGetAthleteDetails";

import authService from "../../api-authorization/AuthorizeService";
import useApiGet from "../hooks/useApiFunction";

const Athlete = () => {
  function HandleClick(e: any) {
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
