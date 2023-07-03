import { useEffect, useState } from "react";
import DisplaySegmentList from "./DisplaySegmentList";
import {
  SegmentDetails,
  SegmentListItem,
  SnipedSegmentListItem,
} from "../../models/Segment/Segment";
import React from "react";
import DisplaySnipedSegmentList from "./DisplaySnipedSegmentsList";
import SnipeSegmentsModal from "./SnipeSegmentsModal";
import { Container } from "react-bootstrap";
import useGetSnipeSegments from "../../hooks/segment/useGetSnipeSegments";
import SegmentDetailsModal from "./SegmentDetailsModal";

export interface SnipeSegmentFunctionProps {
  activityId?: string;
  secondsOff?: number;
  percentageOff?: number;
  useQom: boolean;
}
export interface SegmentListProps {
  activityId: string | undefined;
  activitySegmentList: SegmentListItem[];
}
const SegmentList = (props: SegmentListProps) => {
  const [showSnipeSegmentModal, setShowSnipeSegmentModal] = useState(false);
  const [showSegmentDetailModal, setShowSegmentDetailModal] = useState(false);
  const { snipedSegmentsError, snipedSegmentsLoading, fetchSnipedSegments } =
    useGetSnipeSegments();
  const [isSnipeList, setIsSnipeList] = useState(false);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error>();
  const [snipedSegmentlist, setSnipedSegmentList] = useState<
    SnipedSegmentListItem[]
  >([]);

  const [segmentDetailsModalData, setSegmentDetailsModalData] =
    useState<SegmentDetails>();

  const handleCloseSnipeSegmentModal = () => setShowSnipeSegmentModal(false);
  const handleShowSnipeSegmentModal = () => setShowSnipeSegmentModal(true);

  const handleCloseSegmentDetailModal = () => setShowSegmentDetailModal(false);
  const handleShowSegmentDetailModal = () => setShowSegmentDetailModal(true);

  function clearSnipedSegments() {
    setSnipedSegmentList([]);
    setIsSnipeList(false);
  }

  useEffect(() => {
    if (isSnipeList) {
      setIsSnipeList(true);
    }
  }, [isSnipeList]);

  useEffect(() => {
    setIsSnipeList(false);
  }, [props.activitySegmentList]);

  async function handleSnipeSegments(
    snipeSegmentsProps: SnipeSegmentFunctionProps
  ) {
    snipeSegmentsProps = {
      ...snipeSegmentsProps,
      activityId: props.activityId,
    };
    setLoading(true);
    try {
      console.log(
        `snipe segment search props ${JSON.stringify(
          snipeSegmentsProps,
          null,
          4
        )}`
      );
      const fetchResponse = await fetchSnipedSegments(snipeSegmentsProps!);
      if (fetchResponse && !(fetchResponse instanceof Error)) {
        setSnipedSegmentList(fetchResponse);
        setIsSnipeList(true);
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

  function clearSegmentsDisplay() {
    console.log("going to clear list of segments...");
  }

  function handleShowSegmentDetails(segmentId: number) {}

  return (
    <>
      <Container className="mb-4">
        <SnipeSegmentsModal
          show={showSnipeSegmentModal}
          handleClose={handleCloseSnipeSegmentModal}
          handleSnipeSegments={handleSnipeSegments}
        />
        <SegmentDetailsModal
          show={showSegmentDetailModal}
          handleClose={handleCloseSegmentDetailModal}
          segment={segmentDetailsModalData}
        />
        {!isSnipeList ? (
          <DisplaySegmentList
            segmentList={props.activitySegmentList}
            handleShowSnipeSegmentsModal={handleShowSnipeSegmentModal}
            // handleShowSegmentDetails={handleShowSegmentDetails}
          />
        ) : (
          <DisplaySnipedSegmentList
            snipedSegmentList={snipedSegmentlist}
            clearSnipedSegments={clearSnipedSegments}
            // handleShowSegmentDetails={handleShowSegmentDetails}
          />
        )}
      </Container>
    </>
  );
};

export default SegmentList;
