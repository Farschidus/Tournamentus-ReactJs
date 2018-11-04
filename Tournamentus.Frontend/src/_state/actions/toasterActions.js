import toasterActions from './../consts/toasterActionTypes';

export function showSuccess(message) {
    return dispatch => {
        dispatch({ type: toasterActions.TOASTER_SHOW_SUCCESS_MESSAGE, message });
    };
}

export function showWarning(message) {
    return dispatch => {
        dispatch({ type: toasterActions.TOASTER_SHOW_WARNING_MESSAGE, message });
    };
}

export function hideMessage() {
    return dispatch => {
        dispatch({ type: toasterActions.TOASTER_HIDE_MESSAGE });
    };
}