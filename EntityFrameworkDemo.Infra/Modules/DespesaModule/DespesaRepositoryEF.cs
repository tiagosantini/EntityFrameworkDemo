using EntityFrameworkDemo.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDemo.Infra.Modules.DespesaModule
{
    public class DespesaRepositoryEF : IDespesaRepository
    {
        public int InserirNovaDespesa(Despesa despesa)
        {
            try
            {
                using (FinancaDbContext db = new FinancaDbContext())
                {
                    db.Despesas.Add(despesa);

                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Despesa> SelecionarTodasDespesas()
        {
            try
            {
                using (FinancaDbContext db = new FinancaDbContext())
                {
                    return db.Despesas.OrderBy(x => x.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
