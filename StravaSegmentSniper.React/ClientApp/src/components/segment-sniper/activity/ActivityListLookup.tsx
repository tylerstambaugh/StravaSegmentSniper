import React, { ReactElement, ReactNode, useState } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "bootstrap/dist/css/bootstrap.css";

function ActivityListLookup() {
  const [lookupStartDate, setLookupStartDate] = useState<Date>(new Date());
  const [lookupEndDate, setLookupEndDate] = useState<Date>(new Date());
  const [lookupActivityId, setLookupActivityId] = useState<number>();

  function handleActivityIdChange(e: React.ChangeEvent<HTMLInputElement>) {
    console.log(
      `do validation that this is a positive number ${e.target.value}`
    );
  }

  function handleStartDateChange(e: Date) {
    setLookupStartDate(e);
  }

  function handleEndDateChange(e: Date) {
    setLookupEndDate(e);
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
              onChange={(date: Date | null) => handleStartDateChange(date!)}
            />
          </div>
          <div>
            <p>end date:</p>
            <DatePicker
              selected={lookupEndDate}
              onChange={(date: Date | null) => handleEndDateChange(date!)}
            />
          </div>
        </div>
        <input type="submit" value="Lookup" />
      </form>
    </>
  );
}

export default ActivityListLookup;
