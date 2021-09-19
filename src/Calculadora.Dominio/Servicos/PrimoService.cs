using System.Linq;

using Calculadora.Dominio.Interfaces;

namespace Calculadora.Dominio.Servicos
{
    public class PrimoService: IPrimoService
    {
        private readonly IMemorizacao<string, long> _memorizacao;

        public PrimoService(IMemorizacao<string, long> memorizacao) 
        {
            _memorizacao = memorizacao;
        }

        public bool EhPrimo(long numero)
        {
            var valoresPrimos = _memorizacao.Obter(nameof(EhPrimo));

            if (valoresPrimos != null && valoresPrimos.Any(x => x == numero))
            {
                return true;
            }

            var ehPrimo = numero != 1;

            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    ehPrimo = false;
                    break;
                }
            }

            if (ehPrimo)
                _memorizacao.Adicionar(nameof(EhPrimo), numero);
            return ehPrimo;
        }
    }
}
