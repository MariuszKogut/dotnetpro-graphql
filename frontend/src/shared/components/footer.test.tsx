import React from 'react'
import { render } from '@testing-library/react'
import Footer from './footer'

describe('Footer', () => {
  beforeAll(() => {
    jest.spyOn(Date.prototype, 'getFullYear').mockImplementationOnce(() => 1982)
  })

  it('renders without errors', () => {
    const { container } = render(<Footer />)
    expect(container).toMatchSnapshot()
  })
})
