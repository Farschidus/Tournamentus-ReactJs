import React from 'react';
import PropTypes from 'prop-types';
import ReactSwipeEvents from 'react-swipe-events';
import Flag from './../Flag/Flag';

class GroupCardItem extends React.Component {
    constructor(props) {
        super(props);

        this.GroupCardItem = React.createRef();
        this.onSwipedLeft = this.onSwipedLeft.bind(this);
        this.onSwipedRight = this.onSwipedRight.bind(this);
        this.onRemoveClick = this.onRemoveClick.bind(this);
    }

    onSwipedLeft() {
        if (!this.GroupCardItem.current.classList.contains('GroupCardItem--swipeLeft')) {
            this.GroupCardItem.current.className = 'GroupCardItem GroupCardItem--swipeLeft';
        }
    }

    onSwipedRight() {
        if (!this.GroupCardItem.current.classList.contains('GroupCardItem--swipeRight') &&
            this.GroupCardItem.current.className !== 'GroupCardItem') {
            this.GroupCardItem.current.className = 'GroupCardItem GroupCardItem--swipeRight';
        }
    }

    onRemoveClick() {
        this.onSwipedRight();
        setTimeout(() => {
            this.props.onRemoveItem(this.props.countryName);
        }, 600);
    }

    render() {
        return (
            <div>
                <div className="GroupCardItem-removeButton" onClick={this.onRemoveClick}>
                    <span className="GroupCardItem-removeButton-icon fa fa-minus-circle" />Remove
                </div>
                <ReactSwipeEvents
                    onSwipedLeft={this.onSwipedLeft}
                    onSwipedRight={this.onSwipedRight}
                    className="GroupCardItem-background"
                >
                    <div className="GroupCardItem" ref={this.GroupCardItem}>
                        <Flag size="medium" countryIsoCode={this.props.countryFlag} />{this.props.countryName}
                    </div>
                </ReactSwipeEvents>
            </div>
        );
    }
}

GroupCardItem.propTypes = {
    countryName: PropTypes.string,
    countryFlag: PropTypes.string,
    onRemoveItem: PropTypes.func,
};

export default GroupCardItem;
