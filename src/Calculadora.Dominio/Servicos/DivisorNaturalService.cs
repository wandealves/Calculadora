using System.Linq;

using Calculadora.Dominio.Entidades;
using Calculadora.Dominio.Interfaces;

namespace Calculadora.Dominio.Servicos
{
    public class DivisorNaturalService : IDivisorNaturalService
    {
        private readonly IMemorizacao<long, DivisorNatural> _memorizacao;
        public DivisorNaturalService(IMemorizacao<long, DivisorNatural> memorizacao)
        {
            _memorizacao = memorizacao;
        }

        public DivisorNatural DivisoresNaturais(long numero)
        {
            if (numero <= 0) return default(DivisorNatural);

            var result = _memorizacao.Obter(numero);

            if (result != null) return result;

            var divisorNatural = new DivisorNatural();

            var fatoresPrimos = divisorNatural.CalcularFatorPrimo(numero).ToList();
            var divisores = divisorNatural.CalcularDivisores(fatoresPrimos);

            divisorNatural.AddDivisores(divisores.Distinct().OrderBy(x => x).ToList());
            divisorNatural.AddPrimos(fatoresPrimos.Distinct().OrderBy(x => x).ToList());

            _memorizacao.Adicionar(numero, divisorNatural);

            return divisorNatural;
        }
    }
}
