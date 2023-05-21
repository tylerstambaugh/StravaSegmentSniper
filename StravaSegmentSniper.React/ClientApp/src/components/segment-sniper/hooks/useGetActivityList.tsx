import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { UseApiCallResponse, useApiGet } from "./useApiGet";

const useGetActivityList = async (
  activityId: number
): Promise<ActivityListItem[] | Error> => {
  const response = await useApiGet<ActivityListItem[]>(
    `/activity/${activityId}`
  );
  if (response.error) {
    console.log("somehting went wrong in useGetActivityList.tsx");
    return response.error;
  } else {
    const responseData: ActivityListItem[] = response.data!;
    return responseData;
  }
};

export default useGetActivityList;
