import React from "react";
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

import { ActivityListItem } from "../../models/Activity/ActivityListItem";
export interface displayActivityListProps {
  activityList: ActivityListItem[];
  handleShowSegments(activityId: string);
  clearSearchResults: () => void;
}
type ArrayElementType = ActivityListItem & {
  segmentsButton: any;
  snipeButton: any;
  detailsButton: any;
};

const DisplayActivityList = (props: displayActivityListProps) => {
  const tableBody: ArrayElementType[] = props.activityList.map((item) => ({
    ...item,
    segmentsButton: null,
    snipeButton: null,
    detailsButton: null,
  }));
  const header: TableColumnType<ArrayElementType>[] = [
    { title: "Name", prop: "name", isFilterable: true },
    { title: "Id", prop: "id" },
    { title: "Date", prop: "startDate", isSortable: true },
    { title: "Distance", prop: "distance", isSortable: true },
    { title: "Time", prop: "elapsedTime", isSortable: true },
    { title: "Achievements", prop: "achievementCount", isSortable: true },
    { title: "Max Speed", prop: "maxSpeed", isSortable: true },
    {
      prop: "detailsButton",
      cell: (row) => (
        <Button
          variant="outline-primary"
          size="sm"
          onClick={() => {
            alert(`${row.id}'s achievement count is ${row.achievementCount}`);
          }}
        >
          Details
        </Button>
      ),
    },
    {
      prop: "segments",
      cell: (row) => (
        <Button
          variant="outline-primary"
          size="sm"
          onClick={() => {
            props.handleShowSegments(row.id ?? "");
          }}
        >
          Segments
        </Button>
      ),
    },
  ];

  return (
    <>
      {props.activityList.length > 0 ? (
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
            <div>
              <Row>
                <Col>
                  <h3>Activity Search Results</h3>
                </Col>
                <Col>
                  <Button
                    as="input"
                    value="Clear"
                    onClick={(e) => props.clearSearchResults()}
                  ></Button>
                </Col>
              </Row>
            </div>
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
                <h3>Activity Search Results</h3>
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
};
export default DisplayActivityList;
