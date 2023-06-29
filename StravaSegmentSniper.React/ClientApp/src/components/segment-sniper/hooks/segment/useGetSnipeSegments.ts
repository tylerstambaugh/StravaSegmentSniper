import { useState } from "react";
import { SnipedSegmentListItem } from "../../models/Segment/Segment";
import { useApi } from "../useApi";
import { SnipeSegmentFunctionProps } from "../../scenes/segment/SegmentList";
import { ListItemSecondaryAction } from "@mui/material";

const useGetSnipeSegments = () => {
  const api = useApi<SnipedSegmentListItem[]>();
  const [snipedSegmentsLoading, setSnipedSegmentsLoading] = useState(false);
  const [snipedSegmentsError, setSnipedSegmentsError] = useState<Error>();

  async function fetchSnipedSegments(
    props: SnipeSegmentFunctionProps
  ): Promise<Error | SnipedSegmentListItem[] | undefined> {
    setSnipedSegmentsLoading(true);

    try {
      const requestOptions: RequestInit = {
        method: "POST",
        body: JSON.stringify(props),
        headers: {
          "Content-Type": "application/json",
          //'X-Request-Id': uuidv4(),
        },
      };
      const fetchResponse: SnipedSegmentListItem[] | Error = await api.fetch(
        `/api/SegmentSniper/SnipeSegments`,
        requestOptions
      );
      if (fetchResponse instanceof Error) {
        setSnipedSegmentsError(fetchResponse);
        throw new Error(snipedSegmentsError?.message);
      }

      //map response to new SnipeSegmentListItem to return:
      let returnList: SnipedSegmentListItem[] = fetchResponse.map((item) => {
        return {
          id: item.id,
          name: item.name,
          komTime: item.komTime,
          distance: item.distance,
          secondsFromKom: item.secondsFromKom ? item.secondsFromKom : undefined,
          percentageFromKom: item.percentageFromKom
            ? item.percentageFromKom
            : undefined,
          athleteStats: item.athleteStats,
          koms: item.koms,
        };
      });
      return returnList;
      //return fetchResponse;
    } catch (error) {
      if (error instanceof Error) {
        setSnipedSegmentsError(error);
        return error;
      } else {
        const newError: Error = new Error("An unexpected error occurred");
        setSnipedSegmentsError(newError);
        return newError;
      }
    } finally {
      setSnipedSegmentsLoading(false);
    }
  }
  return { fetchSnipedSegments, snipedSegmentsError, snipedSegmentsLoading };
};

export default useGetSnipeSegments;
