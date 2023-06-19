import React, { useEffect, useState } from "react";
import ActivityListLookup from "./ActivityListLookup";
import DisplayActivityList from "./DisplayActivityList";
import useGetActivityList from "../../hooks/activity/useGetActivityList";
import { ActivityListItem } from "../../models/Activity/ActivityListItem";
import { SegmentListItem } from "../../models/Segment/Segment";
import DisplaySegmentList from "../segment/DisplaySegmentList";
import { useNonInitialEffect } from "react-cork";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ActivityTypeEnum from "../../enums/activityTypes";
import SegmentList from "../segment/SegmentList";

export interface ActivitySearchProps {
  activityId?: number;
  startDate?: Date;
  endDate?: Date;
  activityType?: ActivityTypeEnum;
}

const Activity = () => {
  const [activityList, setActivityList] = useState<ActivityListItem[]>([]);
  const [activitySegmentsList, setActivitySegmentsList] = useState<
    SegmentListItem[]
  >([]);

  const [selectedActivityId, setSelectedActivityId] = useState<string>();
  const { activityLoading, activityError, fetchActivity } =
    useGetActivityList();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error>();

  async function handleActivitySearch(
    activitySearchProps: ActivitySearchProps
  ) {
    setLoading(true);
    try {
      console.log(
        `activity search props ${JSON.stringify(activitySearchProps, null, 4)}`
      );
      const fetchResponse = await fetchActivity(activitySearchProps!);

      if (fetchResponse && !(fetchResponse instanceof Error)) {
        setActivityList(fetchResponse);
      } else {
        console.log(
          `fetch response: ${JSON.stringify(fetchResponse, null, 4)}`
        );
      }
    } catch (error) {
      if (error instanceof Error) {
        setError(error);
        console.log(`caught error: ${JSON.stringify(error, null, 4)}`);
      } else {
        throw new Error("an unexpected error try to fetch activities");
      }
    } finally {
      setLoading(false);
    }
    console.log(activityList);
  }

  function handleShowSegments(activityId: string) {
    if (activityList && activityList.length > 0) {
      const selectedActivity = activityList.find((x) => x.id === activityId);
      setSelectedActivityId(selectedActivity?.id);
      if (
        selectedActivity &&
        selectedActivity.segments &&
        selectedActivity.segments.length > 0
      ) {
        setActivitySegmentsList(selectedActivity.segments);
      }
    }
  }

  function clearSearchResults() {
    setActivityList([]);
    setActivitySegmentsList([]);
    setSelectedActivityId("");
    toast.info("Search Results Cleared", {
      position: "top-center",
      autoClose: 2000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: false,
      draggable: true,
      progress: undefined,
      theme: "dark",
    });
  }

  useNonInitialEffect(() => {
    toast.error(
      `There was an error fetching the activities: ${activityError}`,
      {
        autoClose: 1500,
        position: "bottom-center",
      }
    );
  }, [activityError]);

  return (
    <>
      <h2>Strava Segment Sniper</h2>
      <ActivityListLookup
        activityLoading={activityLoading}
        handleSearch={handleActivitySearch}
      />
      <DisplayActivityList
        activityList={activityList}
        handleShowSegments={handleShowSegments}
        clearSearchResults={clearSearchResults}
      />
      <SegmentList activitySegmentList={activitySegmentsList} />
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
