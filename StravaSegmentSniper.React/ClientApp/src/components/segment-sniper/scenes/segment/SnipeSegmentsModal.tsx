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
    useQom: boolean;
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
      useQom: false,
    },
    onSubmit: (values: SnipeSegmentsParametersForm) => {
      setValidated(true);
      const snipeProps: SnipeSegmentFunctionProps = {
        secondsOff: values.secondsFromLeader,
        percentageOff: values.percentageFromLeader,
        useQom: (values.useQom as unknown) === "QOM" ? true : false,
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
          <Modal.Body>
            <Container>
              <Row>
                <Col>
                  <TextField
                    name="secondsFromLeader"
                    defaultValue={formik.values.secondsFromLeader}
                    error={Boolean(formik.errors.secondsFromLeader)}
                    helperText={formik.errors.secondsFromLeader}
                    id="outlined-number"
                    label="Seconds From Leader"
                    type="number"
                    onChange={(e) => {
                      formik.setFieldValue("secondsFromLeader", e.target.value);
                      //formik.handleChange(e);
                    }}
                    InputLabelProps={{
                      shrink: true,
                    }}
                  />
                </Col>
              </Row>
              <Row>
                <Col>
                  <p>OR</p>
                </Col>
              </Row>
              <Row>
                <Col>
                  <TextField
                    name="percentageFromLeader"
                    defaultValue={formik.values.percentageFromLeader}
                    error={Boolean(formik.errors.percentageFromLeader)}
                    helperText={formik.errors.percentageFromLeader}
                    id="outlined-number"
                    label="Percentage From Leader"
                    type="number"
                    onChange={(e) => {
                      formik.setFieldValue(
                        "percentageFromLeader",
                        e.target.value
                      );
                    }}
                    InputLabelProps={{
                      shrink: true,
                    }}
                  />
                </Col>
              </Row>
              <Row>
                <Col>
                  <FormControl>
                    <FormLabel id="QomKomRadioLabel">
                      Leader Time Type
                    </FormLabel>
                    <RadioGroup
                      aria-labelledby="QomKomRadioGroupLabel"
                      defaultValue={formik.values.useQom}
                      value={formik.values.useQom}
                      name="useQomRadio"
                      row
                      onChange={(e) =>
                        formik.setFieldValue("useQom", e.target.value)
                      }
                    >
                      <FormControlLabel
                        value="KOM"
                        control={<Radio />}
                        label="KOM"
                      />
                      <FormControlLabel
                        value="QOM"
                        control={<Radio />}
                        label="QOM"
                      />
                    </RadioGroup>
                  </FormControl>
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
