import React, { FunctionComponent } from 'react'
import { usePageTracking } from '../../shared/services/use-page-tracking'
import { useTitle } from 'react-use'
import { Jumbotron } from 'react-bootstrap'
import LinkButton from '../../shared/components/link-button'

const HomePage: FunctionComponent = () => {
  useTitle('Home')
  usePageTracking()

  return (
    <Jumbotron>
      <h1>Willkommen!</h1>
      <p className="lead">Schön, dass Sie customer-app aufgerufen haben.</p>
      <hr className="my-4" />
      <p>
        Verwalten Sie Ihre Kunden wie noch nie zuvor. Dank React im Frontend und
        .NET Core im Backend.
      </p>
      <p className="lead">
        <LinkButton to="/customer/list" variant="primary" size="lg">
          Zur Kundenliste
        </LinkButton>
      </p>
    </Jumbotron>
  )
}

export default HomePage
