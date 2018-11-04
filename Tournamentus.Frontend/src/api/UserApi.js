import BaseApi from './BaseApi';

class UserApi extends BaseApi {
    apiBase = 'users';

    authenticate(email, password) {
        const body = JSON.stringify({ email, password });
        return this._post(`${this.apiBase}/authenticate`, body);
    }
}

export default new UserApi();
