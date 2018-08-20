import React from 'react';
import 'amcharts3';
import 'amcharts3/amcharts/serial';
import 'amcharts3/amcharts/themes/dark';
import AmCharts from '@amcharts/amcharts3-react';
import EditableLabel from 'react-inline-editing';
import Timezone from '../Modal/Timezone';
import SelectItemFromModal from '../Modal/SelectItemFromModal';
import ChartConfig from '../Data/ChartConfig.json';
import Timezones from '../Data/Timezones.json';
import { connect } from 'react-redux';
import { updateName, setTimezone } from '../Actions/userActions';

@connect((store) => ({ user: store.user }))
class Profile extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            memberPic: 'clientFiles/profilePics/farschidus.jpg',
            points: {
                perfect: 10,
                goalDiff: 7,
                correct: 5,
                wrong: 0,
            },
        };

        this.setTimezone = this.setTimezone.bind(this);
        this.updateName = this.updateName.bind(this);
    }

    setTimezone(timezone) {
        this.props.dispatch(setTimezone(timezone.name));
    }

    updateName(newName) {
        this.props.dispatch(updateName(newName));
    }

    generateData() {
        const firstDate = new Date();
        const dataProvider = [];

        for (let i = 0; i < 32; ++i) {
            const date = new Date(firstDate.getTime());

            date.setDate(i);

            dataProvider.push({
                date,
                value: i * 10,
            });
        }
        return dataProvider;
    }

    render() {
        const profilePhoto = {
            backgroundImage: `url(${this.state.memberPic})`,
        };
        const totalPoints = (this.state.points.perfect * 10) + (this.state.points.goalDiff * 7) + (this.state.points.correct * 5);
        const configWithData = { ...ChartConfig, dataProvider: this.generateData() };

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
                        <AmCharts.React style={{ width: '100%', height: '100px' }} options={configWithData} />
                    </div>
                    <h1>{totalPoints} points</h1>
                    <h3>Perfect (10pts){this.state.points.perfect}</h3>
                    <h3>GoalDiff (7pts){this.state.points.goalDiff}x</h3>
                    <h3>Correct (5pts){this.state.points.correct}x</h3>
                    <h3>Wrong (0pts){this.state.points.wrong}x</h3>
                </div>
            </div>
        );
    }
}

export default Profile;
