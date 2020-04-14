import React from 'react'
import { render, fireEvent, screen } from '@testing-library/react'
import ShortCutButton from './shortcut-button'

describe('ShortCutButton', () => {
  it('renders without errors', () => {
    const { container } = render(
      <ShortCutButton keyboardShortcut="b">Button</ShortCutButton>,
    )
    expect(container).toMatchSnapshot()
  })

  it('renders with bootstrap specific options', () => {
    const { container } = render(
      <ShortCutButton keyboardShortcut="b" variant="secondary">
        Button
      </ShortCutButton>,
    )
    expect(container).toMatchSnapshot()
  })

  it('should call onClick when button was clicked', () => {
    const clickHandler = jest.fn()

    render(
      <ShortCutButton keyboardShortcut="b" onClick={clickHandler}>
        Button
      </ShortCutButton>,
    )

    fireEvent.click(screen.getByText('Button'))

    expect(clickHandler).toBeCalledTimes(1)
  })

  it('should not call onClick when button was not clicked', () => {
    const clickHandler = jest.fn()

    render(
      <ShortCutButton keyboardShortcut="b" onClick={clickHandler}>
        Button
      </ShortCutButton>,
    )

    expect(clickHandler).toBeCalledTimes(0)
  })
})
