import React, { useState } from "react";
import { Button, Col, Container, Form, Row, Stack } from "react-bootstrap";
import Modal from "react-bootstrap/Modal";
import { useFormik } from "formik";
import * as yup from "yup";
import { SnipeSegmentProps } from "./SegmentList";
import { TextField } from "@mui/material";

interface ShowSnipeSegmentsModalProps {
  show: boolean;
  handleClose: () => void;
  handleSnipeSegments: (snipeProps: SnipeSegmentProps) => void;
}

function ShowSnipeSegmentsModal(props: ShowSnipeSegmentsModalProps) {
  const [validated, setValidated] = useState(false);
  interface SnipeSegmentsParametersForm {
    secondsFromKom?: number;
    percentageFromKom?: number;
  }

  const validationSchema = yup.object().shape({
    secondsFromTopTen: yup.number().nullable(),
  });

  const formik = useFormik<SnipeSegmentsParametersForm>({
    initialValues: {
      secondsFromKom: undefined,
      percentageFromKom: undefined,
    },
    onSubmit: (values: SnipeSegmentsParametersForm) => {
      setValidated(true);
      const snipeProps: SnipeSegmentProps = {
        activityId: 123,
        secondsOff: values.secondsFromKom ?? undefined,
        percentageOff: values.percentageFromKom ?? undefined,
      };
      props.handleSnipeSegments(snipeProps);
    },
    validationSchema,
    validateOnBlur: true,
    validateOnChange: true,
  });

  return (
    <>
      <Modal show={props.show} onHide={() => props.handleClose()}>
        <Modal.Header closeButton>
          <Modal.Title>Segment Sniping Parameters</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Container>
            <Row>
              <Col>
                <Form
                  name="SnipeSegmentsParametersForm"
                  onSubmit={(event) => {
                    console.log("handling submission");

                    event.preventDefault();
                    setValidated(true);
                    console.log(`formik isValid = ${formik.isValid}`);
                    console.log(`formik status = ${formik.status}`);
                    //console.log(`formik errors endDate = ${formik.errors.endDate}`);
                    formik.handleSubmit(event);
                    props.handleClose();
                  }}
                >
                  <Stack direction="vertical" gap={2}>
                    <Col>
                      <TextField
                        name="secondsFromKom"
                        defaultValue={formik.values.secondsFromKom}
                        error={Boolean(formik.errors.secondsFromKom)}
                        helperText={formik.errors.secondsFromKom}
                        id="outlined-number"
                        label="Seconds From KOM"
                        type="number"
                        onChange={(e) => {
                          formik.setFieldValue(
                            "secondsFromKom",
                            e.target.value
                          );
                          //formik.handleChange(e);
                        }}
                        InputLabelProps={{
                          shrink: true,
                        }}
                      />
                    </Col>
                    <p>OR</p>
                    <Col>
                      <TextField
                        name="percentageFromKom"
                        defaultValue={formik.values.percentageFromKom}
                        error={Boolean(formik.errors.percentageFromKom)}
                        helperText={formik.errors.percentageFromKom}
                        id="outlined-number"
                        label="Percentage From KOM"
                        type="number"
                        onChange={(e) => {
                          formik.setFieldValue(
                            "percentageFromKom",
                            e.target.value
                          );
                        }}
                        InputLabelProps={{
                          shrink: true,
                        }}
                      />
                    </Col>
                  </Stack>
                  <Button
                    variant="secondary"
                    onClick={() => props.handleClose()}
                  >
                    Cancel
                  </Button>
                  <Button variant="primary" type="submit">
                    Snipe!
                  </Button>
                </Form>
              </Col>
            </Row>
          </Container>
        </Modal.Body>
        <Modal.Footer></Modal.Footer>
      </Modal>
    </>
  );
}

export default ShowSnipeSegmentsModal;
