import React, { ReactElement, ReactNode, useRef, useState } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "bootstrap/dist/css/bootstrap.css";
import { Container, Row, Col, Button } from "react-bootstrap";

function ActivityListLookup() {
  const [lookupStartDate, setLookupStartDate] = useState<Date>(new Date());
  const [lookupEndDate, setLookupEndDate] = useState<Date>(new Date());
  const activityIdRef = useRef<number>();

  function handleActivityIdChange(e: React.ChangeEvent<HTMLInputElement>) {
    console.log({ activityId: activityIdRef.current!.valueOf() });
  }

  function handleStartDateChange(e: Date) {
    setLookupStartDate(e);
  }

  function handleEndDateChange(e: Date) {
    setLookupEndDate(e);
  }

  function handleSearchClick(
    e: React.MouseEvent<HTMLButtonElement, MouseEvent>
  ) {
    console.log();
  }

  return (
    <>
      <Container
        fluid="md"
        className="md-auto p-3 mb-2 bg-light text-dark border rounded"
      >
        <Row>
          <Col>
            <h3>Activity List Lookup</h3>
            <form>
              <div>
                <Row className="md-auto p-3 mb-2">
                  <Col>
                    Enter an activity Id to look up:
                    <input
                      type="number"
                      ref="activityIdRef"
                      onChange={(e) => handleActivityIdChange(e)}
                    />
                  </Col>
                </Row>
                <Row>or look up a list of rides with a date range:</Row>
                <Row>
                  <Col>
                    start date:
                    <DatePicker
                      selected={lookupStartDate}
                      ref="startDateRef"
                      onChange={(date: Date | null) =>
                        handleStartDateChange(date!)
                      }
                    />
                    end date:
                    <DatePicker
                      selected={lookupEndDate}
                      ref="endDateRef"
                      onChange={(date: Date | null) =>
                        handleEndDateChange(date!)
                      }
                    />
                  </Col>
                </Row>
              </div>
              <Button
                as="input"
                type="submit"
                value="Search"
                variant="primary"
                className={"me-1"}
                onClick={(e) => handleSearchClick(e)}
              />
            </form>
          </Col>
        </Row>
      </Container>
    </>
  );
}

export default ActivityListLookup;
