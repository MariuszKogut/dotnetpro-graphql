import React, { FunctionComponent } from 'react'
import Alert from 'react-bootstrap/Alert'

const OfflineMessage: FunctionComponent = () => (
  <Alert variant="warning">
    Sie sind gerade offline. Es wird eine lokale Kopie der Daten gezeigt. Diese
    kann von den aktuellen Daten abweichen.
  </Alert>
)

export default OfflineMessage
