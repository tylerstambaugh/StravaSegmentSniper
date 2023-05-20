import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { TApiResponse } from "../models/apiResponse";
import useApiGet, { UseApiCallResponse } from "./useApiFunction";

async function useGetActivityList(
  activityId: number
): Promise<UseApiCallResponse<ActivityListItem[]>> {
  const data: UseApiCallResponse<ActivityListItem[]> = useApiGet(
    `/activity/${activityId}`
  );
  return data;
}

export default useGetActivityList;
