// shim mutationobserver ==> https://github.com/testing-library/dom-testing-library/releases/tag/v7.0.0
import MutationObserver from '@sheerun/mutationobserver-shim'
window.MutationObserver = MutationObserver
