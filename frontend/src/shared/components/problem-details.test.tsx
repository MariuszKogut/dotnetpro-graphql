import React from 'react'
import { render } from '@testing-library/react'
import ProblemDetails from './problem-details'
import { IValidationProblemDetails } from '../services/customer-client'

describe('ProblemDetails', () => {
  const problemDetails: IValidationProblemDetails = {
    type: 'https://tools.ietf.org/html/rfc7231#section-6.5.1',
    title: 'One or more validation errors occurred.',
    status: 400,
    errors: {
      Name: [
        "'Name' darf nicht leer sein.",
        "Die Länge von 'Name' muss zwischen 3 und 255 Zeichen liegen. Es wurden 0 Zeichen eingetragen.",
      ],
    },
  }

  it('renders empty list if no ProblemDetails given', () => {
    const { container } = render(<ProblemDetails fieldName="Fieldname" />)
    expect(container).toMatchSnapshot()
  })

  it('renders empty list if fieldName does not match', () => {
    const { container } = render(
      <ProblemDetails fieldName="Fieldname" problemDetails={problemDetails} />,
    )
    expect(container).toMatchSnapshot()
  })

  it('renders one item if fieldName matches', () => {
    const { container } = render(
      <ProblemDetails fieldName="Name" problemDetails={problemDetails} />,
    )
    expect(container).toMatchSnapshot()
  })
})
