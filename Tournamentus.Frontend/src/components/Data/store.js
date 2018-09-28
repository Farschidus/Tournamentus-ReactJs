import { applyMiddleware, createStore, compose } from 'redux';
import promise from 'redux-promise-middleware';
import reducers from '../Reducers';
import Api from './../Middlewares/Api';

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const middleware = composeEnhancers(applyMiddleware(
    promise(),
    Api,
));

const store = createStore(reducers, middleware);

window.store = store;

export default store;
