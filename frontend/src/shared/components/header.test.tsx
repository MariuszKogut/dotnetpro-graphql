import React from 'react'
import { screen, render, fireEvent, waitFor } from '@testing-library/react'
import Header from './header'

jest.mock('react-router-dom', () => ({
  useHistory: () => ({
    push: jest.fn(),
  }),
}))

jest.mock('react-use', () => ({
  useNetwork: jest
    .fn()
    .mockImplementationOnce(() => ({
      online: true,
    }))
    .mockImplementationOnce(() => ({
      online: true,
    }))
    .mockImplementationOnce(() => ({
      online: false,
    })),
}))

describe('Header', () => {
  it('renders without errors', () => {
    const { container } = render(<Header />)
    expect(container).toMatchSnapshot()
  })

  it('renders menu when it was clicked', async () => {
    const { container } = render(<Header />)

    fireEvent.click(screen.getByText('Kunden'))

    await waitFor(
      () => screen.getByText('Liste') && screen.getByText('Hinzufügen'),
    )

    expect(container).toMatchSnapshot()
  })

  it('renders offline badge if connection is broken', async () => {
    const { container } = render(<Header />)

    await waitFor(() => screen.getByText('Offline'))

    expect(container).toMatchSnapshot()
  })
})
