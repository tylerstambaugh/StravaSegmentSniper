import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.css";
import { Container, Row, Col, Button, Stack, Form } from "react-bootstrap";
import {
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  TextField,
} from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { useFormik } from "formik";
import * as yup from "yup";
import { ActivitySearchProps } from "./Activity";

function ActivityListLookup({ activityLoading, handleSearch }) {
  const [validated, setValidated] = useState(false);
  const [startDateError, setStartDateError] = useState("");
  const [endDateError, setEndDateError] = useState("");

  interface ActivityLookupForm {
    activityId?: number;
    startDate?: Date;
    endDate?: Date;
    activityType?: string;
  }
  const validationSchema = yup.object().shape({
    activityId: yup
      .number()
      .typeError("Activity ID Must Be A Number")
      .test(
        "activity-id-test",
        "Activity ID or Start and End Date are required.",
        (value, ctx) => {
          const { startDate, endDate } = ctx.parent;
          const isStartDateMissing = !startDate && endDate;
          const isEndDateMissing = startDate && !endDate;

          if (!value && (isStartDateMissing || isEndDateMissing)) {
            return false; // Fail validation
          }
          return true; // Pass validation
        }
      ),

    // startDate: yup
    //   .date()
    //   .typeError("Please enter a valid date")
    //   .test(
    //     "start-date-test",
    //     "Start and end date are required",
    //     (value, ctx) => {
    //       const endDate = ctx.parent;

    //       if (value && !endDate) {
    //         return false;
    //       }
    //       return true;
    //     }
    //   ),
    // endDate: yup
    //   .date()
    //   .typeError("Please enter a valid date")
    //   .test(
    //     "end-date-test",
    //     "End and start date are required",
    //     (value, ctx) => {
    //       const startDate = ctx.parent;

    //       if (value && !startDate) {
    //         return false;
    //       }
    //       return true;
    //     }
    //   ),
    activityType: yup.string().required("Please select an Activity Type"),
  });

  const formik = useFormik<ActivityLookupForm>({
    initialValues: {
      activityId: 9102798217,
      activityType: "",
    },
    onSubmit: (values: ActivityLookupForm) => {
      console.log(`endDate = ${values.endDate}`);

      const searchProps: ActivitySearchProps = {
        activityId: values.activityId,
        startDate: values.startDate,
        endDate: values.endDate,
        activityType: values.activityType,
      };
      handleSearch(searchProps);
    },
    validationSchema,
    validateOnBlur: false,
    validateOnChange: true,
  });
  return (
    <>
      <Container className="md-auto p-2 mb-1 col-8 bg-light text-dark border rounded">
        <Row>
          <Col>
            <h3>Activity List Lookup</h3>
            <Form
              name="activityLookupForm"
              onSubmit={(event) => {
                // event.preventDefault();
                // setValidated(true);
                formik.handleSubmit(event);
              }}
            >
              <Row className="md-auto p-2 mb-1">
                <div className="border rounded mb-1 p-2">
                  <div className="md-auto p-2 mb-1">
                    Look up by activity ID:
                  </div>
                  <Col>
                    <TextField
                      name="activityId"
                      value={formik.values.activityId}
                      error={Boolean(formik.errors.activityId)}
                      helperText={formik.errors.activityId}
                      id="outlined-number"
                      label="Activity Id"
                      type="number"
                      onChange={(e) => {
                        formik.setFieldValue("activityId", e.target.value);
                        formik.handleChange(e);
                      }}
                      InputLabelProps={{
                        shrink: true,
                      }}
                    />
                  </Col>
                  <Col></Col>
                </div>
              </Row>

              <div className="border rounded mb-1 p-2">
                <div className="md-auto p-2 mb-1">
                  or look up a list of rides with a date range:
                </div>
                <Stack direction="horizontal" gap={2}>
                  <div>
                    <DatePicker
                      label="Start Date"
                      slotProps={{
                        textField: {
                          error: !!startDateError,
                          helperText: "Invalid Date",
                        },
                      }}
                      onError={(err) =>
                        setStartDateError(err ?? "an error with start date")
                      }
                      value={formik.values.startDate ?? null}
                      disableFuture
                      onChange={(date: Date | null) =>
                        formik.setFieldValue("startDate", date)
                      }
                    />
                  </div>
                  <div>
                    <DatePicker
                      label="End Date"
                      slotProps={{
                        textField: {
                          error: !!endDateError,
                          helperText: "Invalid Date",
                        },
                      }}
                      onError={(err) =>
                        setEndDateError(err ?? "an error with end date")
                      }
                      value={formik.values.endDate ?? null}
                      disableFuture
                      onChange={(date: Date | null) =>
                        formik.setFieldValue("endDate", date)
                      }
                    />
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
              />
            </Form>
          </Col>
        </Row>
      </Container>
    </>
  );
}

export default ActivityListLookup;
