import userActions from './../consts/userActionTypes';
import UserApi from './../../api/UserApi';

export function login(email, password) {
    return dispatch => {
        UserApi.authenticate(email, password)
            .then(
                user => {
                    localStorage.setItem('user', JSON.stringify(user));
                    dispatch(success(user));
                },
                error => {
                    dispatch(failure(error));
                }
            );
    };
}

function success(user) { return { type: userActions.USERS_LOGIN_SUCCESS, user } }
function failure(error) { return { type: userActions.USERS_LOGIN_FAILURE, error } }

export function logout() {
    localStorage.removeItem('user');
    return { type: userActions.USERS_LOGOUT_SUCCESS };
}

