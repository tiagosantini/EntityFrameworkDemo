using EntityFrameworkDemo.Dominio.ValueObjects;

namespace EntityFrameworkDemo.Dominio.Entities
{
    public class Despesa
    {
        private Despesa(string descricao, decimal valor, TipoDespesa tipoDespesa)
        {
            Descricao = descricao;
            Valor = valor;
            TipoDespesa = tipoDespesa;
        }

        public static Despesa NovaDespesa(string descricao, decimal valor, TipoDespesa tipoDespesa)
        {
            return new Despesa(descricao, valor, tipoDespesa);
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoDespesa TipoDespesa { get; set; }
    }
}
