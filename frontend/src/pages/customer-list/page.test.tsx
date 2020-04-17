import React from 'react'
import { render } from '@testing-library/react'
import Page from './page'

jest.mock('react-router-dom', () => ({
  useHistory: () => ({
    history: jest.fn(),
  }),
}))

describe('Page', () => {
  it('renders without errors', () => {
    const { container } = render(<Page />)
    expect(container).toMatchSnapshot()
  })
})
