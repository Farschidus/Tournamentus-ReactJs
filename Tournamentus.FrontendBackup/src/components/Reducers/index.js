import { combineReducers } from 'redux';
import modal from './modalReducer';
import user from './userReducer';
import team from './teamReducer';

export default combineReducers({
    modal,
    user,
    team,
});
