import React, { useState } from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import Modal from "react-bootstrap/Modal";
import { useFormik } from "formik";
import * as yup from "yup";
import { SnipeSegmentProps } from "./SegmentList";

interface ShowSnipeSegmentsModalProps {
  show: boolean;
  handleClose: () => void;
  handleSnipeSegments: (snipeProps: SnipeSegmentProps) => void;
}

function ShowSnipeSegmentsModal(props: ShowSnipeSegmentsModalProps) {

    const [validated, setValidated] = useState(false);
    interface SnipeSegmentsParametersForm {
        secondsFromKom: number | undefined,
        percentageFromKom: number | undefined,
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
          //console.log(`endDate = ${values.endDate}`);
    
          setValidated(true);
          const snipeProps: SnipeSegmentProps = {
            activityId: 123,
            secondsOff: values.secondsFromKom,
            percentageOff: values.percentageFromKom,
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
                        <Form name="SnipeSegmentsParametersForm"
                        onSubmit={(event) => {
                            event.preventDefault();
                            setValidated(true);
                            console.log(`formik isValid = ${formik.isValid}`);
                            console.log(`formik status = ${formik.status}`);
                            //console.log(`formik errors endDate = ${formik.errors.endDate}`);
                            formik.handleSubmit(event);
                          }}
                        >
                    </Col>
                </Row>
            </Container>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => props.handleClose()}>
            Cancel
          </Button>
          <Button
            variant="primary"
            onClick={(e) => {
              props.handleClose();
              props.handleSnipeSegments();
            }}
          >
            Snipe!
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default ShowSnipeSegmentsModal;
