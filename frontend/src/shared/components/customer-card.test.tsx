import React from 'react'
import { render } from '@testing-library/react'
import CustomerCard from './customer-card'
import { customerTestData } from '../../__testdata__/customer'

jest.mock('react-router-dom', () => ({
  useHistory: () => ({
    push: jest.fn(),
    history: jest.fn(),
  }),
}))

describe('CustomerCard', () => {
  it('renders without errors', () => {
    const { container } = render(
      <CustomerCard customer={customerTestData[0]} />,
    )
    expect(container).toMatchSnapshot()
  })
})
