import React, { Component } from 'react';

import DivisaoNatural from './DivisaoNatural'

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <DivisaoNatural />
            </div>
        );
    }
}
