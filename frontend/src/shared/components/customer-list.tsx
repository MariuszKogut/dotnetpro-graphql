import React, { FunctionComponent, useMemo } from 'react'
import { CustomerClient } from '../services/customer-client'
import CustomerCard from './customer-card'
import Col from 'react-bootstrap/Col'
import Alert from 'react-bootstrap/Alert'
import Spinner from 'react-bootstrap/Spinner'
import { useAsync } from 'react-use'

const CustomerList: FunctionComponent = () => {
  const customerClient = useMemo<CustomerClient>(
    () => new CustomerClient('https://localhost:5001'),
    [],
  )

  const { loading, error, value: data } = useAsync(
    async () => await customerClient.getAll(),
    [customerClient],
  )

  if (loading) {
    return (
      <Col>
        <Spinner animation="border" role="status">
          <span className="sr-only">Daten werden geladen...</span>
        </Spinner>
      </Col>
    )
  }

  if (error !== undefined) {
    return (
      <Col>
        <Alert variant="danger">Es ist ein Fehler aufgetreten: {error}</Alert>
      </Col>
    )
  }

  if (data && data.length === 0) {
    return (
      <Col>
        <Alert variant="info">Keine Daten vorhanden</Alert>
      </Col>
    )
  }

  if (data && data.length > 0) {
    return (
      <>
        {data &&
          data.map(x => (
            <Col key={x.id} md={3} className="py-3">
              <CustomerCard customer={x} />
            </Col>
          ))}
      </>
    )
  }

  return <></>
}

export default CustomerList
