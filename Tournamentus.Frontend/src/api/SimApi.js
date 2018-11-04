import BaseApi from './BaseApi';

class SimApi extends BaseApi {
    apiBase = 'sims';

    check(body) {
        return this._get(`${this.apiBase}/getstatus`, body);
    }
}

export default new SimApi();
