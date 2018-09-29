import React from 'react';
import PropTypes from 'prop-types';
import Team from './../Modal/Team';
import GroupCardItem from './GroupCardItem';
import SelectItemFromModal from '../Modal/SelectItemFromModal';
import { connect } from 'react-redux';
import { fetchAllTeams } from '../Actions/teamActions';

@connect((store) => ({ team: store.team }))
class Card extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            modalActive: false,
            countries: [
                { name: 'Spain', isoCode: 'es' },
                { name: 'Portugal', isoCode: 'pt' },
                { name: 'Iran', isoCode: 'ir' },
                { name: 'Morocoo', isoCode: 'ma' },
            ],
        };

        this.removeTeam = this.removeTeam.bind(this);
        this.addNewTeam = this.addNewTeam.bind(this);
    }

    componentDidMount() {
        this.props.dispatch(fetchAllTeams());
    }

    removeTeam(countryName) {
        const countries = this.state.countries.filter((obj) => obj.name !== countryName);
        this.setState({
            countries,
        });
    }

    addNewTeam(team) {
        const teams = this.state.countries;
        teams.push(team);
        this.setState({
            countries: teams,
            modalActive: false,
        });
    }

    render() {
        const content = this.state.countries.map((country, i) => (
            <GroupCardItem
                key={i}
                countryName={country.name}
                countryFlag={country.isoCode}
                onRemoveItem={this.removeTeam}
            />));

        // Replace with API
        const modalItems = this.props.team.teams.map((team, i) => (
            <Team
                key={i}
                name={team.name}
                isoCode={team.isoCode}
                onSelect={this.addNewTeam}
            />));

        return (
            <div className="Card">
                <header className="Card-header">{this.props.title}</header>
                <article className="Card-content">
                    {content}
                    <SelectItemFromModal
                        className="AddNewTeam"
                        selectText="Add New Team"
                        modalItems={modalItems}
                        closeModal={this.state.modalActive}
                    />
                </article>
            </div>
        );
    }
}

Card.propTypes = {
    title: PropTypes.string.isRequired,
};

export default Card;
