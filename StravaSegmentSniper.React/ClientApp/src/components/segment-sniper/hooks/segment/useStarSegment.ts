import { useState } from "react";
import { useApi } from "../useApi";
import starredSegment from "../../models/Segment/StarredSegment";

const useStarSegment = () => {
  const api = useApi();
  const [starSegmentLoading, setStarSegmentLoading] = useState(false);
  const [starSegmentError, setStarSegmentError] = useState<Error>();

  async function starSegment(
    props: starSegmentProps
  ): Promise<Error | starredSegment> {
    setStarSegmentLoading(true);

    try {
      const requestOptions: RequestInit = {
        method: "PUT",
        body: JSON.stringify(props),
        headers: {
          "Content-Type": "application/json",
        },
      };

      const response: starredSegment | Error = await api.fetch(
        "url",
        requestOptions
      );
      if (response instanceof Error) {
        setStarSegmentError(response);
        throw new Error(starSegmentError?.message);
      }

      return response;
    } catch (error) {
      if (error instanceof Error) {
        setStarSegmentError(error);
        return error;
      } else {
        const newError: Error = new Error("An unexpected error occurred");
        setStarSegmentError(newError);
        return newError;
      }
    } finally {
      setStarSegmentLoading(false);
    }
  }
  return { starSegment, setStarSegmentError, starSegmentLoading };
};

export default useStarSegment;

export interface starSegmentProps {
  segmentId: number;
  starred: boolean;
}
