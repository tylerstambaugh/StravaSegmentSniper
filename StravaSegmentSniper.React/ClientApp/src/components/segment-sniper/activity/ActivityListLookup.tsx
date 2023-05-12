import React, { ReactElement, ReactNode, useRef, useState } from "react";
//import DatePicker from "react-datepicker";
//import "react-datepicker/dist/react-datepicker.css";
import "bootstrap/dist/css/bootstrap.css";
import { Container, Row, Col, Button, Stack } from "react-bootstrap";
import {
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  TextField,
} from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";

function ActivityListLookup() {
  const [lookupStartDate, setLookupStartDate] = useState<Date>(new Date());
  const [lookupEndDate, setLookupEndDate] = useState<Date>(new Date());
  const activityIdRef = useRef<HTMLInputElement>(null);
  const today = new Date();

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
    e.preventDefault();
    console.log();
  }

  return (
    <>
      <Container className="md-auto p-2 mb-1 col-8 bg-light text-dark border rounded">
        <Row>
          <Col>
            <h3>Activity List Lookup</h3>
            <form>
              <Row className="md-auto p-2 mb-1">
                <Col>
                  <FormControl>
                    <TextField
                      id="outlined-number"
                      label="Activity Id"
                      type="number"
                      InputLabelProps={{
                        shrink: true,
                      }}
                    />
                  </FormControl>
                </Col>
              </Row>
              <div className="md-auto p-2 mb-1">
                or look up a list of rides with a date range:
              </div>
              <div className="border rounded mb-1 p-2">
                <Stack direction="horizontal" gap={2}>
                  <div>
                    <label style={{ display: "inline-flex" }}>
                      <span style={{ marginRight: "1rem" }}>Start Date:</span>
                      <DatePicker
                        disableFuture
                        onChange={(date: Date | null) =>
                          handleStartDateChange(date!)
                        }
                      />
                    </label>
                  </div>
                  <div>
                    <label style={{ display: "flex" }}>
                      <span style={{ marginRight: "1rem" }}>End Date:</span>
                      <DatePicker
                        disableFuture
                        onChange={(date: Date | null) =>
                          handleEndDateChange(date!)
                        }
                      />
                    </label>
                  </div>
                </Stack>
              </div>
              <div>
                <FormControl>
                  <FormLabel id="demo-radio-buttons-group-label">
                    Activity Type
                  </FormLabel>
                  <RadioGroup
                    aria-labelledby="demo-radio-buttons-group-label"
                    defaultValue="ride"
                    name="row-radio-buttons-group"
                    row
                  >
                    <FormControlLabel
                      value="ride"
                      control={<Radio />}
                      label="Ride"
                    />
                    <FormControlLabel
                      value="walk"
                      control={<Radio />}
                      label="Walk"
                    />
                    <FormControlLabel
                      value="run"
                      control={<Radio />}
                      label="Run"
                    />
                    <FormControlLabel
                      value="hike"
                      control={<Radio />}
                      label="Hike"
                    />
                  </RadioGroup>
                </FormControl>
              </div>
              <Button
                as="input"
                type="submit"
                value="Search"
                variant="primary"
                className={"me-1"}
                //onClick={(e) => handleSearchClick(e)}
              />
            </form>
          </Col>
        </Row>
      </Container>
    </>
  );
}

export default ActivityListLookup;
