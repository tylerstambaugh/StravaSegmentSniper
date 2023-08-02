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
import useStarSegment, {
  starSegmentProps,
} from "../../hooks/segment/useStarSegment";
import { toast } from "react-toastify";

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
  const [snipeLoading, setSnipeLoading] = useState(false);
  const [error, setError] = useState<Error>();
  const [segmentList, setSegmentList] = useState<SegmentListItem[]>(
    props.activitySegmentList
  );
  const [snipedSegmentlist, setSnipedSegmentList] = useState<
    SnipedSegmentListItem[]
  >([]);

  const starSegment = useStarSegment();

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

  async function handleStarSegment(props: starSegmentProps) {
    setLoading(true);

    const starSegmentResponse = await starSegment.starSegment({
      segmentId: props.segmentId,
      starSegment: props.starSegment,
    });
    if (starSegmentResponse && !(starSegmentResponse instanceof Error)) {
      const updatedSegmentList = segmentList.map((segment) => {
        if (segment.segmentId === props.segmentId) {
          return { ...segment, starred: starSegmentResponse.starred };
        }
        return segment;
      });
      setSegmentList(updatedSegmentList);
      setLoading(false);
    }
  }

  useEffect(() => {
    if (isSnipeList) {
      setIsSnipeList(true);
    }
  }, [isSnipeList]);

  useEffect(() => {
    setSegmentList(props.activitySegmentList);
    setIsSnipeList(false);
  }, [props.activitySegmentList]);

  async function handleSnipeSegments(
    snipeSegmentsProps: SnipeSegmentFunctionProps
  ) {
    snipeSegmentsProps = {
      ...snipeSegmentsProps,
      activityId: props.activityId,
    };
    setSnipeLoading(true);
    const fetchResponse = await fetchSnipedSegments(snipeSegmentsProps!);
    if (fetchResponse && !(fetchResponse instanceof Error)) {
      setSnipedSegmentList(fetchResponse);
      setIsSnipeList(true);
    } else {
      toast.error(`There was an error sniping the segemtns: ${fetchResponse}`, {
        autoClose: 1500,
        position: "bottom-center",
      });
    }
    setSnipeLoading(false);
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
            segmentList={segmentList}
            handleShowSnipeSegmentsModal={handleShowSnipeSegmentModal}
            // handleShowSegmentDetails={handleShowSegmentDetails}
            handleStarSegment={handleStarSegment}
            snipeLoading={snipeLoading}
          />
        ) : (
          <DisplaySnipedSegmentList
            snipedSegmentList={snipedSegmentlist}
            clearSnipedSegments={clearSnipedSegments}
            handleStarSegment={handleStarSegment}
            // handleShowSegmentDetails={handleShowSegmentDetails}
          />
        )}
      </Container>
    </>
  );
};

export default SegmentList;
