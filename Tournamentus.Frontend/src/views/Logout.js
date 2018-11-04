import React from 'react';
import { Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import { logout } from './../_state/actions/userActions';
import './../assets/styles/Login.css';

class Logout extends React.Component {
    componentWillMount() {
        this.props.dispatch(logout());
    }
    
    render() {
        return <Redirect exact to="/login" />;
    }
}

function mapStateToProps(state) {
    const auth = state.user;
    return {
        auth
    };
}

export default connect(mapStateToProps)(Logout);