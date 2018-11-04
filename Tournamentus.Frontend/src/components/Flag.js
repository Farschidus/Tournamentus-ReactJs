import React from 'react';
import PropTypes from 'prop-types';
import 'flag-icon-css/css/flag-icon.css';

const Flag = (props) => (
    <span className={`flag-icon flag-icon-${props.countryIsoCode} Flag-${props.size}Icon`} />
);

Flag.propTypes = {
    countryIsoCode: PropTypes.string.isRequired,
    size: PropTypes.oneOf(['small', 'medium', 'big']).isRequired,
};

export default Flag;
