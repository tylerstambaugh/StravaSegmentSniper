import React from "react";
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
import * as Yup from "yup";
import { ActivitySearchProps } from "./Activity";

function ActivityListLookup({ activityLoading, handleSearch }) {
  interface ActivityLookupForm {
    activityId: number;
    startDate: Date;
    endDate: Date;
    activityType: string;
  }
  const validationSchema = Yup.object().shape({
    activityId: Yup.number().required("Activity ID Is required"),
    // activityId: Yup.string().when(["startDate", "endDate"], {
    //   is: undefined,
    //   then: Yup.string().required(
    //     "Activity ID or Start Date and End Date are required."
    //   ),
    //   otherwise: Yup.string(),
    // }),
    // startDate: Yup.date(),
    // endDate: Yup.date(),
    // activityType: Yup.string().required("Please select an Activity Type"),
  });

  const formik = useFormik<ActivityLookupForm>({
    initialValues: {
      activityId: 9102798217,
      startDate: new Date(),
      endDate: new Date(),
      activityType: "",
    },
    onSubmit: (values: ActivityLookupForm) => {
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
    validateOnChange: false,
  });
  return (
    <>
      <Container className="md-auto p-2 mb-1 col-8 bg-light text-dark border rounded">
        <Row>
          <Col>
            <h3>Activity List Lookup</h3>
            <Form name="activityLookupForm" onSubmit={formik.handleSubmit}>
              <Row className="md-auto p-2 mb-1">
                <div className="border rounded mb-1 p-2">
                  <div className="md-auto p-2 mb-1">
                    Look up by activity ID:
                  </div>
                  <Col>
                    <TextField
                      name="activityId"
                      value={formik.values.activityId}
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
                      disableFuture
                      onChange={(date: Date | null) =>
                        formik.setFieldValue("startDate", date)
                      }
                    />
                  </div>
                  <div>
                    <DatePicker
                      label="End Date"
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
