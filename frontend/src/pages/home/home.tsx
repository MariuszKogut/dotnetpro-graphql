import React, { FunctionComponent } from 'react'
import { Link } from 'react-router-dom'
import { usePageTracking } from '../../shared/services/use-page-tracking'
import { useTitle } from 'react-use'
import { Jumbotron } from 'react-bootstrap'

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
        <Link to="/customer/list" className="btn btn-primary btn-lg">
          Zur Kundenliste
        </Link>
      </p>
    </Jumbotron>
  )
}

export default HomePage
