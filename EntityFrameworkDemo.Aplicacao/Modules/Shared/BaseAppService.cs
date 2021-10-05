using EntityFrameworkDemo.Dominio.Entities.Shared;
using Serilog;
using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Aplicacao.Modules.Shared
{
    public class BaseAppService<T> where T: class, IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseAppService(IRepository<T> repository) => _repository = repository;

        public virtual int Inserir(T registro)
        {
            Log.Debug("Inserindo novo registro... {Registro}", registro);

            try
            {
                return _repository.InserirNovo(registro);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar inserir novo registro {Registro}", registro);
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool Editar(int id, T registro)
        {
            Log.Debug("Editando registro ID: {IdRegistro}", id);

            try
            {
                return _repository.EditarRegistro(id, registro);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar editar registro ID: {IdRegistro}", id);
                throw new Exception(ex.Message, ex);
            }
        }

        public bool Excluir(int id)
        {
            Log.Debug("Excluindo registro ID: {IdRegistro}", id);

            try
            {
                return _repository.ExcluirRegistro(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir registro ID: {IdRegistro}", id);
                throw new Exception(ex.Message, ex);
            }
        }

        public T SelecionarPorId(int id)
        {
            Log.Debug("Selecionando registro ID: {IdRegistro}", id);

            try
            {
                return _repository.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar registro ID: {IdRegistro}", id);
                throw new Exception(ex.Message, ex);
            }
        }

        public List<T> SelecionarTodos()
        {
            Log.Debug("Selecionando todas os registros...");

            try
            {
                return _repository.SelecionarTodos() as List<T>;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar todas os registros");
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
