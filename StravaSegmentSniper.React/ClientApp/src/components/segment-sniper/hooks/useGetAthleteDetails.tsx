import { TApiResponse } from "../models/apiResponse";
import useApiGet from "./useApiFunction";

async function useGetAthleteDetails(): Promise<TApiResponse> {
  const data: TApiResponse = useApiGet("url");
  return data;
}

export default useGetAthleteDetails;
