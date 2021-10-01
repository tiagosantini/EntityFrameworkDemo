using EntityFrameworkDemo.Dominio.Entities;
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
            try
            {
                return despesaRepository.InserirNovaDespesa(despesa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Despesa> SelecionarTodasDespesas()
        {
            try
            {
                return despesaRepository.SelecionarTodasDespesas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
