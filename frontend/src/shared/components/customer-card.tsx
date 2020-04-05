import React, { FunctionComponent } from 'react'
import { ICustomerModel } from '../services/customer-client'
import LinkButton from './link-button'
import Card from 'react-bootstrap/Card'
import ListGroup from 'react-bootstrap/ListGroup'

interface Props {
  customer: ICustomerModel
}

const CustomerCard: FunctionComponent<Props> = props => {
  const {
    customer: { name, id, location },
  } = props

  return (
    <Card className="card">
      <Card.Header className="font-weight-bold">{name}</Card.Header>
      <ListGroup variant="flush">
        <ListGroup.Item>
          <span className="text-muted">#</span> {id}
        </ListGroup.Item>
        <ListGroup.Item>
          <span className="text-muted">Location</span> {location}
        </ListGroup.Item>
      </ListGroup>
      <Card.Body className="d-flex">
        <LinkButton to={`/customer/editor/${id}`} variant="secondary">
          Öffnen
        </LinkButton>
      </Card.Body>
    </Card>
  )
}

export default CustomerCard
