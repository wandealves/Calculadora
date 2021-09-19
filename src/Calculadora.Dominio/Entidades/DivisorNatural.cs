using System.Collections.Generic;
using System.Linq;

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

        public IList<long> CalcularDivisores(List<long> fatores, int index = 0, List<long> divisores = null)
        {
            if (divisores == null)
            {
                divisores = new List<long>();
                divisores.Add(1);
            }

            var fator = fatores[index];
            var clone = divisores.ToList();

            foreach (var divisor in clone)
            {
                var valor = fator * divisor;
                if (!divisores.Any(x => x == valor))
                    divisores.Add(valor);
            }

            if ((fatores.Count - 1) == index) return divisores;

            index += 1;

            return CalcularDivisores(fatores, index, divisores);
        }

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
