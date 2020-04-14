import React from 'react'
import { render } from '@testing-library/react'
import CustomerDetails from './customer-details'

jest.mock('react-router-dom', () => ({
  useHistory: () => ({
    push: jest.fn(),
  }),
}))

describe('CustomerDetails', () => {
  it('renders loading state correctly', () => {
    const { container } = render(<CustomerDetails />)
    expect(container).toMatchSnapshot()
  })

  it('renders insert form correctly', () => {
    // ToDo: insert
    const { container } = render(<CustomerDetails />)
    expect(container).toMatchSnapshot()
  })

  it('renders edit form correctly', () => {
    // ToDo: edit
    const { container } = render(<CustomerDetails />)
    expect(container).toMatchSnapshot()
  })
})
