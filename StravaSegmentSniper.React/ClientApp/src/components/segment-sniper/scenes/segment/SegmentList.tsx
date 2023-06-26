import { useEffect, useState } from "react";
import DisplaySegmentList from "./DisplaySegmentList";
import {
  SegmentListItem,
  SnipedSegmentListItem,
} from "../../models/Segment/Segment";
import React from "react";
import DisplaySnipedSegmentList from "./DisplaySnipedSegmentsList";
import SnipeSegmentsModal from "./SnipeSegmentsModal";
import { Container } from "react-bootstrap";
import useGetSnipeSegments from "../../hooks/segment/useGetSnipeSegments";

export interface SnipeSegmentFunctionProps {
  activityId?: string;
  secondsOff?: number | undefined;
  percentageOff?: number | undefined;
}
export interface SegmentListProps {
  activityId: string | undefined;
  activitySegmentList: SegmentListItem[];
}
const SegmentList = (props: SegmentListProps) => {
  const [showSnipeSegmentModal, setShowSnipeSegmentModal] = useState(false);
  const { snipedSegmentsError, snipedSegmentsLoading, fetchSnipedSegments } =
    useGetSnipeSegments();
  const [isSnipeList, setIsSnipeList] = useState(false);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error>();
  const [snipedSegmentlist, setSnipedSegmentList] = useState<
    SnipedSegmentListItem[]
  >([]);

  const handleCloseSnipeSegmentModal = () => setShowSnipeSegmentModal(false);
  const handleShowSnipeSegmentsModal = () => setShowSnipeSegmentModal(true);

  function clearSnipedSegments() {
    setSnipedSegmentList([]);
    setIsSnipeList(false);
  }

  useEffect(() => {
    if (isSnipeList) {
      setIsSnipeList(true);
    }
  }, [isSnipeList]);

  async function handleSnipeSegments(
    snipeSegmentsProps: SnipeSegmentFunctionProps
  ) {
    snipeSegmentsProps.activityId = props.activityId;
    setLoading(true);
    try {
      console.log(
        `activity search props ${JSON.stringify(snipeSegmentsProps, null, 4)}`
      );
      const fetchResponse = await fetchSnipedSegments(snipeSegmentsProps!);
      if (fetchResponse && !(fetchResponse instanceof Error)) {
        setSnipedSegmentList(fetchResponse);
      } else {
        console.log(
          `fetch response: ${JSON.stringify(fetchResponse, null, 4)}`
        );
      }
    } catch (error) {
      if (error instanceof Error) {
        setError(error);
        console.log(`caught error: ${JSON.stringify(error, null, 4)}`);
      } else {
        throw new Error("an unexpected error try to fetch sniped segments");
      }
    } finally {
      setLoading(false);
    }
    console.log(snipedSegmentlist);
  }

  return (
    <>
      <Container className="mb-4">
        <SnipeSegmentsModal
          show={showSnipeSegmentModal}
          handleClose={handleCloseSnipeSegmentModal}
          handleSnipeSegments={handleSnipeSegments}
        />
        {!isSnipeList ? (
          <DisplaySegmentList
            segmentList={props.activitySegmentList}
            handleShowSnipeSegmentsModal={handleShowSnipeSegmentsModal}
          />
        ) : (
          <DisplaySnipedSegmentList
            snipedSegmentList={snipedSegmentlist}
            clearSnipedSegments={clearSnipedSegments}
          />
        )}
      </Container>
    </>
  );
};

export default SegmentList;
