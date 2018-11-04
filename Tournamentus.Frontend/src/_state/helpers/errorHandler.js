import Actions from '../consts/toasterActionTypes';

export default function ErrorHandler(error) {
    var errorMessages = error.errors.map((error) => {
        return `${error.propertyName}: ${error.errorMessage}`;
    });
    return {
        type: Actions.TOASTER_SHOW_ERROR_MESSAGE, 
        error: errorMessages
    }
}