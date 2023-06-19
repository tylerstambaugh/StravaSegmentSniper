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

export interface displaySnipedSegmentListProps {
  snipedSegmentList: SnipedSegmentListItem[];
}

const [isSnipeList, setIsSnipeList] = useState();

type ArrayElementType = SegmentListItem & {
  detailsButton: any;
};

function DisplaySnipedSegmentList(props: displaySnipedSegmentListProps) {
  const tableBody: ArrayElementType[] = props.snipedSegmentList.map((item) => ({
    ...item,
    detailsButton: null,
  }));

  const header: TableColumnType<ArrayElementType>[] = [
    { title: "Name", prop: "name", isFilterable: true },
    { title: "Id", prop: "id" },
    { title: "Distance", prop: "distance", isSortable: true },
    { title: "Time", prop: "time", isSortable: true },
    { title: "% From KOM", prop: "percentOff", isSortable: true},
    { title: "Seconds From KOM", prop: "secondsOff", isSortable: true}
    {
      prop: "detailsButton",
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

  return (
    <>
      {props.snipedSegmentList.length > 0 ? (
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
              <Col>
                <Button
                  as="input"
                  value="Clear"
                  variant="primary"
                  onClick={(e) => props.handleSnipeSegments()}
                />
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

export default DisplaySnipedSegmentList;
