import userActions from './../consts/userActionTypes';

const unauthenticatedState = {
    isLoggedIn: false,
    user: {}
};

const initialState = { ...unauthenticatedState }

let user = JSON.parse(localStorage.getItem('user'));
if (user) {
    initialState.isLoggedIn = true;
    initialState.user = user;
}

export default function reducer(state = initialState, action) {
    switch (action.type) {
        case userActions.USERS_LOGIN_SUCCESS:
            return {
                ...state,
                isLoggedIn: true,
                user: action.user
            }
        case userActions.USERS_LOGIN_FAILURE:
            return { ...unauthenticatedState }
        case userActions.USERS_LOGOUT_SUCCESS:
            return { ...unauthenticatedState }
        default:
            return state;
    }
}