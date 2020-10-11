import React, { FunctionComponent, useMemo } from 'react'
import { IValidationProblemDetails } from '../services/customer-client'
import Form from 'react-bootstrap/Form'

export const hasErrors = (
  fieldName: string,
  problemDetails?: IValidationProblemDetails,
) =>
  problemDetails &&
  problemDetails.errors &&
  problemDetails.errors.hasOwnProperty(fieldName)
    ? problemDetails.errors[fieldName]
    : []

interface Props {
  fieldName: string
  problemDetails?: IValidationProblemDetails
}

const ProblemDetails: FunctionComponent<Props> = (props) => {
  const { fieldName, problemDetails } = props

  const errors = useMemo(() => hasErrors(fieldName, problemDetails), [
    fieldName,
    problemDetails,
  ])

  return (
    <>
      {errors && errors.length > 0 && (
        <Form.Control.Feedback type="invalid">
          {errors.map((x, i) => (
            <span key={i}>{x}</span>
          ))}
        </Form.Control.Feedback>
      )}
    </>
  )
}

export default ProblemDetails
