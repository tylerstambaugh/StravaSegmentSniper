import React, { useEffect, useState } from "react";
import ActivityListLookup from "./ActivityListLookup";
import DisplayActivityList from "./DisplayActivityList";
import useGetActivityList from "../../hooks/activity/useGetActivityList";
import { ActivityListItem } from "../../models/Activity/ActivityListItem";
import { SegmentListItem } from "../../models/Segment/Segment";
import DisplaySegmentList from "../segment/DisplaySegmentList";
import { useNonInitialEffect } from "react-cork";

export interface ActivitySearchProps {
  activityId?: number;
  startDate?: Date;
  endDate?: Date;
  activityType?: string;
}

const Activity = () => {
  const [activityList, setActivityList] = useState<ActivityListItem[]>([]);
  const [activitySegmentsList, setActivitySegmentsList] = useState<
    SegmentListItem[]
  >([]);
  const { activityLoading, activityError, fetchActivity } =
    useGetActivityList();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error>();

  async function handleActivitySearch(
    activitySearchProps: ActivitySearchProps
  ) {
    setLoading(true);
    try {
      const fetchResponse = await fetchActivity(activitySearchProps!);

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

  function handleShowSegments(activityId: string) {
    setActivitySegmentsList(
      activityList.find((x) => x.id === activityId)?.segments!
    );
  }

  function handleSnipeSegments(activityId: string) {}

  // useNonInitialEffect(() => {
  //   if (activityList !== undefined && activityList[0].segments) {
  //     setActivitySegmentsList(activityList[0].segments);
  //   }
  // }, [activityList]);

  return (
    <>
      <h2>Strava Segment Sniper</h2>
      <ActivityListLookup
        activityLoading={activityLoading}
        handleSearch={handleActivitySearch}
      />
      <DisplayActivityList
        activityList={activityList}
        handleSnipeSegments={handleSnipeSegments}
        handleShowSegments={handleShowSegments}
      />
      <DisplaySegmentList segmentList={activitySegmentsList} />
    </>
  );
};

export default Activity;

// const initialState: ActivityListItem = {
//   name: "",
//   id: "",
//   startDate: undefined,
//   elapsedTime: undefined,
//   type: "",
//   distance: undefined,
//   achievementCount: undefined,
//   maxSpeed: undefined,
//   stravaMap: {
//     id: "",
//     polyline: "",
//   },
//   segments: [
//     {
//       name: "",
//       id: "",
//       time: 0,
//       distance: 0,
//     },
//   ],
// };
