import ActionTypes from './../consts/ActionTypes';
import BaseApi from './../../api/BaseApi';

const Api = ({ dispatch }) => (next) => (action) => {
    if (action.type !== ActionTypes.Api) {
        return next(action);
    }

    const { url, success } = action.payload;

    BaseApi.
    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            dispatch(success(data));
        })
        .catch((error) => {
            console.error(error);
        });
};

export default Api;