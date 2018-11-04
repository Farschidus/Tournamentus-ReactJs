import React from 'react';
import PropTypes from 'prop-types';

class Button extends React.Component {
    constructor(props) {
        super(props);
        this.size = '';
        switch (props.size) {
            case 'large':
                this.size = 'lg';
                break;
            case 'small':
                this.size = 'sm';
                break;
            default:
                this.size = '';
        }

        this.target = '';
        switch (props.target) {
            case 'same':
                this.target = '_self';
                break;
            case 'new':
                this.target = '_blank';
                break;
            default:
                this.target = '_self';
        }
    }

    render() {
        let buttonClass = (this.props.size !== 'normal')
            ? `btn btn-${this.props.type} btn-${this.size}`
            : `btn btn-${this.props.type}`;

        buttonClass = (this.props.text)
            ? buttonClass
            : `${buttonClass} btn-noText`;

        if (this.props.isHyperlink) {
            return <a href={this.props.link} className={buttonClass} target={this.target} >{this.props.text}</a>;
        }

        const icon = (this.props.iconClass)
            ? <i className={this.props.iconClass} />
            : '';
        return (
            <button type="Button" className={buttonClass} onClick={this.props.onClick}>{icon} {this.props.text}</button>
        );
    }
}

Button.propTypes = {
    text: PropTypes.string,
    link: PropTypes.string,
    target: PropTypes.oneOf(['new', 'same']),
    size: PropTypes.oneOf(['large', 'normal', 'small']),
    type: PropTypes.oneOf(['primary', 'secondary', 'success', 'danger', 'warning', 'info']),
    isHyperlink: PropTypes.bool,
    iconClass: PropTypes.string,
    onClick: PropTypes.func,
};

Button.defaultProps = {
    target: 'same',
    size: 'normal',
    type: 'primary',
    isHyperlink: false,
};

export default Button;