import React, { FunctionComponent, useMemo } from 'react'
import { CustomerClient, ICustomerModel } from '../services/customer-client'
import CustomerCard from './customer-card'
import Col from 'react-bootstrap/Col'
import Alert from 'react-bootstrap/Alert'
import Spinner from 'react-bootstrap/Spinner'
import { useAsync, useLocalStorage, useNetwork } from 'react-use'
import OfflineMessage from './offline-message'

const CustomerList: FunctionComponent = () => {
  const { online } = useNetwork()
  const [offlineData, setOfflineData] = useLocalStorage<ICustomerModel[]>(
    'customer-list',
    [],
  )

  const customerClient = useMemo<CustomerClient>(
    () => new CustomerClient('https://localhost:5001'),
    [],
  )

  const { loading, error, value: data } = useAsync<
    ICustomerModel[] | undefined
  >(async () => {
    if (online === undefined || online) {
      try {
        const data = await customerClient.getAll()
        setOfflineData(data)
        return data
      } catch (e) {
        return offlineData
      }
    } else {
      return offlineData
    }
  }, [customerClient])

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
        <Alert variant="danger">
          Es ist ein Fehler aufgetreten: {JSON.stringify(error, null, 2)}
        </Alert>
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
        {online === false && (
          <Col xs={12}>
            <OfflineMessage />
          </Col>
        )}

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
