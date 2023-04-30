import { TApiResponse } from "../models/apiResponse";
import useApiGet from "./useApiFunction";

async function useGetAthleteDetails(athleteId: number): Promise<TApiResponse> {
  const data: TApiResponse = useApiGet(`/athlete/${athleteId}`);
  return data;
}

export default useGetAthleteDetails;
