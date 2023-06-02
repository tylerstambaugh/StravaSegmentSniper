import { useState } from "react";
import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { useApi } from "./useApi";

const useGetActivityList = () => {
  const api = useApi<ActivityListItem[]>();
  const [activityLoading, setActivityLoading] = useState(false);
  const [activityError, setActivityError] = useState<Error>();

  async function fetchActivity(
    activityId: number
  ): Promise<Error | ActivityListItem[] | undefined> {
    setActivityLoading(true);

    try {
      const requestOptions: RequestInit = {
        method: "GET",
      };
      const fetchResponse: ActivityListItem[] | Error = await api.fetch(
        `/api/StravaActivity/ActivityListById?activityId=${activityId}`,
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
  return { activityLoading, activityError, fetchActivity };
};

export default useGetActivityList;
