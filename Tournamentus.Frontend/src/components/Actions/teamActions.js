import * as Actions from './../Consts/ActionTypes';
import TeamApi from './../Api/TeamApi';

export const setTeams = (payload) => ({
    type: Actions.TEAMS_GETALL,
    payload,
});

export function fetchAllTeams() {
    return (dispatch) => {
        TeamApi.get().then((json) => dispatch(setTeams(json.teams)));
    };
}

