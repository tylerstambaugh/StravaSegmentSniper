import React, { ReactElement, ReactNode, useState } from "react";
import ActivityListLookup from "./ActivityListLookup";
import DisplayActivityList from "./DisplayActivityList";
import { ActivityListItem } from "../models/Activity/ActivityListItem";
import useGetActivityList from "../hooks/useGetActivityList";

function Activity() {
  const [activityList, setActivityList] = useState<ActivityListItem[]>([]);

  function HandleActivitySearch(activityId: number) {
    // const activityListResponse =  useGetActivityList(activityId)
    // setActivityList(activityListResponse)
    console.log(`going to call the api with activityID ${activityId}`);
  }

  return (
    <>
      <h2>Strava Segment Sniper</h2>
      <ActivityListLookup handleSearch={HandleActivitySearch} />
      <DisplayActivityList activityList={activityList} />
    </>
  );
}

export default Activity;
