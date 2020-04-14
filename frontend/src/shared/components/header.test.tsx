import React from 'react'
import { render } from '@testing-library/react'
import Header from './header'

jest.mock('react-router-dom', () => ({
  useHistory: () => ({
    push: jest.fn(),
  }),
}))

describe('Header', () => {
  it('renders without errors', () => {
    const { container } = render(<Header />)
    expect(container).toMatchSnapshot()
  })
})
