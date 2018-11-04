import React from 'react';
import { connect } from 'react-redux';
import Dropdown from './../components/Dropdown';
import Button from './../components/Button';
import SimResult from './../components/SimResult';
import { check, clear } from './../_state/actions/simActions';
import { showSuccess, showWarning } from './../_state/actions/toasterActions';

class Home extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            countryName: null,
            customerName: null,
            dcuId: null,
            iccid: null,
        };

        this.handleKeyDown = this.handleKeyDown.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.getSimStatus = this.getSimStatus.bind(this);
        this.onSelectCountry = this.onSelectCountry.bind(this);
        this.activateSim = this.activateSim.bind(this);
    }

    onSelectCountry(value) {
        this.setState({ countryName: value });
    }

    handleKeyDown(e) {
        if((e.keyCode >= 8 && e.keyCode <= 9 ) || 
           (e.keyCode >= 48 && e.keyCode <= 57) || 
           (e.keyCode >= 96 && e.keyCode <= 105)) {
        } else {
            e.preventDefault();
        };
    }

    handleChange(e) {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    getSimStatus() {
        this.props.dispatch(clear());
        var warningMessage = [];
        if(!this.state.countryName) {
            warningMessage.push('Select Country!');
        }
        if(!this.state.customerName) {
            warningMessage.push('Customer name is empty!');
        }
        if(!this.state.dcuId) {
            warningMessage.push('DCU ID is empty!');
        }
        if(!this.state.iccid) {
            warningMessage.push('ICCID is empty!');
        }
        if(warningMessage.length > 0) {
            this.props.dispatch(showWarning(warningMessage));
        } else {
            this.props.dispatch(check(this.state));
        }
    }

    activateSim() {
        this.props.dispatch(showSuccess('Activated'));
    }

    render() {
        const divStyle = {
            width: '105px',
        };
        return (
            <div className="form-group">
                <Dropdown className="my-4" title="Select Country" onChange={this.onSelectCountry} />
                <input
                    name="customerName"
                    type="text"
                    className="form-control my-2"
                    id="txtCustomerName"
                    placeholder="Customer Name"
                    onChange={this.handleChange}
                />
                <input
                    name="dcuId"
                    type="text"
                    className="form-control my-2"
                    id="txtDcuId"
                    placeholder="DCU ID"
                    maxLength="4"
                    onChange={this.handleChange}
                    onKeyDown={this.handleKeyDown}
                />
                <input
                    name="iccid"
                    type="text"
                    className="form-control my-2"
                    id="txtICCID"
                    placeholder="ICCID"
                    maxLength="19"
                    onChange={this.handleChange}
                    onKeyDown={this.handleKeyDown}
                />
                <Button text="Check" iconClass="fa fa-check" onClick={this.getSimStatus} />
                {this.props.sim.iccid &&
                    <SimResult iccid={this.props.sim.iccid} status={this.props.sim.status} activationDate={this.props.sim.activationDate} />
                }
                {(this.props.sim.isActive === false && this.props.sim.iccid) &&
                    <div className="mx-auto"  style={divStyle}>
                        <Button text="Activate" iconClass="fa fa-check-square" className="mx-auto" onClick={this.activateSim} />
                    </div>
                }
            </div>
        );
    }
}

function mapStateToProps(state) {
    const sim = state.sim;
    return {
        sim
    };
}

export default connect(mapStateToProps)(Home);