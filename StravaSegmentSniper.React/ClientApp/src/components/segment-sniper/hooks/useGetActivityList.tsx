import { ActivityListItem } from "../models/Activity/ActivityListItem";
import { useAxios } from "./useAxios";

const useGetActivityList = async (): Promise<
  [
    boolean,
    ActivityListItem[] | undefined,
    string,
    (activityId: number) => void
  ]
> => {
  const [loading, data, error, request] = useAxios<ActivityListItem[]>();

  const fetch = (activityId: number) => {
    request(`/activity/${activityId}`, "GET");
  };

  return [loading, data, error, fetch];
};

export default useGetActivityList;
