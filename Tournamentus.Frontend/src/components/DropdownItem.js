import React from 'react';
import PropTypes from 'prop-types';

class DropdownItem extends React.Component {
    constructor(props) {
        super(props);
        
        this.onSelect = this.onSelect.bind(this);
    }

    onSelect() {
        this.props.onSelect(this.props.text);
    }

    render() {
        return (
            <button className="dropdown-item" type="button" data-value={this.props.value} onClick={this.onSelect}>
                {this.props.text}
            </button>
        );
    }
}

DropdownItem.propTypes = {
    text: PropTypes.string.isRequired,
    value: PropTypes.string.isRequired,
    onSelect: PropTypes.func.isRequired,
};

export default DropdownItem;