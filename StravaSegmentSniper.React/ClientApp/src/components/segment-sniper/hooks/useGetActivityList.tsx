import { useState } from "react";
import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { useApi } from "./useApi";

const useGetActivityList = (): {
  loading: boolean;
  error: Error | undefined;
  fetch: (
    activityId: number
  ) => Promise<Error | ActivityListItem[] | undefined>;
} => {
  const api = useApi<ActivityListItem[]>();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error>();

  async function fetch(
    activityId: number
  ): Promise<Error | ActivityListItem[] | undefined> {
    setLoading(true);

    try {
      const requestOptions: RequestInit = { method: "GET" };
      const fetchResponse: ActivityListItem[] | Error = await api.fetch(
        `/activity/${activityId}`,
        requestOptions
      );
      if (fetchResponse instanceof Error) {
        setError(fetchResponse);
        throw new Error(error?.message);
      }
      return fetchResponse;
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
