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
import { addDays } from "date-fns";
import dayjs, { Dayjs } from "dayjs";
import { useFormik } from "formik";
import * as yup from "yup";
import ActivityTypeEnum from "../../enums/activityTypes";
import { ActivitySearchProps } from "./Activity";

function ActivityListLookup({ activityLoading, handleSearch }) {
  const [validated, setValidated] = useState(false);
  const [startDateError, setStartDateError] = useState<string | undefined>("");
  const [endDateError, setEndDateError] = useState<string | undefined>("");

  //const minDate: Date = dayjs().subtract(45, "day").toDate();
  interface ActivityLookupForm {
    activityId?: string | null;
    startDate?: Date | null;
    endDate?: Date | null;
    activityType?: string | null;
  }

  const validationSchema = yup.object().shape({
    activityId: yup
      .number()
      .nullable()
      .test({
        name: "activityIdOrDateRange",
        test: function (value) {
          const { startDate, endDate } = this.parent;
          return !!value || (!!startDate && !!endDate);
        },
        message: "Please provide either activity ID or date range",
      }),

    // startDate: yup
    //   .date()
    //   .when(["activityId", "endDate"], (activityId, endDate, schema) =>
    //     !!activityId || !!endDate
    //       ? schema
    //           .required("Date range or activity ID required")
    //           .test(
    //             "startDateLessThan",
    //             "Start date must be before end date",
    //             function (value): boolean {
    //               const { endDate } = this.parent;
    //               return value < endDate;
    //             }
    //           )
    //       : schema.nullable()
    //   ),

    endDate: yup
      .date()
      .nullable()
      .when("startDate", (startDate, schema) =>
        startDate
          ? schema
              .min(startDate, "End date must be greater than start date")
              .required("End date is required when start date is present")
          : schema.nullable()
      ),
    activityType: yup.string().required("Please select an Activity Type"),
  });

  const initialValues = {
    activityId: undefined,
    activityType: "Ride",
    startDate: undefined,
    endDate: undefined,
  };

  const formik = useFormik<ActivityLookupForm>({
    initialValues,
    enableReinitialize: true,
    onSubmit: (values: ActivityLookupForm) => {
      setValidated(true);
      const searchProps: ActivitySearchProps = {
        activityId: values.activityId ?? "",
        startDate: values.startDate,
        endDate: values.endDate,
        activityType: values.activityType as unknown as ActivityTypeEnum,
      };
      handleSearch(searchProps);
    },
    validationSchema: validationSchema,
    validateOnBlur: validated,
    validateOnChange: validated,
  });

  const handleFormReset = () => {
    formik.resetForm({
      values: {
        ...formik.values,
        startDate: null,
        endDate: null,
      },
    });
    formik.setFieldValue("startDate", null);
    formik.setFieldValue("endDate", null);
    setValidated(false);
    setStartDateError("");
    setEndDateError("");
  };
  return (
    <>
      <Container className="md-auto p-2 mb-1 col-8 bg-light text-dark border rounded">
        <Row>
          <Col>
            <h3>Activity List Lookup</h3>
            <Form
              name="activityLookupForm"
              onSubmit={(event) => {
                console.log(`activity Id: ${formik.values.activityId}`);
                console.log(`activity Id error: ${formik.errors.activityId}`);

                event.preventDefault();
                setValidated(true);
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
                      defaultValue={formik.values.activityId || undefined}
                      value={formik.values.activityId || ""}
                      error={Boolean(formik.errors.activityId)}
                      helperText={formik.errors.activityId}
                      id="outlined-number"
                      label="Activity Id"
                      type="number"
                      onChange={(e) => {
                        formik.setFieldValue("activityId", e.target.value);
                        //formik.handleChange(e);
                      }}
                      onBlur={formik.handleBlur}
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
                  or look up a list with a date range:
                </div>
                <Stack direction="horizontal" gap={2}>
                  <div>
                    <DatePicker
                      label="Start Date"
                      slotProps={{
                        textField: {
                          error: startDateError !== "",
                          helperText: <>{startDateError}</>,
                        },
                      }}
                      onError={(err) => {
                        if (err === "disableFuture") {
                          setStartDateError("Date must be in past.");
                        } else if (err === "invalidDate") {
                          setStartDateError("Invalid Date");
                        } else {
                          setStartDateError(err ?? "");
                        }
                      }}
                      defaultValue={formik.values.startDate || null}
                      value={formik.values.startDate || null}
                      disableFuture
                      showDaysOutsideCurrentMonth
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
                          error: endDateError !== "",
                          helperText: <>{endDateError}</>,
                        },
                      }}
                      onError={(err) => {
                        if (err === "disableFuture") {
                          setEndDateError("Date must be in past.");
                        } else if (err === "invalidDate") {
                          setEndDateError("Invalid Date");
                        } else {
                          setEndDateError(err ?? "");
                        }
                      }}
                      defaultValue={formik.values.endDate ?? null}
                      value={formik.values.endDate || null}
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
                  <FormLabel id="activityTypeRadioButtons">
                    Activity Type
                  </FormLabel>
                  <RadioGroup
                    //aria-labelledby="activityTypeRadioButtons"
                    defaultValue={formik.values.activityType}
                    value={formik.values.activityType}
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
                      onClick={(e) => {
                        handleFormReset();
                        console.log("form reset called");
                      }}
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
