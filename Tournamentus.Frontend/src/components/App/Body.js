import React from 'react';
import { Switch, Route } from 'react-router-dom';
import PrivateRoute from './PrivateRoute';
import { Login, PageNotFound, Registeration, ForgottenPassword } from './../NoAuthPages/index';
import Profile from '../Profile';
import Home from '../Home/CurrentGame';

const Body = () => (
    <main className="Body">
        <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/Profile" component={Profile} />
            <Route path="/login" component={Login} />
            <Route path="/Registeration" component={Registeration} />
            <Route path="/ForgottenPassword" component={ForgottenPassword} />
            <Route component={PageNotFound} />
        </Switch>
    </main>
);

export default Body;
