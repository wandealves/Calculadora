using System.Collections.Generic;

namespace Calculadora.Dominio.Interfaces
{
    public interface IMemorizacao<T, U>
    {
        void AdicionarValor(T chave, U valor);
        void AdicionarValores(T chave, List<U> valores);
        void AdicionarValorNoDicionario(T chaveExterna, T chaveInterna, U valor);
        void AdicionarValoresNoDicionario(T chaveExterna, T chaveInterna, IList<U> valores);
        IList<U> ObterValores(T chave);
        U ObterValor(T chave);
        IList<U> ObterValoresdoDicionario(T chaveExterna, T chaveInterna);
    }
}
