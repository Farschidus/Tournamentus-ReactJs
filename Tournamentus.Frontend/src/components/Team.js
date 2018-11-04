import React from 'react';
import PropTypes from 'prop-types';
import Flag from './../Flag/Flag';
import { connect } from 'react-redux';
import { closeModal } from '../Actions/modalActions';

@connect((store) => ({ modal: store.modal }))
class Team extends React.Component {
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
            isoCode: e.target.getAttribute('isocode'),
        };
        this.props.onSelect(selectedItem);
        this.props.dispatch(closeModal());
    }

    render() {
        return (
            <div className="Modal-item" onClick={this.onSelect} isocode={this.props.isoCode}>
                <Flag size="small" countryIsoCode={this.props.isoCode} />{this.props.name}
            </div>
        );
    }
}

Team.propTypes = {
    name: PropTypes.string.isRequired,
    isoCode: PropTypes.string.isRequired,
    onSelect: PropTypes.func.isRequired,
};

export default Team;
