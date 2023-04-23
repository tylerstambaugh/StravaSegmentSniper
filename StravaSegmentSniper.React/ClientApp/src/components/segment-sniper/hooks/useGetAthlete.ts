//this will be the hook for calling the athlete API endpoint

import { useEffect, useState } from "react";
 
const useGetAthleteDetails = () => {
  const [data, setdata] = useState(null);
  const [loading, setloading] = useState(true);
  const [error, seterror] = useState("");
 
function get() {
    fetch('./athlete')
    .then((res) => res.json())
    .then((data) => {
        seterror(data.error)
        setdata(data.joke)
        setloading(false)
    })
}
 
  return { data, loading, error };
};
 
export default useGetAthleteDetails;