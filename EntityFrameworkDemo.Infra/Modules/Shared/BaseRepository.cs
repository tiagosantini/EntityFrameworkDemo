using EntityFrameworkDemo.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDemo.Infra.Modules.Shared
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext) => _dbContext = dbContext;

        public int InserirNovo(TEntity registro)
        {
            try
            {
                using (_dbContext)
                {
                   _dbContext.Set<TEntity>().Add(registro);

                    return _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditarRegistro(int id, TEntity registro)
        {
            try
            {
                using (_dbContext)
                {
                    var despesaExiste = _dbContext.Set<TEntity>().Any(x => x.Id == id);

                    if (despesaExiste)
                    {
                        registro.Id = id;

                        _dbContext.Set<TEntity>().Update(registro);

                        _dbContext.SaveChanges();
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool ExcluirRegistro(int id)
        {
            try
            {
                using (_dbContext)
                {
                    var despesa = _dbContext.Set<TEntity>().Find(id);

                    if (despesa != null)
                    {
                        _dbContext.Set<TEntity>().Remove(despesa);

                        _dbContext.SaveChanges();

                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntity SelecionarPorId(int id)
        {
            try
            {
                using (_dbContext)
                {
                    return _dbContext.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
                }
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
                using (_dbContext)
                {
                    return _dbContext.Set<TEntity>().OrderBy(x => x.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
