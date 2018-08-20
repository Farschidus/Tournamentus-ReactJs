import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import * as modalActions from '../Actions/modalActions';

@connect((store) => ({ modal: store.modal }))
class Modal extends React.Component {
    constructor(props) {
        super(props);

        this.closeModal = this.closeModal.bind(this);
    }

    closeModal() {
        this.props.dispatch(modalActions.closeModal());
    }

    render() {
        return (
            <div className="Modal">
                <span onClick={this.closeModal} className="fa fa-close ModalPopup-closeIcon" />
                <br />
                {this.props.items}
            </div>
        );
    }
}

Modal.propTypes = {
    items: PropTypes.array.isRequired,
};

export default Modal;
