import { addition } from './math'

describe('math', () => {
  it('should return 2 for 1+1', () => {
    const result = addition(1, 1)
    expect(result).toBe(2)
  })
})
