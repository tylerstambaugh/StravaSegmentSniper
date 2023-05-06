import React, { ReactElement, ReactNode, useState } from "react";
import DatePicker from "react-datepicker";

function ActivityListLookup() {
  const [lookupStartDate, setLookupStartDate] = useState(new Date());
  const [lookupEndDate, setLookupEndDate] = useState(new Date());
  const [lookupActivityId, setLookupActivityId] = useState<number>();

  function handleActivityIdChange(e: React.ChangeEvent<HTMLInputElement>) {
    console.log(
      `do validation that this is a positive number ${e.target.value}`
    );
  }

  function handleStartDateChange(e: React.ChangeEvent<HTMLInputElement>) {
    console.log(
      `do validation that this is a positive number ${e.target.value}`
    );
  }

  function handleEndDateChange(e: React.ChangeEvent<HTMLInputElement>) {
    //setLookupEndDate(e.target.value)
  }

  return (
    <>
      <h3>Activity List Lookup</h3>
      <form>
        <div>
          <p>
            Enter an activity Id to look up:
            <input type="text" onChange={(e) => handleActivityIdChange(e)} />
          </p>
        </div>
        <div>
          <div>
            or look up a list of rides with a date range:
            <p>start date:</p>
            <DatePicker
              selected={lookupStartDate}
              onChange={(date) => handleStartDateChange(date)}
            />
          </div>
          <div>
            <p>end date:</p>
            <DatePicker
              selected={lookupEndDate}
              onChange={(date) => handleEndDateChange(date)}
            />
          </div>
        </div>
        <input type="submit" value="Lookup" />
      </form>
    </>
  );
}

export default ActivityListLookup;
