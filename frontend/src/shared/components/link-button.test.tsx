import React from 'react'
import { render } from '@testing-library/react'
import LinkButton from './link-button'

jest.mock('react-router-dom', () => ({
  useHistory: jest.fn(),
}))

describe('LinkButton', () => {
  it('renders without errors', () => {
    const { container } = render(
      <LinkButton to="http://www.handmade-systems.de" />,
    )
    expect(container).toMatchSnapshot()
  })
})
