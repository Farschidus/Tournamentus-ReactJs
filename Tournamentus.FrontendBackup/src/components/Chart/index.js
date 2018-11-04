import React from 'react';
import 'amcharts3';
import 'amcharts3/amcharts/serial';
import 'amcharts3/amcharts/themes/dark';
import AmCharts from '@amcharts/amcharts3-react';
import ChartConfig from '../Data/ChartConfig.json';

class Chart extends React.Component {
    generateData() {
        const firstDate = new Date();
        const dataProvider = [];

        for (let i = 0; i < 32; ++i) {
            const date = new Date(firstDate.getTime());

            date.setDate(i);

            dataProvider.push({
                date,
                value: Math.floor(Math.random() * 10),
            });
        }
        return dataProvider;
    }

    render() {
        const configWithData = { ...ChartConfig, dataProvider: this.generateData() };

        return (<AmCharts.React style={{ width: '100%', height: '100px' }} options={configWithData} />);
    }
}

export default Chart;
