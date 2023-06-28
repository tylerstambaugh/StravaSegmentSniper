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

export interface displaySegmentListProps {
  segmentList: SegmentListItem[];
  handleShowSnipeSegmentsModal: () => void;
}

type TableRow = SegmentListItem & {
  detailsButton: any;
  starButton: any;
};

function DisplaySegmentList(props: displaySegmentListProps) {
  const [listOfSegments, setListOfSegments] = useState<SegmentListItem[]>(
    props.segmentList
  );
  //setListOfSegments(props.segmentList);
  const tableBody: TableRow[] = props.segmentList.map((item) => ({
    ...item,
    detailsButton: null,
    starButton: null,
  }));

  const header: TableColumnType<TableRow>[] = [
    { title: "Name", prop: "name", isFilterable: true },
    { title: "Id", prop: "id" },
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
            alert(`We'll star this segment`);
          }}
        >
          Star
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
                <h3>Segments</h3>
              </Col>
            </Row>
            <Row className="mb-4">
              <Col
                xs={12}
                lg={4}
                className="d-flex flex-col justify-content-end align-items-end"
              >
                <Filter />
              </Col>
              <Col>
                <Button
                  as="input"
                  variant="primary"
                  value="Snipe!"
                  onClick={(e) => props.handleShowSnipeSegmentsModal()}
                />
              </Col>
              <Col>
                <Button
                  as="input"
                  value="Clear"
                  onClick={(e) => clearSegmentsList()}
                ></Button>
              </Col>
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
