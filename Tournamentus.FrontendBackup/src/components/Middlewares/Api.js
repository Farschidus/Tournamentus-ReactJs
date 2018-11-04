import * as Actions from './../Consts/ActionTypes';

const Api = ({ dispatch }) => (next) => (action) => {
    if (action.type !== Actions.API) {
        return next(action);
    }

    const { url, success } = action.payload;

    fetch(url)
        .then((response) => response.json())
        .then((data) => {
            dispatch(success(data));
        })
        .catch((error) => {
            console.error(error);
        });
};

export default Api;
