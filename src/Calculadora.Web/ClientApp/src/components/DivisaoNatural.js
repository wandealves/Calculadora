import React, { useState } from 'react';

import $ from 'jquery';

import api from '../services/api';

import ResultadoDivisores from './ResultadoDivisores';

function DivisaoNatural(props) {
    const [numero, setNumero] = useState(0);
    const [divisores, setDivisores] = useState([]);
    const [primos, setPrimos] = useState([]);
    const [error, setError] = useState('');

    const [carregando, setCarregando] = useState(false);

    function calcular(event) {
        event.preventDefault();

        setCarregando(true);

        api.get(`DivisaoNatural?numero=${numero}`)
            .then((response) => {

                if (!response.data) return;

                const { primos, divisores } = response.data;

                setDivisores(divisores);
                setPrimos(primos);

                console.log('primos', primos);
                console.log('primos', divisores);
            })
            .catch((_) => {
                setError('ao tentar realizar o calculo');
                $('#myAlert').show();
            }).finally(() => setCarregando(false));


    }

    function altualizarNumero(event) {
        event.preventDefault();

        setNumero(event.target.value);
    }

    function fechar() {
        $('#myAlert').hide();
    }

    return (
        <div>
            {
                error ? (
                    <div className="alert alert-danger alert-dismissible" id="myAlert">
                        <button onClick={fechar} type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Error!</strong> {error}
                    </div>
                ) : ''
            }

            <div className="row">
                <div className="form-inline">
                    <div className="form-group mb-3 ml-3">
                        <input onChange={altualizarNumero} type="number" className="form-control" id="inputPassword2" placeholder="Número" value={numero} />
                    </div>
                    {carregando ? (
                        <div className="spinner-border text-primary mb-3 ml-2" role="status">
                            <span className="sr-only">Loading...</span>
                        </div>
                    ) : (
                        <button onClick={calcular} className="btn btn-primary mb-3 ml-2">Calcular</button>
                    )}
                </div>
            </div>

            <ResultadoDivisores divisores={divisores} primos={primos} />
        </div>
    );
}

export default DivisaoNatural;