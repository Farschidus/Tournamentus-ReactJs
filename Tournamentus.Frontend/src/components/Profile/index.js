import React from 'react';
import EditableLabel from 'react-inline-editing';
import Chart from '../Chart';
import Timezone from '../Modal/Timezone';
import SelectItemFromModal from '../Modal/SelectItemFromModal';
import Timezones from '../Data/Timezones.json';
import { connect } from 'react-redux';
import { updateName, setTimezone } from '../Actions/userActions';

@connect((store) => ({ user: store.user }))
class Profile extends React.Component {
    constructor(props) {
        super(props);

        this.setTimezone = this.setTimezone.bind(this);
        this.updateName = this.updateName.bind(this);
    }

    setTimezone(timezone) {
        this.props.dispatch(setTimezone(timezone.name));
    }

    updateName(newName) {
        this.props.dispatch(updateName(newName));
    }

    render() {
        const profilePhoto = {
            backgroundImage: `url(${this.props.user.picture})`,
        };
        const totalPoints = (this.props.user.points.perfect * 10) + (this.props.user.points.goalDiff * 7) + (this.props.user.points.correct * 5);

        const modalItems = Timezones.map((zone, i) => (
            <Timezone
                key={i}
                name={zone.text}
                offset={zone.offset}
                onSelect={this.setTimezone}
            />));

        return (
            <div className="Profile">
                <header className="Profile-top">
                    <span className="Profile-photo" style={profilePhoto} />
                    <EditableLabel
                        text={this.props.user.name}
                        onFocusOut={this.updateName}
                        labelClassName="Profile-name-label"
                        inputClassName="Profile-name-input"
                    />
                    <SelectItemFromModal
                        className="Profile-timezone"
                        selectText={this.props.user.timezone}
                        onSelectItem={this.setTimezone}
                        modalItems={modalItems}
                    />
                </header>
                <div className="Profile-bottom">
                    <div className="chart" style={{ marginTop: '-25px' }}>
                        <Chart />
                    </div>
                    <h1>{totalPoints} points</h1>
                    <h3>Perfect (10pts){this.props.user.points.perfect}</h3>
                    <h3>GoalDiff (7pts){this.props.user.points.goalDiff}x</h3>
                    <h3>Correct (5pts){this.props.user.points.correct}x</h3>
                    <h3>Wrong (0pts){this.props.user.points.wrong}x</h3>
                </div>
            </div>
        );
    }
}

export default Profile;
