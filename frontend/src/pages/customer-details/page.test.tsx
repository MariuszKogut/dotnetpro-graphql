import React from 'react'
import { render } from '@testing-library/react'
import CustomerDetailsPage from './page'

describe('CustomerDetailsPage', () => {
  it('renders without errors', () => {
    const { container } = render(<CustomerDetailsPage />)
    expect(container).toMatchSnapshot()
  })
})
