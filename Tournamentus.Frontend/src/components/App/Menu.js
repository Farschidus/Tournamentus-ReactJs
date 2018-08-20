import React from 'react';
import { NavLink } from 'react-router-dom';

class Menu extends React.Component {
    constructor(props) {
        super(props);
        this.onItemClick = this.onItemClick.bind(this);
    }

    onItemClick() {

    }

    render() {
        return (
            <nav className="Menu">
                <NavLink activeClassName="Menu-link--active" to="/profile"><span className="Menu-link fa fa-user" /></NavLink>
                <NavLink activeClassName="Menu-link--active" to="/statisticts"><span className="Menu-link fa fa-calendar-check-o" /></NavLink>
                <NavLink activeClassName="Menu-link--active" exact to="/"><span className="Menu-link fa fa-trophy" /></NavLink>
                <NavLink activeClassName="Menu-link--active" to="/rules"><span className="Menu-link fa fa-calendar-check-o" /></NavLink>
                <NavLink activeClassName="Menu-link--active" to="/credits"><span className="Menu-link fa fa-birthday-cake" /></NavLink>
            </nav>
        );
    }
}

export default Menu;
