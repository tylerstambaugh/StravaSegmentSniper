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
import ActivityTypeEnum from "../../enums/activityTypes";

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
    activityId: yup.number().nullable(),
    // startDate: yup.date().nullable(),
    // endDate: yup.date().nullable(),
    activityType: yup.string().required("Please select an Activity Type"),
  });
  // .test(
  //   "activityOrDates",
  //   "Please provide an activity ID or both start and end dates.",
  //   function (values) {
  //     const { activityId, startDate, endDate } = values;

  //     if (!activityId && (!startDate || !endDate)) {
  //       return this.createError({
  //         path: "activityId",
  //         message:
  //           "Please provide an activity ID or both start and end dates.",
  //       });
  //     }
  //     return true;
  //   }
  // );

  const formik = useFormik<ActivityLookupForm>({
    initialValues: {
      activityId: undefined,
      activityType: undefined,
      startDate: undefined,
      endDate: undefined,
    },
    onSubmit: (values: ActivityLookupForm) => {
      console.log(`endDate = ${values.endDate}`);

      setValidated(true);
      const searchProps: ActivitySearchProps = {
        activityId: values.activityId,
        startDate: values.startDate,
        endDate: values.endDate,
        activityType: values.activityType as unknown as ActivityTypeEnum,
      };
      handleSearch(searchProps);
    },
    validationSchema,
    validateOnBlur: true,
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
                event.preventDefault();
                setValidated(true);
                console.log(`formik isValid = ${formik.isValid}`);
                console.log(`formik status = ${formik.status}`);
                console.log(`formik errors endDate = ${formik.errors.endDate}`);
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
                      defaultValue={formik.values.activityId}
                      error={Boolean(formik.errors.activityId)}
                      helperText={formik.errors.activityId}
                      id="outlined-number"
                      label="Activity Id"
                      type="number"
                      onChange={(e) => {
                        formik.setFieldValue("activityId", e.target.value);
                        //formik.handleChange(e);
                      }}
                      InputLabelProps={{
                        shrink: true,
                      }}
                    />
                  </Col>
                  <Col>
                    <p>Activity Id for test = 9102798217</p>
                  </Col>
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
                      defaultValue={formik.values.startDate ?? null}
                      disableFuture
                      onChange={(date: Date | null) => {
                        formik.setFieldValue("startDate", date);
                        console.log(`start date: ${date}`);
                      }}
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
                      defaultValue={formik.values.endDate ?? null}
                      disableFuture
                      onChange={(date: Date | null) => {
                        formik.setFieldValue("endDate", date);
                        console.log(`end date: ${date}`);
                      }}
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
                    defaultValue="Ride"
                    name="row-radio-buttons-group"
                    row
                    onChange={(e) =>
                      formik.setFieldValue("activityType", e.target.value)
                    }
                  >
                    <FormControlLabel
                      value="Ride"
                      control={<Radio />}
                      label="Ride"
                    />
                    <FormControlLabel
                      value="Walk"
                      control={<Radio />}
                      label="Walk"
                    />
                    <FormControlLabel
                      value="Run"
                      control={<Radio />}
                      label="Run"
                    />
                    <FormControlLabel
                      value="Hike"
                      control={<Radio />}
                      label="Hike"
                    />
                    <FormControlLabel
                      value="All"
                      control={<Radio />}
                      label="All"
                    />
                  </RadioGroup>
                </FormControl>
              </div>
              <div className="d-flex justify-content-end">
                <Row>
                  <Col>
                    <Button
                      type="submit"
                      variant="primary"
                      className={"me-1"}
                      disabled={activityLoading}
                    >
                      Search
                    </Button>
                  </Col>
                  <Col>
                    <Button
                      variant="secondary"
                      className={"me-1"}
                      onClick={(e) => formik.resetForm()}
                    >
                      Reset
                    </Button>
                  </Col>
                </Row>
              </div>
            </Form>
          </Col>
        </Row>
      </Container>
    </>
  );
}

export default ActivityListLookup;
