import { useState } from "react";
import DisplaySegmentList from "./DisplaySegmentList";
import {
  SegmentListItem,
  SnipedSegmentListItem,
} from "../../models/Segment/Segment";
import React from "react";
import DisplaySnipedSegmentList from "./DisplaySnipedSegmentsList";

export interface SnipeSegmentProps {
  activityId: number;
  secondsOff: number;
  percentageOff: number;
}
export interface segmentListProps {
  activitySegmentList: SegmentListItem[];
}
const SegmentList = (props: segmentListProps) => {
  const [showSnipeSegmentModal, setShowSnipeSegmentModal] = useState(false);
  const [isSnipeList, setIsSnipeList] = useState(false);

  const [snipedSegmentlist, setSnipedSegmentList] = useState<
    SnipedSegmentListItem[]
  >([]);

  const handleCloseSnipeSegmentModal = () => setShowSnipeSegmentModal(false);
  const handleShowSnipeSegmentModal = () => setShowSnipeSegmentModal(true);

  function clearSnipedSegments() {
    setSnipedSegmentList([]);
  }

  return (
    <>
      {!isSnipeList ? (
        <DisplaySegmentList
          segmentList={props.activitySegmentList}
          handleShowSnipeSegmentsModal={handleShowSnipeSegmentModal}
        />
      ) : (
        <DisplaySnipedSegmentList
          snipedSegmentList={snipedSegmentlist}
          clearSnipedSegments={clearSnipedSegments}
          handleShowSnipeSegmentModal={handleShowSnipeSegmentModal}
        />
      )}
    </>
  );
};

export default SegmentList;
