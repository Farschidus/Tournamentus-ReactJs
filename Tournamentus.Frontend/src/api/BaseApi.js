import config from './../config';
import queryString from 'query-string';

export default class BaseApi {
    baseUrl;

    constructor() {
        this.baseUrl = config.apiUrl;
    }

    async _get(endpoint, params = {}) {
        const result = await this._request({
            endpoint,
            method: 'GET',
            params,
        });
        return result;
    }

    async _put(endpoint, body, params = {}) {
        const result = await this._request({
            endpoint,
            method: 'PUT',
            params,
            body,
        });
        return result;
    }

    async _post(endpoint, body, params = {}) {
        const result = await this._request({
            endpoint,
            method: 'POST',
            params,
            body,
        });
        return result;
    }

    async _delete(endpoint, body, params = {}) {
        const result = await this._request({
            endpoint,
            method: 'DELETE',
            body,
            params,
        });
        return result;
    }

    _request({
        endpoint,
        method,
        params = {},
        body = {},
    }) {
        const stringifiedParams = Object.keys(params).length !== 0 &&
                params.constructor === Object
            ? `?${queryString.stringify(params)}`
            : '';
        const url = `${this.baseUrl}${endpoint}${stringifiedParams}`;

        const headers = new Headers();
        const options = {
            method,
            headers,
        };

        let user = JSON.parse(localStorage.getItem('user'));
        if (user && user.token) {
            headers.append('Authorization', `Bearer ${user.token}`);
        }

        headers.append('Access-Control-Allow-Origin', config.apiUrl);
        headers.append('Access-Control-Allow-Credentials', 'true');
        headers.append('Content-Type', 'application/json');
        if (method === 'POST') {
            options.body = body;
        } else {
            if (['get', 'head'].indexOf(method.toLowerCase()) === -1) {
                options.body = JSON.stringify(body);
            }
        }

        return fetch(url, options)
            .then(this.handleResponse, this.handleError)
            .then((result) => {
                return result;
            });
    }

    handleResponse(response) {
        return new Promise((resolve, reject) => {
            if (response.status >= 400) {
                if (response.status === 401) {
                    window.location.href = "/logout";
                    return resolve();
                } else {
                    return response.json().then(json => reject(json));
                }
            }
            
            if (response.status < 300 && response.status >= 200) {
                return response.json().then(json => resolve(json));
            }

            var contentType = response.headers.get("content-type");
            if (!contentType) {  
                // return error message from response body
                return response.text().then(text => reject(text));
            }

            return reject(response);
        });
    }

    handleError(error) {
        return Promise.reject(error && error.message);
    }
}
