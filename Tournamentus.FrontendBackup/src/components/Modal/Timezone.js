import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { closeModal } from '../Actions/modalActions';

@connect((store) => ({ modal: store.modal }))
class Timezone extends React.Component {
    constructor(props) {
        super(props);
        this.onSelect = this.onSelect.bind(this);
    }

    onSelect(e) {
        if (e.target.tagName !== 'DIV') {
            return;
        }
        const selectedItem = {
            name: e.target.textContent,
            offset: e.target.getAttribute('offset'),
        };
        this.props.onSelect(selectedItem);
        this.props.dispatch(closeModal());
    }

    render() {
        return (
            <div className="Modal-item" onClick={this.onSelect} offset={this.props.offset}>
                {this.props.name}
            </div>
        );
    }
}

Timezone.propTypes = {
    name: PropTypes.string.isRequired,
    offset: PropTypes.number.isRequired,
    onSelect: PropTypes.func.isRequired,
};

export default Timezone;
