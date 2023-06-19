import { useState } from "react";
import DisplaySegmentList from "./DisplaySegmentList";
import {
  SegmentListItem,
  SnipedSegmentListItem,
} from "../../models/Segment/Segment";
import React from "react";
import DisplaySnipedSegmentList from "./DisplaySnipedSegmentsList";

export interface segmentListProps {
  activitySegmentList: SegmentListItem[];
}
const SegmentList = (props: segmentListProps) => {
  const [isSnipeList, setIsSnipeList] = useState(false);

  const [snipedSegmentlist, setSnipedSegmentList] = useState<
    SnipedSegmentListItem[]
  >([]);

  async function handleSnipeSegments() {}

  return (
    <>
      {!isSnipeList ? (
        <DisplaySegmentList
          segmentList={props.activitySegmentList}
          handleSnipeSegments={handleSnipeSegments}
        />
      ) : (
        <DisplaySnipedSegmentList snipedSegmentList={snipedSegmentlist} />
      )}
    </>
  );
};

export default SegmentList;
