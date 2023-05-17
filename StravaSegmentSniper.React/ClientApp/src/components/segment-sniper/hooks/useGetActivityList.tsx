import { TApiResponse } from "../models/apiResponse";
import useApiGet from "./useApiFunction";

async function useGetActivityList(activityId: number): Promise<TApiResponse> {
  const data: TApiResponse = await useApiGet(`/activity/${activityId}`);
  return data;
}

export default useGetActivityList;
