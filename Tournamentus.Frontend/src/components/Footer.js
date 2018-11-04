import React from 'react';
import EssityLogo from './../assets/images/essity_logo.svg';
import EseyeLogo from './../assets/images/eseye_logo.svg';
import './../assets/styles/Footer.css';

function Footer() {
    return (
        localStorage.getItem('user') ?
        <footer className="Footer">
            <div className="container">
                <img className="Footer-essityLogo" src={EssityLogo} alt="essity-logo" />
                <span className="Footer-eseye">
                    Powered by<img className="Footer-eseyeLogo" src={EseyeLogo} alt="eseye-logo" />
                </span>
            </div>
        </footer>
        : ''
    );
}

export default Footer;
