import React from 'react'
import { render } from '@testing-library/react'
import Footer from './footer'

describe('Footer', () => {
  it('renders without errors', () => {
    const { container } = render(<Footer />)
    expect(container).toMatchSnapshot()
  })
})
