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

import ActivityList from "./mockData/mockActivities.json";

const tableBody = ActivityList as ArrayElementType[];

type ArrayElementType = (typeof ActivityList)[number] & {
  snipeButton: any;
  detailsButton: any;
};

const header: TableColumnType<ArrayElementType>[] = [
  { title: "Name", prop: "name", isFilterable: true },
  { title: "Id", prop: "id" },
  { title: "Date", prop: "startDate", isSortable: true },
  { title: "Distance", prop: "distance" },
  { title: "Achievements", prop: "achievementCount" },
  { title: "Max Speed", prop: "maxSpeed" },
  { title: "Gear", prop: "gearId" },
  {
    prop: "snipeButton",
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
    prop: "detailsButton",
    cell: (row) => (
      <Button
        variant="outline-primary"
        size="sm"
        onClick={() => {
          alert(`${row.id}'s achievement count is ${row.achievementCount}`);
        }}
      >
        Snipe Segments
      </Button>
    ),
  },
];

function DisplayActivityList() {
  return (
    <Container className="md-auto p-2 mb-1 col-12 bg-light text-dark border rounded">
      <DatatableWrapper body={tableBody} headers={header}>
        <Row>
          <Col>
            <h3>Activity Search Results</h3>
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
          <Col md={3}>
            <Pagination />
          </Col>
        </Row>
      </DatatableWrapper>
    </Container>
  );
}
export default DisplayActivityList;
