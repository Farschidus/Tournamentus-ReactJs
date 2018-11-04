import * as Actions from './../Consts/ActionTypes';
const modalState = { isActive: false };

export default function reducer(state = modalState, action) {
    switch (action.type) {
        case Actions.MODAL_CLOSED: {
            return { ...state, isActive: action.payload };
        }
        case Actions.MODAL_OPENED: {
            return { ...state, isActive: action.payload };
        }
        default: {
            return state;
        }
    }
}
