import React from 'react';
import PropTypes from 'prop-types';

function SimResult(props) {
    if (!props.iccid) {
        return;
    }

    return (
        <table className="table table-dark my-5">
            <tbody>
                <tr>
                    <th scope="row">ICCID</th>
                    <td>{props.iccid}</td>
                </tr>
                <tr>
                    <th scope="row">Status</th>
                    <td>{props.status}</td>
                </tr>
                {props.activationDate &&
                    <tr>
                        <th scope="row">Activation Date</th>
                        <td>{props.activationDate}</td>
                    </tr>
                }
            </tbody>
        </table>
    );
}

SimResult.propTypes = {
    iccid: PropTypes.string,
    status: PropTypes.string,
    activationDate: PropTypes.string,
};


export default SimResult;