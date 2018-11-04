import React from 'react';
import PropTypes from 'prop-types';
import DropdownItem from './DropdownItem';

class Dropdown extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            dropdownItems: [
                { title: 'Austria' },
                { title: 'Belgium' },
                { title: 'Denmark' },
                { title: 'Finland' },
                { title: 'France' },
                { title: 'Germany' },
                { title: 'Ireland' },
                { title: 'Italy' },
                { title: 'Netherlands' },
                { title: 'Norway' },
                { title: 'Poland' },
                { title: 'Portugal' },
                { title: 'Spain' },
                { title: 'Sweden' },
                { title: 'Switzerland' },
                { title: 'UK' },
            ],
            mainTitle: this.props.title,
        };

        this.onChange = this.onChange.bind(this);
    }

    onChange(selectedItem) {
        this.setState({
            mainTitle: selectedItem,
        });
        this.props.onChange(selectedItem);
    }

    render() {
        const items = this.state.dropdownItems.map((item, i) =>
            <DropdownItem key={i} text={item.title} value={item.title} onSelect={this.onChange} />);

        const dropdownClass = this.props.className ? `dropdown w-100 ${this.props.className}` : 'dropdown w-100';

        return (
            <div className={dropdownClass}>
                <button
                    className="btn btn-secondary dropdown-toggle w-100"
                    type="button"
                    id="dropdownMenuButton"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                >
                    {this.state.mainTitle}
                </button>
                <div className="dropdown-menu w-100" aria-labelledby="dropdownMenuButton">
                    {items}
                </div>
            </div>
        );
    }
}

Dropdown.propTypes = {
    title: PropTypes.string.isRequired,
    className: PropTypes.string,
    onChange: PropTypes.func
};

export default Dropdown;