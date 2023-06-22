import { useState } from "react";
import DisplaySegmentList from "./DisplaySegmentList";
import {
  SegmentListItem,
  SnipedSegmentListItem,
} from "../../models/Segment/Segment";
import React from "react";
import DisplaySnipedSegmentList from "./DisplaySnipedSegmentsList";
import SnipeSegmentsModal from "./SnipeSegmentsModal";

export interface SnipeSegmentProps {
  activityId: number;
  secondsOff?: number | undefined;
  percentageOff?: number | undefined;
}
export interface SegmentListProps {
  activitySegmentList: SegmentListItem[];
}
const SegmentList = (props: SegmentListProps) => {
  const [showSnipeSegmentModal, setShowSnipeSegmentModal] = useState(false);
  const [isSnipeList, setIsSnipeList] = useState(false);

  const [snipedSegmentlist, setSnipedSegmentList] = useState<
    SnipedSegmentListItem[]
  >([]);

  const handleCloseSnipeSegmentModal = () => setShowSnipeSegmentModal(false);
  const handleShowSnipeSegmentsModal = () => setShowSnipeSegmentModal(true);

  function clearSnipedSegments() {
    setSnipedSegmentList([]);
    setIsSnipeList(false);
  }

  async function handleSnipeSegments() {}

  return (
    <>
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
    </>
  );
};

export default SegmentList;
