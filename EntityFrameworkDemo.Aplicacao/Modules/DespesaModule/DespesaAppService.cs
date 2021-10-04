using EntityFrameworkDemo.Dominio.Entities.DespesaModule;
using EntityFrameworkDemo.Dominio.Entities.Shared;
using Serilog;
using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Aplicacao.Modules.DespesaModule
{
    public class DespesaAppService
    {
        private readonly IDespesaRepository despesaRepository;

        public DespesaAppService(IDespesaRepository despesaRepository)
        {
            this.despesaRepository = despesaRepository;
        }

        public int InserirNovaDespesa(Despesa despesa)
        {
            Log.Debug("Inserindo novo registro... {Registro}", despesa);

            try
            {
                return despesaRepository.InserirNovo(despesa);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar inserir novo registro {Registro}", despesa);
                throw new Exception(ex.Message, ex);
            }
        }

        public bool EditarRegistro(int id, Despesa despesa)
        {
            Log.Debug("Editando registro ID: {IdRegistro}", id);

            try
            {
                return despesaRepository.EditarRegistro(id, despesa);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar editar registro ID: {IdRegistro}", id);
                throw new Exception(ex.Message, ex);
            }
        }

        public bool ExcluirRegistro(int id)
        {
            Log.Debug("Excluindo registro ID: {IdRegistro}", id);

            try
            {
                return despesaRepository.ExcluirRegistro(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir registro ID: {IdRegistro}", id);
                throw new Exception(ex.Message, ex);
            }
        }

        public Despesa SelecionarPorId(int id)
        {
            Log.Debug("Selecionando registro ID: {IdRegistro}", id);

            try
            {
                return despesaRepository.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar registro ID: {IdRegistro}", id);
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Despesa> SelecionarTodasDespesas()
        {
            Log.Debug("Selecionando todas os registros...");

            try
            {
                return despesaRepository.SelecionarTodos() as List<Despesa>;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar todas as despesas");
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
