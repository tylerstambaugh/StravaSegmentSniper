import { useState } from "react";
import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { useAxios } from "./useAxios";

const useGetActivityList = (): {
  loading: boolean;
  error: Error | undefined;
  fetch: (
    activityId: number
  ) => Promise<Error | ActivityListItem[] | undefined>;
} => {
  const [, data, , request] = useAxios<ActivityListItem[]>();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error>();

  async function fetch(
    activityId: number
  ): Promise<Error | ActivityListItem[] | undefined> {
    setLoading(true);

    try {
      await request(`/activity/${activityId}`, "GET");
      if (data instanceof Error) {
        setError(data);
        throw new Error(error?.message);
      }
      return data;
    } catch (error) {
      if (error instanceof Error) {
        setError(error);
        return error;
      } else {
        const newError: Error = new Error("An unexpected error occurred");
        setError(newError);
        return newError;
      }
    } finally {
      setLoading(false);
    }
  }
  return { loading, error, fetch };
};

export default useGetActivityList;
