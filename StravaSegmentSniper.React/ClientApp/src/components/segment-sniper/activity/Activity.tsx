import React, { ReactElement, ReactNode, useEffect, useState } from "react";
import ActivityListLookup from "./ActivityListLookup";
import DisplayActivityList from "./DisplayActivityList";
import { ActivityListItem } from "../models/Activity/ActivityListItem";
import useGetActivityList from "../hooks/useGetActivityList";

export interface ActivitySearchProps {
  activityId?: number;
  startDate?: Date;
  endDate?: Date;
  activityType?: string;
}

const Activity = () => {
  const [activityList, setActivityList] = useState<ActivityListItem[]>([]);
  const { activityLoading, activityError, fetchActivity } =
    useGetActivityList();
  const [loading, setLoading] = useState();
  const [error, setError] = useState();

  async function handleActivitySearch(props: ActivitySearchProps) {
    const fetchResponse = await fetchActivity(props.activityId!);

    if (fetchResponse && !(fetchResponse instanceof Error)) {
      setActivityList(fetchResponse);
    } else {
      // Handle error case here
    }

    console.log(activityList);
  }

  return (
    <>
      <h2>Strava Segment Sniper</h2>
      <ActivityListLookup handleSearch={handleActivitySearch} />
      <DisplayActivityList activityList={activityList} />
    </>
  );
};

export default Activity;
