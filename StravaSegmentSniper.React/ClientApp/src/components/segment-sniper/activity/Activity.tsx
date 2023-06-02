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
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error>();

  async function handleActivitySearch(props: ActivitySearchProps) {
    setLoading(true);
    try {
      const fetchResponse = await fetchActivity(props.activityId!);

      if (fetchResponse && !(fetchResponse instanceof Error)) {
        setActivityList(fetchResponse);
      } else {
        console.log(`error when fetching: ${fetchResponse}`);
      }
    } catch (error) {
      if (error instanceof Error) {
        setError(error);
        console.log(`error when fetching: ${error.stack}`);
      } else {
        throw new Error("an unexpected error try to fetch activities");
      }
    } finally {
      setLoading(false);
    }
    console.log(activityList);
  }

  return (
    <>
      <h2>Strava Segment Sniper</h2>
      <ActivityListLookup
        activityLoading={activityLoading}
        handleSearch={handleActivitySearch}
      />
      <DisplayActivityList activityList={activityList} />
    </>
  );
};

export default Activity;
