using EntityFrameworkDemo.Aplicacao.Modules.Shared;
using EntityFrameworkDemo.Dominio.Entities.DespesaModule;
using EntityFrameworkDemo.Dominio.Entities.Shared;

namespace EntityFrameworkDemo.Aplicacao.Modules.DespesaModule
{
    public class DespesaAppService : BaseAppService<Despesa>
    {
        public DespesaAppService(IDespesaRepository despesaRepository) : base(despesaRepository)
        {
        }
    }
}
