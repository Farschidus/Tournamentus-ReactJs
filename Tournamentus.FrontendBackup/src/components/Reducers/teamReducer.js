import * as Actions from './../Consts/ActionTypes';
const teamState = {
    teams: [],
};

export default function reducer(state = teamState, action) {
    switch (action.type) {
        case Actions.TEAMS_GETALL: {
            return { ...state, teams: action.payload };
        }
        default: {
            return state;
        }
    }
}
