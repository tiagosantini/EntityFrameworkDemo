using System.Collections.Generic;

namespace EntityFrameworkDemo.Dominio.Entities
{
    public interface IRepository<T>
    {
        int InserirNovo(T registro);
        bool EditarRegistro(int id, T registro);
        bool ExcluirRegistro(int id);
        T SelecionarPorId(int id);
        List<T> SelecionarTodos();
    }
}
