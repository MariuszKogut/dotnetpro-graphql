import React, { FunctionComponent, useEffect, useMemo, useState } from 'react'
import { CustomerClient, ICustomerModel } from '../services/customer-client'
import { LoadingState } from './loading-state'
import CustomerCard from './customer-card'
import Col from 'react-bootstrap/Col'
import Alert from 'react-bootstrap/Alert'
import Spinner from 'react-bootstrap/Spinner'

const CustomerList: FunctionComponent = () => {
  const [loadingState, setLoadingState] = useState<LoadingState>(
    LoadingState.Loading,
  )
  const [data, setData] = useState<ICustomerModel[]>()
  const [error, setError] = useState<string>()

  const customerClient = useMemo<CustomerClient>(
    () => new CustomerClient('https://localhost:5001'),
    [],
  )

  useEffect(() => {
    const loadCustomer = async () => {
      setLoadingState(LoadingState.Loading)
      try {
        const result = await customerClient.getAll()
        setData(result)
        setLoadingState(
          result.length > 0 ? LoadingState.HasData : LoadingState.NoData,
        )
      } catch (e) {
        setError(e.message)
        setLoadingState(LoadingState.Error)
      }
    }

    loadCustomer()
  }, [customerClient])

  switch (loadingState) {
    case LoadingState.Loading:
      return (
        <Col>
          <Spinner animation="border" role="status">
            <span className="sr-only">Daten werden geladen...</span>
          </Spinner>
        </Col>
      )

    case LoadingState.Error:
      return (
        <Col>
          <Alert variant="danger">Es ist ein Fehler aufgetreten: {error}</Alert>
        </Col>
      )

    case LoadingState.NoData:
      return (
        <Col>
          <Alert variant="info">Keine Daten vorhanden</Alert>
        </Col>
      )

    case LoadingState.HasData:
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
}

export default CustomerList
