import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { useAxios } from "./useAxios";

const useGetActivityList = async (
  activityId: number
): Promise<[boolean, ActivityListItem[] | undefined, string, () => void]> => {
  const [loading, data, error, request] = useAxios<ActivityListItem[]>({
    method: "GET",
    url: `/activity/${activityId}`,
  });

  const fetch = () => {
    request();
  };

  return [loading, data, error, fetch];
};

export default useGetActivityList;
