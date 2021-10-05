using EntityFrameworkDemo.Dominio.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDemo.Infra.Modules.Shared
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
             _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public int Inserir(TEntity registro)
        {
            try
            {
                _dbSet.Add(registro);

                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(int id, TEntity registro)
        {
            try
            {
                var registroEncontrado = _dbSet.Find(id);

                if (registroEncontrado != null)
                {
                    registro.Id = id;

                    _dbContext.Entry(registroEncontrado).CurrentValues.SetValues(registro);

                    _dbContext.SaveChanges();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool Excluir(int id)
        {
            try
            {
                var registroEncontrado = _dbSet.Find(id);

                if (registroEncontrado != null)
                {
                    _dbSet.Remove(registroEncontrado);

                    _dbContext.SaveChanges();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public TEntity SelecionarPorId(int id)
        {
            try
            {
                return _dbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> SelecionarTodos()
        {
            try
            {
                return _dbSet.AsNoTracking().OrderBy(x => x.Id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
