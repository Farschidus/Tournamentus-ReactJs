import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import App from './components/App';
import store from './components/Data/store';

import './assets/css/normalize.css';
import './assets/css/style.css';

function registerServiceWorkers() {
    if ('serviceWorker' in navigator) {
        window.addEventListener('load', () => {
            navigator.serviceWorker.register('./sw.js').then((registration) => {
                console.log('SW registered: ', registration);
            }).catch((error) => {
                console.log('SW registration failed: ', error);
            });
        });
    }
}

render(
    (
        <BrowserRouter>
            <Provider store={store}>
                <App />
            </Provider>
        </BrowserRouter>
    ), document.getElementById('app'),
);
registerServiceWorkers();

