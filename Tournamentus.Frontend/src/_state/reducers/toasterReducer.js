import Actions from '../consts/toasterActionTypes';

const toasterInitState = {
    messages: [],
    type: null,
    isActive: false,
};

export default function toasterReducer(state = toasterInitState, action) {
    switch (action.type) {
        case Actions.TOASTER_SHOW_SUCCESS_MESSAGE:
            return {
                messages: action.message,
                isActive: true,
                type: 'success',
            }
        case Actions.TOASTER_SHOW_WARNING_MESSAGE:
            return {
                messages: action.message,
                isActive: true,
                type: 'warning',
            }
        case Actions.TOASTER_SHOW_ERROR_MESSAGE:
            return {
                messages: action.error,
                isActive: true,
                type: 'error',
            }
        case Actions.TOASTER_HIDE_MESSAGE:
            return {
                ...toasterInitState
            }
        default:
            return state;
    }
}