import React, { useState } from "react";
import { Button, Col, Container, Form, Row, Stack } from "react-bootstrap";
import Modal from "react-bootstrap/Modal";
import { useFormik } from "formik";
import * as yup from "yup";
import { SnipeSegmentFunctionProps } from "./SegmentList";
import {
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  TextField,
} from "@mui/material";
import { log } from "console";

export interface ShowSnipeSegmentsModalProps {
  show: boolean;
  handleClose: () => void;
  handleSnipeSegments: (snipeProps: SnipeSegmentFunctionProps) => void;
}

function ShowSnipeSegmentsModal(props: ShowSnipeSegmentsModalProps) {
  const [validated, setValidated] = useState(false);
  interface SnipeSegmentsParametersForm {
    secondsFromLeader?: number;
    percentageFromLeader?: number;
    useQom: string;
  }

  const validationSchema = yup.object().shape({
    secondsFromLeader: yup.number().nullable(),
    percentageFromLeader: yup.number().nullable(),
    useQom: yup.string().required("Select QOM or KOM"),
  });

  const formik = useFormik<SnipeSegmentsParametersForm>({
    initialValues: {
      secondsFromLeader: undefined,
      percentageFromLeader: undefined,
      useQom: "KOM",
    },
    onSubmit: (values: SnipeSegmentsParametersForm) => {
      console.log(`segment snipe form props: ${values}`);

      // setValidated(true);
      const snipeProps: SnipeSegmentFunctionProps = {
        secondsOff: values.secondsFromLeader,
        percentageOff: values.percentageFromLeader,
        useQom: (values.useQom as unknown) === "QOM" ? true : false,
      };
      props.handleSnipeSegments(snipeProps);
    },
    validationSchema,
    validateOnBlur: true,
    validateOnChange: false,
  });

  return (
    <>
      <Modal show={props.show} onHide={() => props.handleClose()}>
        <Modal.Header closeButton>
          <Modal.Title>Segment Sniping Parameters</Modal.Title>
        </Modal.Header>
        <Form
          name="SnipeSegmentsParametersForm"
          onSubmit={(event) => {
            console.log("handling submission");
            event.preventDefault();
            //setValidated(true);
            console.log(`formik isValid = ${formik.isValid}`);
            console.log(`formik status = ${formik.status}`);
            //console.log(`formik errors endDate = ${formik.errors.endDate}`);
            formik.handleSubmit(event);
            props.handleClose();
          }}
        >
          <Modal.Body>
            <Container>
              <Row>
                <Col>
                  <Form.Group controlId="secondsFromLeader">
                    <Form.Label>Seconds From Leader</Form.Label>
                    <Form.Control
                      type="number"
                      name="secondsFromLeader"
                      value={formik.values.secondsFromLeader || ""}
                      onChange={(e) => {
                        formik.setFieldValue(
                          "secondsFromLeader",
                          e.target.value
                        );
                      }}
                      isInvalid={Boolean(formik.errors.secondsFromLeader)}
                    />
                    <Form.Control.Feedback type="invalid">
                      {formik.errors.secondsFromLeader}
                    </Form.Control.Feedback>
                  </Form.Group>
                </Col>
              </Row>
              <Row>
                <Col>
                  <p>OR</p>
                </Col>
              </Row>
              <Row>
                <Col>
                  <Form.Group controlId="percentageFromLeader">
                    <Form.Label>Percentage From Leader</Form.Label>
                    <Form.Control
                      type="number"
                      name="percentageFromLeader"
                      value={formik.values.percentageFromLeader || ""}
                      onChange={(e) => {
                        formik.setFieldValue(
                          "percentageFromLeader",
                          e.target.value
                        );
                      }}
                      isInvalid={Boolean(formik.errors.percentageFromLeader)}
                    />
                    <Form.Control.Feedback type="invalid">
                      {formik.errors.percentageFromLeader}
                    </Form.Control.Feedback>
                  </Form.Group>
                </Col>
              </Row>
              <Row>
                <Col>
                  <Form.Group controlId="useQomRadio">
                    <Form.Label>Leader Time Type</Form.Label>
                    <Row>
                      <Col>
                        <Form.Check
                          type="radio"
                          name="useQom"
                          id="komRadio"
                          label="KOM"
                          value="KOM"
                          checked={formik.values.useQom === "KOM"}
                          onChange={(e) => {
                            formik.setFieldValue("useQom", "KOM");
                            console.log(formik.values);
                          }}
                        />
                      </Col>
                      <Col>
                        <Form.Check
                          type="radio"
                          name="useQom"
                          id="qomRadio"
                          label="QOM"
                          value="QOM"
                          checked={formik.values.useQom === "QOM"}
                          onChange={(e) => {
                            formik.setFieldValue("useQom", "QOM");
                            console.log(formik.values);
                          }}
                        />
                      </Col>
                    </Row>
                  </Form.Group>
                </Col>
              </Row>
            </Container>
          </Modal.Body>
        </Form>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => props.handleClose()}>
            Cancel
          </Button>
          <Button variant="primary" type="submit">
            Snipe!
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default ShowSnipeSegmentsModal;
