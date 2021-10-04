using System.Collections.Generic;

namespace EntityFrameworkDemo.Dominio.Entities.Shared
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        int InserirNovo(TEntity registro);
        bool EditarRegistro(int id, TEntity registro);
        bool ExcluirRegistro(int id);
        TEntity SelecionarPorId(int id);
        IEnumerable<TEntity> SelecionarTodos();
    }
}
