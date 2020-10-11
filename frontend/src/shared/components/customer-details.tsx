import React, { FunctionComponent, useMemo, useState } from 'react'
import classNames from 'classnames'
import { useHistory } from 'react-router-dom'
import {
  CustomerClient,
  CustomerModel,
  ICustomerModel,
  ValidationProblemDetails,
} from '../services/customer-client'
import ProblemDetails, { hasErrors } from './problem-details'
import Alert from 'react-bootstrap/Alert'
import { useAsync, useAsyncFn, useLocalStorage, useNetwork } from 'react-use'
import Spinner from 'react-bootstrap/Spinner'
import OfflineMessage from './offline-message'
import ShortcutButton from './shortcut-button'

interface Props {
  id?: number
}

const CustomerDetails: FunctionComponent<Props> = (props) => {
  const { id } = props
  const isInsertMode = id === undefined

  const history = useHistory()
  const { online } = useNetwork()
  const [offlineData] = useLocalStorage<ICustomerModel[]>('customer-list', [])
  const [customer, setCustomer] = useState<CustomerModel>(() => {
    const customer = new CustomerModel()
    customer.id = isInsertMode ? undefined : id
    customer.name = ''
    customer.location = ''
    return customer
  })
  const { name, location } = customer

  const [problemDetails, setProblemDetails] = useState<
    ValidationProblemDetails
  >()

  const customerClient = useMemo<CustomerClient>(
    () => new CustomerClient('https://localhost:5001'),
    [],
  )

  const { loading: loadingData, error: errorData } = useAsync(async () => {
    const tryToSetCustomerFromLocalstorage = () => {
      const customerFromStorage = offlineData?.find((x) => x.id === id)
      if (customerFromStorage) {
        const customer = new CustomerModel()
        customer.init(customerFromStorage)
        setCustomer(customer)
      }
    }

    if (id) {
      if (online === undefined || online) {
        try {
          const result = await customerClient.get(id)
          setCustomer(result)
          return result
        } catch (e) {
          tryToSetCustomerFromLocalstorage()
        }
      } else {
        tryToSetCustomerFromLocalstorage()
      }
    }
  }, [id, customerClient])

  const goToList = () => history.push('/customer/list')

  const handleBackClick = () => history.goBack()

  const [
    { loading: loadingSave, error: errorSave },
    saveCustomer,
  ] = useAsyncFn(async () => {
    try {
      if (isInsertMode) {
        await customerClient.insert(customer)
      } else {
        await customerClient.update(customer)
      }
      goToList()
    } catch (e) {
      if (e instanceof ValidationProblemDetails) {
        setProblemDetails(e)
      }
    }
  }, [customer])

  const [
    { loading: loadingDelete, error: errorDelete },
    deleteCustomer,
  ] = useAsyncFn(async () => {
    if (id && window.confirm(`Möchten Sie '${name}' wirklich löschen?`)) {
      await customerClient.delete(id)
      goToList()
    }
  })

  const handleSaveClick = async () => await saveCustomer()
  const handleDeleteClick = async () => await deleteCustomer()

  const handleTextFieldChange = (
    fieldName: keyof ICustomerModel,
    value: string,
  ) => {
    const changedCustomer = new CustomerModel()
    changedCustomer.init({ ...customer, [fieldName]: value })
    setCustomer(changedCustomer)
  }

  const error = () => errorData || errorSave || errorDelete
  const loading = () => loadingData || loadingSave || loadingDelete

  if (loadingData) {
    return (
      <Alert variant="info">
        <Spinner animation="border" role="status">
          <span className="sr-only">Kunde wird geladen...</span>
        </Spinner>
      </Alert>
    )
  }

  return (
    <>
      <h1 className="pb-3">
        Kunde {name} {isInsertMode ? 'hinzufügen' : 'bearbeiten'}
      </h1>

      <hr />

      {online === false && <OfflineMessage />}

      <ShortcutButton
        variant="primary"
        size="lg"
        className="mr-3"
        disabled={loading() || online === false}
        keyboardShortcut="s"
        onClick={handleSaveClick}
      >
        {loadingSave && <Spinner animation="grow" />}
        Speichern
      </ShortcutButton>
      {!isInsertMode && (
        <ShortcutButton
          variant="danger"
          size="lg"
          className="mr-3"
          disabled={loading() || online === false}
          keyboardShortcut="d"
          onClick={handleDeleteClick}
        >
          Löschen
        </ShortcutButton>
      )}
      <ShortcutButton
        variant="secondary"
        size="lg"
        keyboardShortcut="b"
        onClick={handleBackClick}
      >
        Zurück
      </ShortcutButton>
      <hr />

      {error() && (
        <Alert variant="danger">
          Es ist ein Fehler aufgetreten:{' '}
          <pre>{JSON.stringify(error(), null, 2) ?? ''}</pre>
        </Alert>
      )}

      <form>
        <div className="form-group">
          <label htmlFor="Name">Name</label>
          <input
            type="text"
            className={classNames('form-control', {
              'is-invalid': hasErrors('Name', problemDetails).length > 0,
            })}
            id="Name"
            aria-describedby="NameHelp"
            value={name}
            readOnly={online === false}
            onChange={(e) =>
              handleTextFieldChange('name', e.currentTarget.value)
            }
          />
          <small id="NameHelp" className="form-text text-muted">
            Name des Unternehmens, z. B. Microsoft
          </small>
          <ProblemDetails fieldName="Name" problemDetails={problemDetails} />
        </div>
        <div className="form-group">
          <label htmlFor="Location">Location</label>
          <input
            type="text"
            className={classNames('form-control', {
              'is-invalid': hasErrors('Location', problemDetails).length > 0,
            })}
            id="Location"
            aria-describedby="LocationHelp"
            value={location}
            readOnly={online === false}
            onChange={(e) =>
              handleTextFieldChange('location', e.currentTarget.value)
            }
          />
          <small id="LocationHelp" className="form-text text-muted">
            Sitz des Unternehmens, z. B. USA
          </small>
          <ProblemDetails
            fieldName="Location"
            problemDetails={problemDetails}
          />
        </div>
      </form>
    </>
  )
}

export default CustomerDetails
