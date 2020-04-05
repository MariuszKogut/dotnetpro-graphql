import React, { FunctionComponent } from 'react'
import { ButtonProps } from 'react-bootstrap'
import Button from 'react-bootstrap/Button'
import { useHistory } from 'react-router-dom'

interface Props extends ButtonProps {
  to: string
}

const LinkButton: FunctionComponent<Props> = ({ to, ...rest }) => {
  const history = useHistory()
  const handleClick = () => history.push(to)

  return <Button {...rest} onClick={handleClick} />
}

export default LinkButton
