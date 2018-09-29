import * as Actions from './../Consts/ActionTypes';
const userState = {
    id: 1,
    firstName: 'Farshid',
    lastName: 'A. Ghavanini',
    fullName: 'Farshid A. Ghavanini',
    timezone: 'Set Your Timezone',
    picture: 'clientFiles/profilePics/farschidus.jpg',
    points: {
        perfect: 10,
        goalDiff: 7,
        correct: 5,
        wrong: 0,
    },
};

export default function reducer(state = userState, action) {
    switch (action.type) {
        case Actions.SET_USER_FULLNAME: {
            return { ...state, name: action.payload };
        }
        case Actions.USER_SET_TIMEZONE: {
            return { ...state, timezone: action.payload };
        }
        default: {
            return state;
        }
    }
}
