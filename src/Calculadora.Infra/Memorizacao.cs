using System.Collections.Generic;
using System.Linq;

using Calculadora.Dominio.Interfaces;

namespace Calculadora.Infra
{
    public class Memorizacao<T, U> : IMemorizacao<T, U>
    {
        private readonly Dictionary<T, U> _valores;

        public Memorizacao()
        {
            _valores = new Dictionary<T, U>();
        }

        public IReadOnlyDictionary<T, U> Valores => _valores;

        public void Adicionar(T chave, U valor)
        {
            if (!_valores.ContainsKey(chave))
                _valores.Add(chave, valor);
        }

        public U Obter(T chave)
        {
            if (_valores.Any() == true)
            {
                return _valores[chave];
            }

            return default(U);
        }
    }
}
