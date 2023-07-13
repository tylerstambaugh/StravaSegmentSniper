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
import { Container } from "react-bootstrap";

export interface ActivitySearchProps {
  activityId?: number | null;
  startDate?: Date | null;
  endDate?: Date | null;
  activityType?: ActivityTypeEnum | null;
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
      position: "bottom-center",
      autoClose: 1000,
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
      <Container className="mb-4">
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
        <SegmentList
          activitySegmentList={activitySegmentsList}
          activityId={selectedActivityId}
        />
      </Container>
    </>
  );
};

export default Activity;
