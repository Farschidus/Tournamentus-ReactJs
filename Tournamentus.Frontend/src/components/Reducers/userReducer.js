const userState = {
    name: 'Farshid A. Ghavanini',
    timezone: 'Set Your Timezone',
};

export default function reducer(state = userState, action) {
    switch (action.type) {
        case 'USER_UPDATE_NAME': {
            return { ...state, name: action.payload };
        }
        case 'USER_SET_TIMEZONE': {
            return { ...state, timezone: action.payload };
        }
        default: {
            return state;
        }
    }
}
