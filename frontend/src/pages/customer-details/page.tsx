import React, { FunctionComponent } from 'react'
import { useParams } from 'react-router'
import CustomerDetails from '../../shared/components/customer-details'
import { usePageTracking } from '../../shared/services/use-page-tracking'
import { useTitle } from 'react-use'
import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'

const CustomerDetailsPage: FunctionComponent = () => {
  const { id } = useParams<{ id: string }>()
  useTitle(`Kundendetails ${id ? ' > ' + id : ''}`)
  usePageTracking()

  return (
    <Container>
      <Row className="py-3">
        <Col>
          <CustomerDetails id={id ? parseInt(id) : undefined} />
        </Col>
      </Row>
    </Container>
  )
}

export default CustomerDetailsPage
