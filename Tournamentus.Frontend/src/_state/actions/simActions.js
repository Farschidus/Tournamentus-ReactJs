import simActions from './../consts/simActionTypes';
import errorHandler from '../helpers/errorHandler';
import SimApi from './../../api/SimApi';

export function check(data) {
    return dispatch => {
        SimApi.check(data)
            .then(
                result => {
                    dispatch(successCheck(result));
                },
                error => {
                    dispatch(errorHandler(error));
                }
            );
    };

    function successCheck(result) { return { type: simActions.SIM_CHECK_SUCCESS, result } }
}

export function clear() {
    return dispatch => {
        return { type: simActions.SIM_CLEAR_REQUEST }
    };
}

export function activation(data) {
    return dispatch => {
        SimApi.activation(data)
            .then(
                result => {
                    dispatch(successActivation(result));
                },
                error => {
                    dispatch(errorHandler(error));
                }
            );
    };

    function successActivation(result) { return { type: simActions.SIM_ACTIVATION_SUCCESS, result } }
}