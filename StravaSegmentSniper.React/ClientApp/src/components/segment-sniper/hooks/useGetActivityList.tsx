import { useState } from "react";
import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { useApi } from "./useApi";
import { ActivitySearchProps } from "../activity/Activity";

const useGetActivityList = () => {
  const api = useApi<ActivityListItem[]>();
  const [activityLoading, setActivityLoading] = useState(false);
  const [activityError, setActivityError] = useState<Error>();

  async function fetchActivity(
    activitySearchProps: ActivitySearchProps
  ): Promise<Error | ActivityListItem[] | undefined> {
    setActivityLoading(true);

    if (activitySearchProps.activityId) {
      return fetchByActivityId(activitySearchProps.activityId);
    } else if (activitySearchProps.startDate && activitySearchProps.endDate) {
      return fetchByActivityDateRange(
        activitySearchProps.startDate,
        activitySearchProps.endDate
      );
    } else {
      setActivityLoading(false);
      const error: Error = new Error("An unexpected error occurred");
      setActivityError(error);
      return error;
    }

    async function fetchByActivityId(activityId: number) {
      try {
        const requestOptions: RequestInit = {
          method: "GET",
        };
        const fetchResponse: ActivityListItem[] | Error = await api.fetch(
          `/api/StravaActivity/ActivityListById?activityId=${activitySearchProps.activityId}`,
          requestOptions
        );
        if (fetchResponse instanceof Error) {
          setActivityError(fetchResponse);
          throw new Error(activityError?.message);
        }
        return fetchResponse;
      } catch (error) {
        if (error instanceof Error) {
          setActivityError(error);
          return error;
        } else {
          const newError: Error = new Error("An unexpected error occurred");
          setActivityError(newError);
          return newError;
        }
      } finally {
        setActivityLoading(false);
      }
    }

    async function fetchByActivityDateRange(startDate: Date, endDate: Date) {
      try {
        const bodyData = {
          startDate: Date,
          endDate: Date,
        };
        const requestOptions: RequestInit = {
          method: "GET",
          body: JSON.stringify(bodyData),
        };
        const fetchResponse: ActivityListItem[] | Error = await api.fetch(
          `/api/StravaActivity/ActivityListByDates`,
          requestOptions
        );
        if (fetchResponse instanceof Error) {
          setActivityError(fetchResponse);
          throw new Error(activityError?.message);
        }
        return fetchResponse;
      } catch (error) {
        if (error instanceof Error) {
          setActivityError(error);
          return error;
        } else {
          const newError: Error = new Error("An unexpected error occurred");
          setActivityError(newError);
          return newError;
        }
      } finally {
        setActivityLoading(false);
      }
    }
  }
  return { activityLoading, activityError, fetchActivity };
};

export default useGetActivityList;
