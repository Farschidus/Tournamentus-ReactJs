import { applyMiddleware, createStore } from 'redux';
import promise from 'redux-promise-middleware';
import reducers from '../Reducers';

const middleware = applyMiddleware(promise());

export default createStore(reducers, middleware);
