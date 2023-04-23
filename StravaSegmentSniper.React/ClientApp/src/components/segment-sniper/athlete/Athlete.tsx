import React from "react";
import useGetAthleteDetails from "../hooks/useGetAthlete";

import authService from "../../api-authorization/AuthorizeService";

function Athlete() {
  const handleButtonClick = (e: Event) => {
    // useGetAthleteDetails.get();
  };

  async function callAPI2(e) {
    const token = await authService.getAccessToken();
    console.log(token);
    const response = await fetch("/athlete", {
      headers: !token ? {} : { Authorization: `Bearer ${token}` },
    });
    const data = await response.json();
    console.log(data);
  }

  // function get() {
  //         fetch('./athlete')
  //         .then((res) => res.json())
  //         .then((data) => {
  //             seterror(data.error)
  //             setdata(data.joke)
  //             setloading(false)
  //         })
  //     }

  return (
    <div>
      <h1>This is where we'll deal with athlete datas.</h1>
      <div>
        <p>testing button:</p>
        <button onClick={(e) => callAPI2(e)}>Call API</button>
      </div>
      <h2>Athlete name from local DB: </h2>
    </div>
  );
}

export default Athlete;
