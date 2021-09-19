import React from 'react';

function ResultadoDivisores(props) {

    return (
        <div className="row">
            <div className="col-6">
                <div className="card">
                    <div className="card-header">
                        Divisores Naturais
                    </div>
                    <div className="card-body">
                        <ul className="list-group">
                            {props.divisores && props.divisores.length > 0 ? (props.divisores.map((valor, index) => (
                                <li key={index} className="list-group-item text-center">{valor}</li>
                            ))) : <p>Lista vazia</p>}
                        </ul>
                    </div>
                </div>
            </div>

            <div className="col-6">
                <div className="card">
                    <div className="card-header">
                        Números Primos
                    </div>
                    <div className="card-body">
                        <ul className="list-group">
                            {props.primos && props.primos.length > 0 ? (props.primos.map((valor, index) => (
                                <li key={index} className="list-group-item text-center">{valor}</li>
                            ))) : <p>Lista vazia</p>}
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default ResultadoDivisores;