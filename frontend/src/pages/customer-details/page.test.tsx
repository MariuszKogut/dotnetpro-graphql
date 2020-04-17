import React from 'react'
import { render } from '@testing-library/react'
import CustomerDetailsPage from './page'

jest.mock('react-router', () => ({
  useParams: jest.fn().mockImplementationOnce(() => ({
    id: '4711',
  })),
}))

jest.mock('react-router-dom', () => ({
  useHistory: () => ({
    push: jest.fn(),
    history: jest.fn(),
  }),
}))

describe('CustomerDetailsPage', () => {
  it('renders without errors', () => {
    const { container } = render(<CustomerDetailsPage />)
    expect(container).toMatchSnapshot()
  })
})
