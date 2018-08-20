import React from 'react';
import Menu from './Menu';
import Body from './Body';
import ScrollToTop from './ScrollToTop';
// import AuthBody from './../Authentication/AuthBody';

function App() {
    // const content = props.store.isAuthenticated === true
    //     ? <ScrollToTop><Body /><Menu /></ScrollToTop>
    //     : <AuthBody />;

    return (
        <div className="full-height">
            <ScrollToTop><Body /><Menu /></ScrollToTop>
        </div>
    );
}

export default App;
