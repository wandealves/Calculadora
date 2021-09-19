using System.Collections.Generic;
using System.Linq;

using Calculadora.Dominio.Entidades;
using Calculadora.Dominio.Interfaces;

namespace Calculadora.Dominio.Servicos
{
    public class DivisorNaturalService : IDivisorNaturalService
    {
        private readonly IPrimoService _primoService;
        private readonly IMemorizacao<string, long> _memorizacao;
        public DivisorNaturalService(IPrimoService primoService, IMemorizacao<string, long> memorizacao)
        {
            _primoService = primoService;
            _memorizacao = memorizacao;
        }

        public DivisorNatural DivisoresNaturais(long numero)
        {
            if (numero <= 0) return default(DivisorNatural);

            var divisorNatural = new DivisorNatural();

            var fatoresPrimos = CalcularFatorPrimo(numero, numero);
            var divisores = divisorNatural.CalcularDivisores(fatoresPrimos);

            divisorNatural.AddDivisores(divisores.Distinct().OrderBy(x => x).ToList());
            divisorNatural.AddPrimos(fatoresPrimos.Distinct().OrderBy(x => x).ToList());

            return divisorNatural;
        }

        private List<long> CalcularFatorPrimo(long valorOriginal, long numero, long fator = 2, List<long> fatores = null)
        {
            if (fatores == null)
            {
                fatores = new List<long>();
                fatores.Add(1);
            }

            if (valorOriginal == numero)
            {
                var listaNoDicionario = _memorizacao.Obter(nameof(CalcularFatorPrimo), numero.ToString());

                if (listaNoDicionario?.Any() == true) return listaNoDicionario.ToList();
            }

            var divisor = numero;

            var resto = numero % fator;
            var ehPrimo = _primoService.EhPrimo(fator);

            if (resto == 0 && ehPrimo)
            {
                divisor = numero / fator;
                fatores.Add(fator);
            }

            if (resto != 0)
                fator += 1;

            if (divisor == 1)
            {
                _memorizacao.Adicionar(nameof(CalcularFatorPrimo), valorOriginal.ToString(), fatores);
                return fatores;
            }
            else
                return CalcularFatorPrimo(valorOriginal, divisor, fator, fatores);
        }
    }
}
