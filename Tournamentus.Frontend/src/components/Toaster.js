import React from 'react';
import { connect } from 'react-redux';
import { hideMessage } from './../_state/actions/toasterActions';
import './../assets/styles/Toaster.css'


class Toaster extends React.Component {
    constructor(props) {
        super(props);
        this.closeToaster = this.closeToaster.bind(this);
    }

    closeToaster() {
        this.props.dispatch(hideMessage());
    }

    getMessages(messages) {
        return (
            <ol>
            {
                messages.map((msg, i) => {
                    return (<li key={i}>{msg}</li>)
                })
            }
            </ol>
        );
    }

    getMessage(messages) {
        return (<div className="mx-auto" style={{ width: '80px', fontSize: '26px' }}>{this.props.toaster.messages}</div>);
    }

    render() {
        const divStyle = {
            width: '20px',
            fontSize: '26px',
        };
        var faIcon, message, animation;
        switch (this.props.toaster.type) {
            case 'success':
                faIcon = 'fa fa-check-circle'
                message = this.getMessage(this.props.toaster.messages);
                animation = "bounceIn"
                break;
            case 'warning':
                faIcon = 'fa fa-exclamation-circle';
                message = this.getMessages(this.props.toaster.messages);
                animation = "wobble"
                break;
            case 'error':
                faIcon = 'fa fa-times-circle';
                message = this.getMessages(this.props.toaster.messages);
                animation = "shake"
                break;
            default:
                break;
        }

        var toasterClassName = `Toaster-popup Toaster-${this.props.toaster.type} animated ${animation}`;
        var icon = (<i className={faIcon} />);
        return (
            this.props.toaster.isActive && (
            <div className="Toaster" tabIndex="-1">
                <div className={toasterClassName}>
                    <div className="mx-auto" style={divStyle}>{icon}</div>
                    <div className="Toaster-message">{message}</div>
                    <button type="button" className="Toaster-ok" onClick={this.closeToaster}>Dismiss</button>
                </div>
                <div className="Toaster-shadow"></div>
            </div>)
        );
    }
}

function mapStateToProps(state) {
    const toaster = state.toaster;
    return {
        toaster
    };
}

export default connect(mapStateToProps)(Toaster);