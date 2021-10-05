using System.Collections.Generic;

namespace EntityFrameworkDemo.Dominio.Entities.Shared
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        int Inserir(TEntity registro);
        bool Editar(int id, TEntity registro);
        bool Excluir(int id);
        TEntity SelecionarPorId(int id);
        IEnumerable<TEntity> SelecionarTodos();
    }
}
