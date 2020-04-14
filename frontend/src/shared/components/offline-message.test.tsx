import React from 'react'
import { render } from '@testing-library/react'
import OfflineMessage from './offline-message'

describe('OfflineMessage', () => {
  it('renders without errors', () => {
    const { container } = render(<OfflineMessage />)
    expect(container).toMatchSnapshot()
  })
})
