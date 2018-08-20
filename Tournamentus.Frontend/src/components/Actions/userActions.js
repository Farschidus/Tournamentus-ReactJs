export function updateName(name) {
    return {
        type: 'USER_UPDATE_NAME',
        payload: name,
    };
}

export function setTimezone(timezone) {
    return {
        type: 'USER_SET_TIMEZONE',
        payload: timezone,
    };
}
