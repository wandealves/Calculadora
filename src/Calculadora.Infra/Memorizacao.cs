using System.Collections.Generic;
using System.Linq;

using Calculadora.Dominio.Interfaces;

namespace Calculadora.Infra
{
    public class Memorizacao<T, U> : IMemorizacao<T, U>
    {
        private readonly Dictionary<T, IList<U>> _valores;
        private readonly Dictionary<T, Dictionary<T, IList<U>>> _dicionarios;

        public Memorizacao()
        {
            _valores = new Dictionary<T, IList<U>>();
            _dicionarios = new Dictionary<T, Dictionary<T, IList<U>>>();
        }

        public IReadOnlyDictionary<T, IList<U>> Valores => _valores;
        public Dictionary<T, Dictionary<T, IList<U>>> Dicionarios => _dicionarios;

        public void Adicionar(T chave, U valor)
        {
            if (!_valores.ContainsKey(chave))
            {
                var lista = new List<U> { valor };
                _valores.Add(chave, lista);
            }
            else
            {
                var lista = _valores[chave];

                if (lista.Any(x => !x.Equals(valor)))
                {
                    lista.Add(valor);
                }
            }
        }

        public void Adicionar(T chave, List<U> valores)
        {
            if (!_valores.ContainsKey(chave))
                _valores.Add(chave, valores);
        }

        public void Adicionar(T chaveExterna, T chaveInterna, U valor)
        {
            if (!_dicionarios.ContainsKey(chaveExterna))
            {
                var dicionarioInterno = new Dictionary<T, IList<U>>();
                dicionarioInterno.Add(chaveInterna, new List<U> { valor });

                _dicionarios.Add(chaveExterna, dicionarioInterno);
            }
            else
            {
                var dicionarioInterno = _dicionarios[chaveExterna];
                var listaInterna = dicionarioInterno[chaveInterna];
                if (listaInterna.Any(x => !x.Equals(valor)))
                {
                    listaInterna.Add(valor);
                }
            }
        }

        public void Adicionar(T chaveExterna, T chaveInterna, IList<U> valores)
        {
            if (!_dicionarios.ContainsKey(chaveExterna))
            {
                var dicionarioInterno = new Dictionary<T, IList<U>>();
                dicionarioInterno.Add(chaveInterna, valores);

                _dicionarios.Add(chaveExterna, dicionarioInterno);
            }
            else
            {
                var dicionarioInterno = _dicionarios[chaveExterna];
                if (!dicionarioInterno.ContainsKey(chaveInterna))
                {
                    dicionarioInterno.Add(chaveInterna, valores);
                }
            }
        }

        public IList<U> Obter(T chave)
        {
            if (_valores.Any() == true)
            {
                return _valores[chave];
            }

            return default(IList<U>);
        }

        public U ObterUnico(T chave)
        {
            if (_valores.Any() == true)
            {
                return _valores[chave].FirstOrDefault();
            }

            return default(U);
        }

        public IList<U> Obter(T chaveExterna, T chaveInterna)
        {
            if (_dicionarios.Any() == true)
            {
                var dicionarioInterno = _dicionarios[chaveExterna];
                if (dicionarioInterno.Any())
                {
                    if (dicionarioInterno.ContainsKey(chaveInterna))
                    {
                        var listaInterna = dicionarioInterno[chaveInterna];

                        return listaInterna;
                    }
                }
            }

            return default(IList<U>);
        }
    }
}
