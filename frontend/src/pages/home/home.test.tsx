import React from 'react'
import { render } from '@testing-library/react'
import Home from './home'

jest.mock('react-router-dom', () => ({
  useHistory: () => ({
    history: jest.fn(),
  }),
}))

describe('Home', () => {
  it('renders without errors', () => {
    const { container } = render(<Home />)
    expect(container).toMatchSnapshot()
  })
})
