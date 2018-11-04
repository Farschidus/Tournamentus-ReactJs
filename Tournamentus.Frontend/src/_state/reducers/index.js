import { combineReducers } from 'redux';
import user from './userReducer';
import sim from './simReducer';
import toaster from './toasterReducer';
import userActions from './../consts/userActionTypes'

const appReducers = combineReducers({
    user,
    sim,
    toaster,
});

const rootReducer = (state, action) => {
    if (action.type === userActions.USERS_LOGOUT_SUCCESS) {
        state = undefined;
    }
  
    return appReducers(state, action);
  }

export default rootReducer;
