import React, { FunctionComponent } from 'react'
import { useHistory } from 'react-router-dom'
import ShortcutButton, { ShortcutButtonProps } from './shortcut-button'

interface Props extends ShortcutButtonProps {
  to: string
}

const LinkButton: FunctionComponent<Props> = ({ to, ...rest }) => {
  const history = useHistory()
  const handleClick = () => history.push(to)

  return <ShortcutButton {...rest} onClick={handleClick} />
}

export default LinkButton
