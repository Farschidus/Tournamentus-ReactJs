import * as Actions from './../Consts/ActionTypes';

export function openModal() {
    return {
        type: Actions.MODAL_OPENED,
        payload: true,
    };
}

export function closeModal() {
    return {
        type: Actions.MODAL_CLOSED,
        payload: false,
    };
}
