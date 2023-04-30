import React, { useState } from "react";
import DatePicker from "react-date-picker";

const ActivityListLookup = () => {
  const [lookupStartDate, setLookupStartDate] = useState("");
  const [lookupEndDate, setLookupEndDate] = useState("");
  const [lookupActivityId, setLookupActivityId] = useState<number>();

  function handleLookupActivityChange(e: React.ChangeEvent<HTMLInputElement>) {
    console.log(
      `do validation that this is a positive number ${e.target.value}`
    );
  }
  return (
    <>
      <h3>Activity List Lookup</h3>
      <form>
        <div>
          <p>
            Enter an activity Id to look up:
            <input
              type="text"
              onChange={(e) => handleLookupActivityChange(e)}
            />
          </p>
        </div>
        <div>
          <p>
            or look up a list of rides with a date range:
            <p>start date:</p>
            <DatePicker
              onChange={(date) => setLookupStartDate(date?.toString() ?? "")}
            />
          </p>

          <p>end date:</p>
          <DatePicker
            onChange={(date) => setLookupEndDate(date?.toString() ?? "")}
          />
        </div>
        <input type="submit" value="Lookup" />
      </form>
    </>
  );
};

export default ActivityListLookup;
