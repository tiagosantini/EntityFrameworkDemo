using EntityFrameworkDemo.Dominio.Entities;
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
                return despesaRepository.InserirNovaDespesa(despesa);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar inserir novo registro {Registro}", despesa);
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Despesa> SelecionarTodasDespesas()
        {
            Log.Debug("Selecionando todas os registros...");

            try
            {
                return despesaRepository.SelecionarTodasDespesas();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar todas as despesas");
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
