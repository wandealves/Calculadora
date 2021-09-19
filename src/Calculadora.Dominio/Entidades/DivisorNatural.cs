using System.Collections.Generic;

namespace Calculadora.Dominio.Entidades
{
    public class DivisorNatural
    {
        private readonly List<long> _primos;
        private readonly List<long> _divisores;

        public DivisorNatural()
        {
            _primos = new List<long>();
            _divisores = new List<long>();
        }

        public IReadOnlyCollection<long> Primos => _primos.ToArray();
        public IReadOnlyCollection<long> Divisores => _divisores.ToArray();

        public void AddPrimo(long primo)
        {
            _primos.Add(primo);
        }

        public void AddPrimos(IList<long> primos)
        {
            _primos.AddRange(primos);
        }

        public void AddDivisor(long divisor)
        {
            _divisores.Add(divisor);
        }

        public void AddDivisores(IList<long> divisores)
        {
            _divisores.AddRange(divisores);
        }
    }
}
