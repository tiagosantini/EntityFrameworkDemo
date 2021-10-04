using EntityFrameworkDemo.Dominio.Entities.Shared;
using EntityFrameworkDemo.Dominio.ValueObjects.DespesaModule;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Dominio.Entities.DespesaModule
{
    public class Despesa : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
        
        [Required]
        public decimal Valor { get; set; }
        
        [Required]
        public TipoDespesa TipoDespesa { get; set; }

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
    }
}
