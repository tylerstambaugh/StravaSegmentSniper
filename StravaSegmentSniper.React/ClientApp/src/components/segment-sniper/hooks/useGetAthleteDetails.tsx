import { DetailedAthleteModel } from "../athlete/models/DetailedAthleteModel";
import { UseApiCallResponse, useApiGet } from "./useApiGet";

async function useGetAthleteDetails(
  athleteId: number
): Promise<UseApiCallResponse<DetailedAthleteModel>> {
  const data: UseApiCallResponse<DetailedAthleteModel> = await useApiGet(
    `/athlete/${athleteId}`
  );
  return data;
}

export default useGetAthleteDetails;
