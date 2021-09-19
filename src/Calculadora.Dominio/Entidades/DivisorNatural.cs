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

        public IList<long> CalcularFatorPrimo(long numero, long fator = 2, List<long> fatores = null)
        {
            if (fatores == null)
            {
                fatores = new List<long>();
                fatores.Add(1);
            }

            var divisor = numero;

            var resto = numero % fator;
            var ehPrimo = EhPrimo(fator);

            if (resto == 0 && ehPrimo)
            {
                divisor = numero / fator;
                fatores.Add(fator);
            }

            if (resto != 0)
                fator += 1;

            if (divisor == 1)
            {
                return fatores;
            }
            else
                return CalcularFatorPrimo(divisor, fator, fatores);
        }

        public bool EhPrimo(long numero)
        {
            var ehPrimo = numero != 1;

            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    ehPrimo = false;
                    break;
                }
            }

            return ehPrimo;
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
