using EntityFrameworkDemo.Dominio.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDemo.Infra.Modules.DespesaModule
{
    public class DespesaRepositoryEF : IDespesaRepository
    {
        public int InserirNovaDespesa(Despesa despesa)
        {
            using (FinancaDbContext db = new FinancaDbContext())
            {
                db.Despesas.Add(despesa);

                return db.SaveChanges();
            }
        }

        public List<Despesa> SelecionarTodasDespesas()
        {
            using (FinancaDbContext db = new FinancaDbContext())
            {
                return db.Despesas.OrderBy(x => x.Id).ToList();
            }
        }
    }
}
