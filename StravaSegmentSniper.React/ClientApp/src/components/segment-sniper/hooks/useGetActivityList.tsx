import { useState } from "react";
import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { UseApiCallResponse, useApiGet } from "./useApiGet";

const useGetActivityList = async (
  activityId: number
): Promise<ActivityListItem[] | string> => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string>();

  async function fetch(activityId: number) {
    const response = await useApiGet<ActivityListItem[]>(
      `/activity/${activityId}`
    );
    if (response.error) {
      console.log("something went wrong in useGetActivityList.tsx");
      setError(response.error);
    }
    const responseData: ActivityListItem[] = response.data!;
    return responseData;
  }
  return { fetch, error };
};

export default useGetActivityList;
