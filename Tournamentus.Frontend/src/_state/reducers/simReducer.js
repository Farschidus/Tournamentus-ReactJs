import Actions from '../consts/simActionTypes';

const simInitState = {
    countryName: null,
    customerName: null,
    dcuId: null,
    iccid: null,
    status: null,
    friendlyName: null,
    isActive: false,
    activationDate: null
};

export default function simReducer(state = simInitState, action) {
    switch (action.type) {
        case Actions.SIM_CHECK_SUCCESS:
            return {
                ...state,
                ...action.result
            }
        case Actions.SIM_ACTIVATION:
            return {
                ...state,
                isActive: true
            }
        case Actions.SIM_CLEAR_REQUEST:
            return {
                ...simInitState,
            }
        default:
            return state;
    }
}