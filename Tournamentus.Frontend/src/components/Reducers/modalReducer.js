
export default function reducer(state = { isActive: false }, action) {
    switch (action.type) {
        case 'MODAL_CLOSED': {
            return { ...state, isActive: action.payload };
        }
        case 'MODAL_OPENED': {
            return { ...state, isActive: action.payload };
        }
        default: {
            return state;
        }
    }
}
