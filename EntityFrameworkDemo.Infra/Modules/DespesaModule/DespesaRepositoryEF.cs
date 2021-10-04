using EntityFrameworkDemo.Dominio.Entities.DespesaModule;
using EntityFrameworkDemo.Dominio.Entities.Shared;
using EntityFrameworkDemo.Infra.Modules.Shared;

namespace EntityFrameworkDemo.Infra.Modules.DespesaModule
{
    public class DespesaRepositoryEF : BaseRepository<Despesa>, IDespesaRepository
    {
        public DespesaRepositoryEF(FinancaDbContext dbContext) : base(dbContext) 
        {
        }
    }
}
