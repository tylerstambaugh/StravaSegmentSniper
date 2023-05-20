import { DetailedAthleteModel } from "../athlete/models/DetailedAthleteModel";
import useApiGet, { UseApiCallResponse } from "./useApiFunction";

async function useGetAthleteDetails(
  athleteId: number
): Promise<UseApiCallResponse<DetailedAthleteModel>> {
  const data: UseApiCallResponse<DetailedAthleteModel> = await useApiGet(
    `/athlete/${athleteId}`
  );
  return data;
}

export default useGetAthleteDetails;
