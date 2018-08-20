import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Profile from '../Profile';
import Home from '../Home/CurrentGame';

const Body = () => (
    <main className="Body">
        <Switch>
            <Route path="/Profile" component={Profile} />
            <Route exact path="/" component={Home} />
        </Switch>
    </main>
);

export default Body;
