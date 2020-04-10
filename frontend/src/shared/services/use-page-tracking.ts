import { useApplicationInsightsContext } from './analytics'

export const usePageTracking = () => {
  const { instance } = useApplicationInsightsContext()
  if (instance) {
    instance.trackPageView()
  }
}
