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
import { SegmentListItem } from "../../models/Segment/Segment";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faStar as solidStar,
  faCircleCheck as circleCheck,
} from "@fortawesome/free-solid-svg-icons";
import { faStar as regularStar } from "@fortawesome/free-regular-svg-icons";
import useStarSegment, {
  starSegmentProps,
} from "../../hooks/segment/useStarSegment";

export interface displaySegmentListProps {
  segmentList: SegmentListItem[];
  handleShowSnipeSegmentsModal: () => void;
  handleStarSegment: (props: starSegmentProps) => void;
}

type TableRow = SegmentListItem & {
  detailsButton: any;
  starButton: any;
};

function DisplaySegmentList(props: displaySegmentListProps) {
  const [listOfSegments, setListOfSegments] = useState<SegmentListItem[]>(
    props.segmentList
  );
  const tableBody: TableRow[] = props.segmentList.map((item) => ({
    ...item,
    detailsButton: null,
    starButton: null,
  }));

  const header: TableColumnType<TableRow>[] = [
    { title: "Name", prop: "name", isFilterable: true },
    { title: "Id", prop: "segmentId" },
    { title: "Distance", prop: "distance", isSortable: true },
    { title: "Time", prop: "time", isSortable: true },
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
            props.handleStarSegment({
              segmentId: row.segmentId,
              starSegment: !row.starred,
            });
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

  function clearSegmentsList() {
    setListOfSegments([]);
  }

  return (
    <>
      {props.segmentList.length > 0 ? (
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
                <h3>Segments</h3>
              </Col>
            </Row>
            <Row className="d-flex justify-content-between">
              <Col sm={3}>
                <Filter placeholder="Filter Segments" />
              </Col>
              <Col className="d-flex justify-content-end pb-3">
                <Button
                  as="input"
                  variant="primary"
                  value="Snipe!"
                  onClick={(e) => props.handleShowSnipeSegmentsModal()}
                />
              </Col>
            </Row>
            <Table>
              <TableHeader />
              <TableBody />
            </Table>
            <Row className="justify-content-between">
              <Col sm={2}>
                <PaginationOptions />
              </Col>
              <Col sm={5} className="mt-3">
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
                <p>No Results to Display</p>
              </Col>
            </Row>
          </DatatableWrapper>
        </Container>
      )}
    </>
  );
}

export default DisplaySegmentList;
