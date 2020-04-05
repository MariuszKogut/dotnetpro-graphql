import React, { FunctionComponent } from 'react'
import CustomerList from '../../shared/components/customer-list'
import { Link } from 'react-router-dom'
import { usePageTracking } from '../../shared/services/use-page-tracking'
import { useTitle } from 'react-use'
import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'

const CustomerListPage: FunctionComponent = () => {
  useTitle('Kundenliste')
  usePageTracking()

  return (
    <Container>
      <Row className="py-3">
        <Col>
          <h1 className="pb-3">Kundenliste</h1>
          <hr />
          <Link to="/customer/new" className="btn btn-primary btn-lg">
            Kunde hinzufügen
          </Link>
          <hr />
        </Col>
      </Row>
      <Row>
        <CustomerList />
      </Row>
    </Container>
  )
}

export default CustomerListPage
