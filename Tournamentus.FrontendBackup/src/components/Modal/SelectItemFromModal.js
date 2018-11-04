import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import Modal from './../Modal';
import { openModal } from '../Actions/modalActions';

@connect((store) => ({ modal: store.modal }))
class SelectItemFromModal extends React.Component {
    constructor(props) {
        super(props);

        this.onOpenModal = this.onOpenModal.bind(this);
    }

    onOpenModal() {
        this.props.dispatch(openModal());
    }

    render() {
        return (
            <Fragment>
                {this.props.modal.isActive && <Modal items={this.props.modalItems} />}
                <div className={this.props.className} onClick={this.onOpenModal}>{this.props.selectText}</div>
            </Fragment>
        );
    }
}

SelectItemFromModal.propTypes = {
    className: PropTypes.string,
    selectText: PropTypes.string.isRequired,
    modalItems: PropTypes.array,
};

export default SelectItemFromModal;
