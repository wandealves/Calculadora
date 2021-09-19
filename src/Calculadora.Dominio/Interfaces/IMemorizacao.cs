namespace Calculadora.Dominio.Interfaces
{
    public interface IMemorizacao<T, U>
    {
        void Adicionar(T chave, U valor);
        U Obter(T chave);
    }
}
