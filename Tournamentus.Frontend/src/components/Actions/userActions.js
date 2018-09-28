import * as Actions from './../Consts/ActionTypes';

export const setUserFullName = (payload) => ({
    type: Actions.SET_USER_FULLNAME,
    payload,
});

export function setTimezone(timezone) {
    return {
        type: Actions.USER_SET_TIMEZONE,
        payload: timezone, // Just for learning purposes didn't change it like updateName
    };
}

export const fetchUserInfo = () => ({
    type: Actions.API,
    payload: {
        url: 'api/getUser',
        success: ({ respond }) => [
            setUserFullName(respond.user.firstName + respond.user.lastName),
            setTimezone(respond.user.timezone),
        ],
    },
});
