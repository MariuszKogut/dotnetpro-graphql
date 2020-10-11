import React, { FunctionComponent, HTMLAttributes } from 'react'
import { ButtonProps } from 'react-bootstrap'
import Button from 'react-bootstrap/Button'
import { useKey } from 'react-use'

export interface ShortcutButtonProps
  extends ButtonProps,
    HTMLAttributes<HTMLButtonElement> {
  keyboardShortcut?: string
  onClick?: () => void
}

const ShortcutButton: FunctionComponent<ShortcutButtonProps> = ({
  keyboardShortcut,
  onClick,
  ...rest
}) => {
  useKey(
    (keyFilter) =>
      keyboardShortcut !== undefined &&
      keyFilter.altKey &&
      keyFilter.ctrlKey &&
      keyFilter.key === keyboardShortcut,
    () => handleClick(),
  )

  const handleClick = () => {
    if (onClick) {
      onClick()
    }
  }

  return <Button {...rest} onClick={() => handleClick()} />
}

export default ShortcutButton
