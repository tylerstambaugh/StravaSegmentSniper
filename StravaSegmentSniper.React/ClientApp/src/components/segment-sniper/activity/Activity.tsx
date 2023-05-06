import React, { ReactElement, ReactNode } from "react";
import ActivityListLookup from "./ActivityListLookup";

function Activity({ children }: { children: ReactNode }): ReactElement {
  return (
    <>
      <h1>This is where we'll deal with activities.</h1>
      <ActivityListLookup />
    </>
  );
}

export default Activity;
