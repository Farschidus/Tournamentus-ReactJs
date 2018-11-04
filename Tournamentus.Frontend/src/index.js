import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import App from './components/App';
import store from './_state/store';
import * as serviceWorker from './serviceWorker';
import './assets/styles/index.css';

render(
    (
        <BrowserRouter>
            <Provider store={store}>
                <App />
            </Provider>
        </BrowserRouter>
    ), document.getElementById('root'));
serviceWorker.unregister();
