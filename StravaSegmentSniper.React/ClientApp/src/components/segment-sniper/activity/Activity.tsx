import React, { ReactElement, ReactNode } from "react";
import ActivityListLookup from "./ActivityListLookup";
import DisplayActivityList from "./DisplayActivityList";

function Activity() {
  return (
    <>
      <h1>This is where we'll deal with activities.</h1>
      <ActivityListLookup />
      <DisplayActivityList />
    </>
  );
}

export default Activity;
