import React, { FunctionComponent } from 'react'
import CustomerList from '../../shared/components/customer-list'
import { usePageTracking } from '../../shared/services/use-page-tracking'
import { useNetwork, useTitle } from 'react-use'
import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import LinkButton from '../../shared/components/link-button'

const CustomerListPage: FunctionComponent = () => {
  useTitle('Kundenliste')
  usePageTracking()
  const { online } = useNetwork()

  return (
    <Container>
      <Row className="py-3">
        <Col>
          <h1 className="pb-3">Kundenliste</h1>
          <hr />
          <LinkButton
            to="/customer/new"
            variant="primary"
            size="lg"
            disabled={online === false}
            keyboardShortcut="n"
          >
            Kunde hinzufügen
          </LinkButton>
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
