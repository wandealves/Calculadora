using System.Collections.Generic;

namespace Calculadora.Dominio.Interfaces
{
    public interface IMemorizacao<T, U>
    {
        void Adicionar(T chave, U valor);
        void Adicionar(T chave, List<U> valores);
        void Adicionar(T chaveExterna, T chaveInterna, U valor);
        void Adicionar(T chaveExterna, T chaveInterna, IList<U> valores);
        IList<U> Obter(T chave);
        U ObterUnico(T chave);
        IList<U> Obter(T chaveExterna, T chaveInterna);
    }
}
