export function openModal() {
    return {
        type: 'MODAL_OPENED',
        payload: true,
    };
}

export function closeModal() {
    return {
        type: 'MODAL_CLOSED',
        payload: false,
    };
}
