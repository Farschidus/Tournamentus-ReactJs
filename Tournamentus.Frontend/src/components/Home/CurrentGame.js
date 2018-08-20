import React from 'react';
import Card from './../Card/Card';

class CurrentGame extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            groups: ['A', 'B', 'C', 'D'],
        };
    }

    render() {
        const title = `Group ${this.state.groups[0]}`;

        return (
            <div className="CardContainer">
                <Card title={title} />
            </div>
        );
    }
}

export default CurrentGame;
