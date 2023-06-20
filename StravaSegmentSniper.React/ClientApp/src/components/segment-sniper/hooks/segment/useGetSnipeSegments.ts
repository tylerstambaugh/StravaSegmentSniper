import { useState } from "react";
import { SnipedSegmentListItem } from "../../models/Segment/Segment";
import { useApi } from "../useApi";
import { SnipeSegmentProps } from "../../scenes/segment/SegmentList";

const useSnipeSegments = () => {
  const api = useApi<SnipedSegmentListItem[]>();
  const [snipedSegmentsLoading, setSnipedSegmentsLoading] = useState(false);
  const [snipedSegmentsError, setSnipedSegmentsError] = useState<Error>();

  async function fetchSnipedSegments(
    props: SnipeSegmentProps
  ): Promise<Error | SnipedSegmentListItem[] | undefined> {
    const [snipedSegmentList, setSnipedSegmentList] = useState<
      SnipedSegmentListItem[]
    >([]);
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
        `url`,
        requestOptions
      );
      if (fetchResponse instanceof Error) {
        setSnipedSegmentsError(fetchResponse);
        throw new Error(snipedSegmentsError?.message);
      }
      return fetchResponse;
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
};
