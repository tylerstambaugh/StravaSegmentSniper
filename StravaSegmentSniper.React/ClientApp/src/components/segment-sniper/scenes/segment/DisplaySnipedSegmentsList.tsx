import React, { useState } from "react";
import {
  DatatableWrapper,
  Filter,
  Pagination,
  PaginationOptions,
  TableBody,
  TableColumnType,
  TableHeader,
} from "react-bs-datatable";
import { Button, Col, Container, Row, Table } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import {
  SegmentListItem,
  SnipedSegmentListItem,
} from "../../models/Segment/Segment";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCircleCheck as circleCheck } from "@fortawesome/free-solid-svg-icons";
import { faStar as regularStar } from "@fortawesome/free-regular-svg-icons";
import { starSegmentProps } from "../../hooks/segment/useStarSegment";

export interface displaySnipedSegmentListProps {
  snipedSegmentList: SnipedSegmentListItem[];
  clearSnipedSegments: () => void;
  handleStarSegment: (props: starSegmentProps) => void;
}

type TableRow = SnipedSegmentListItem & {
  detailsButton: any;
  starButton: any;
  rowLoading: boolean;
};

function DisplaySnipedSegmentList(props: displaySnipedSegmentListProps) {
  const [listOfSnipedSegments, setListOfSegments] = useState<
    SnipedSegmentListItem[]
  >(props.snipedSegmentList);

  const tableBody: TableRow[] = props.snipedSegmentList.map((item) => ({
    ...item,
    detailsButton: null,
    starButton: null,
    rowLoading: false,
  }));

  const header: TableColumnType<TableRow>[] = [
    { title: "Name", prop: "name", isFilterable: true },
    { title: "Id", prop: "segmentId" },
    { title: "Distance", prop: "distance", isSortable: true },
    { title: "KOM Time", prop: "komTime", isSortable: true },
    {
      title: "Seconds From KOM/QOM",
      prop: "secondsFromLeader",
      isSortable: true,
    },
    { title: "% From KOM/QOM", prop: "percentageFromLeader", isSortable: true },
    {
      prop: "detailsButton",
      cell: (row) => (
        <Button
          variant="outline-primary"
          size="sm"
          onClick={() => {
            alert(`We'll show details`);
          }}
        >
          Details
        </Button>
      ),
    },
    {
      prop: "starButton",
      cell: (row) => (
        <Button
          variant="outline-primary"
          size="sm"
          onClick={() => {
            handleStarSegmentClick(row);
          }}
        >
          {row.starred ? (
            <FontAwesomeIcon icon={circleCheck} />
          ) : (
            <FontAwesomeIcon icon={regularStar} />
          )}
        </Button>
      ),
    },
  ];

  const handleStarSegmentClick = async (row: TableRow) => {
    setListOfSegments((prevList) =>
      prevList.map((item) =>
        item.segmentId === row.segmentId ? { ...item, rowLoading: true } : item
      )
    );

    try {
      await props.handleStarSegment({
        segmentId: row.segmentId,
        starSegment: !row.starred,
      });
      setListOfSegments((prevList) =>
        prevList.map((item) =>
          item.segmentId === row.segmentId
            ? { ...item, rowLoading: false }
            : item
        )
      );
    } catch (error) {
      console.error("Error occurred while starring the segment:", error);
      setListOfSegments((prevList) =>
        prevList.map((item) =>
          item.segmentId === row.segmentId
            ? { ...item, rowLoading: false }
            : item
        )
      );
    }
  };

  return (
    <>
      {props.snipedSegmentList.length > 0 ? (
        <Container className="p-2 mb-1 col-12 bg-light text-dark border rounded">
          <DatatableWrapper
            body={tableBody}
            headers={header}
            paginationOptionsProps={{
              initialState: {
                rowsPerPage: 10,
                options: [5, 10, 15, 20],
              },
            }}
          >
            <Row>
              <Col>
                <h3>Sniped Segments</h3>
              </Col>
            </Row>
            <Row className="d-flex justify-content-between">
              <Col sm={3}>
                <Filter />
              </Col>
              <Col className="d-flex justify-content-end pb-3">
                <Button
                  as="input"
                  value="Reset"
                  variant="primary"
                  onClick={(e) => props.clearSnipedSegments()}
                />
              </Col>
            </Row>
            <Row className="mb-4">
              <Col
                xs={12}
                sm={6}
                lg={4}
                className="d-flex flex-col justify-content-lg-center align-items-center justify-content-sm-start mb-2 mb-sm-0"
              ></Col>
              <Col
                xs={12}
                sm={6}
                lg={4}
                className="d-flex flex-col justify-content-end align-items-end"
              ></Col>
            </Row>
            <Table>
              <TableHeader />
              <TableBody />
            </Table>
            <Row className="justify-content-between">
              <Col md={2}>
                <PaginationOptions />
              </Col>
              <Col md={5}>
                <Pagination />
              </Col>
            </Row>
          </DatatableWrapper>
        </Container>
      ) : (
        <Container className="md-auto p-2 mb-1 col-12 bg-light text-dark border rounded">
          <DatatableWrapper
            body={tableBody}
            headers={header}
            paginationOptionsProps={{
              initialState: {
                rowsPerPage: 10,
                options: [5, 10, 15, 20],
              },
            }}
          >
            <Row>
              <Col>
                <h3>Segments List Results</h3>
              </Col>
            </Row>
            <Row>
              <Col>
                <p>Try harder next time woosie</p>
                <p>No segments to snipe!</p>
              </Col>
            </Row>
          </DatatableWrapper>
        </Container>
      )}
    </>
  );
}

export default DisplaySnipedSegmentList;
