using System.Collections.Generic;

namespace EntityFrameworkDemo.Dominio.Entities
{
    public interface IDespesaRepository
    {
        int InserirNovaDespesa(Despesa despesa);
        List<Despesa> SelecionarTodasDespesas();
    }
}
