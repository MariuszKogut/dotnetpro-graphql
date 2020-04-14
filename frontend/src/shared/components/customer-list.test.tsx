import React from 'react'
import { render, waitForElementToBeRemoved } from '@testing-library/react'
import CustomerList from './customer-list'
import { customerTestData } from '../../__testdata__/customer'

jest.mock('react-router-dom', () => ({
  useHistory: () => ({
    push: jest.fn(),
    history: jest.fn(),
  }),
}))

describe('CustomerList', () => {
  it('renders loader', () => {
    const { container } = render(<CustomerList />)
    expect(container).toMatchSnapshot()
  })

  it('renders no data message if no data given', async () => {
    jest.spyOn(window, 'fetch').mockImplementationOnce(() =>
      Promise.resolve({
        text: () => Promise.resolve('[]'),
        status: 200,
      } as Response),
    )

    // Act
    const { container, queryByText } = render(<CustomerList />)

    // Assert
    await waitForElementToBeRemoved(() =>
      queryByText('Daten werden geladen...'),
    )

    expect(container).toMatchSnapshot()
  })

  it('renders data correctly', async () => {
    // Arrange
    jest.spyOn(window, 'fetch').mockImplementationOnce(() =>
      Promise.resolve({
        text: () => Promise.resolve(JSON.stringify(customerTestData)),
        status: 200,
      } as Response),
    )

    // Act
    const { container, queryByText } = render(<CustomerList />)

    // Assert
    await waitForElementToBeRemoved(() =>
      queryByText('Daten werden geladen...'),
    )

    expect(container).toMatchSnapshot()
  })
})
