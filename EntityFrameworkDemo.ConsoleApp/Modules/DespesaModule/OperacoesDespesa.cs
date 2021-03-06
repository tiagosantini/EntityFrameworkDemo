using EntityFrameworkDemo.Aplicacao.Modules.DespesaModule;
using EntityFrameworkDemo.ConsoleApp.Modules.Shared;
using EntityFrameworkDemo.Dominio.Entities.DespesaModule;
using EntityFrameworkDemo.Dominio.Entities.Shared;
using EntityFrameworkDemo.Dominio.ValueObjects.DespesaModule;
using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.ConsoleApp.Modules.DespesaModule
{
    public class OperacoesDespesa : IOperacaoCadastravel
    {
        private readonly DespesaAppService despesaService;

        public OperacoesDespesa(DespesaAppService despesaService)
        {
            this.despesaService = despesaService;
        }

        public void InserirNovoRegistro()
        {
            Despesa despesa = ObterDespesa(TipoOperacao.Insercao);

            int novasColunas = despesaService.Inserir(despesa);

            Console.Clear();

            if (novasColunas > 0)
                Console.WriteLine("Despesa salva com sucesso!");
            else
                Console.WriteLine("Falha ao salvar Despesa");
        }

        public void EditarRegistro()
        {
            Console.Write("Digite o ID do registro que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Despesa despesa = ObterDespesa(TipoOperacao.Edicao, id);

            bool conseguiuEditar = despesaService.Editar(despesa);

            Console.Clear();

            if (conseguiuEditar)
                Console.WriteLine("Despesa editada com sucesso!");
            else
                Console.WriteLine("Falha ao editar Despesa");
        }

        public void ExcluirRegistro()
        {
            Console.Write("Digite o ID do registro que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = despesaService.Excluir(id);

            Console.Clear();

            if (conseguiuExcluir)
                Console.WriteLine("Despesa excluída com sucesso!");
            else
                Console.WriteLine("Falha ao excluir Despesa");
        }

        public void SelecionarRegistroPorId()
        {
            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var despesa = despesaService.SelecionarPorId(id);

            Console.Clear();

            if (despesa != null)
                ApresentarTabela(despesa);
            else
                Console.WriteLine($"Falha ao selecionar Despesa ID: {id}");
        }

        public void SelecionarTodosRegistros()
        {
            decimal totalDespesas = 0m;

            ConfigurarTitulo("Visualizando todas as despesas salvas...");

            var despesasEncontradas = despesaService.SelecionarTodos();

            ApresentarTabela(despesasEncontradas, ref totalDespesas);

            Console.WriteLine($"\nTotal de despesas: R$ {totalDespesas}");
        }

        #region Métodos privados da tela

        private static Despesa ObterDespesa(TipoOperacao tipoOperacao = TipoOperacao.Insercao, int id = 0)
        {
            Console.Write("Por favor digite a descrição da despesa: ");
            string descricao = Console.ReadLine();

            Console.Clear();
            Console.Write("Por favor digite o valor da despesa: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());

            TipoDespesa tipoDespesa = TipoDespesa.Essencial;
            string tipoEscolhido;

            do
            {
                Console.Clear();
                Console.WriteLine("Por favor escolha o tipo da despesa:\n");
                Console.WriteLine("1 - Essencial");
                Console.WriteLine("2 - Supérflua");

                tipoEscolhido = Console.ReadLine();

                if (tipoEscolhido != "1" && tipoEscolhido != "2")
                {
                    Console.WriteLine("Por favor escolha uma opção válida, digite ENTER para tentar novamente."!);
                    Console.ReadLine();
                }

            } while (tipoEscolhido != "1" && tipoEscolhido != "2");

            switch (tipoEscolhido)
            {
                case "1": tipoDespesa = TipoDespesa.Essencial; break;
                case "2": tipoDespesa = TipoDespesa.Superflua; break;
                default: break;
            }

            Despesa despesa = Despesa.NovaDespesa(descricao, valor, tipoDespesa);

            if (tipoOperacao == TipoOperacao.Edicao)
                despesa.Id = id;

            return despesa;
        }

        private static void ConfigurarTitulo(string titulo)
        {
            Console.WriteLine(titulo);
            Console.WriteLine("---------------------------------------\n");
        }

        private static void ApresentarTabela(List<Despesa> despesas, ref decimal totalDespesas)
        {
            string configuracaoColunasTabela = "{0,-10} | {1,-50} | {2,-20} | {3,-15}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Descrição", "Valor", "Tipo de Despesa");

            foreach (Despesa d in despesas)
            {
                Console.WriteLine(configuracaoColunasTabela, d.Id, d.Descricao, d.Valor, d.TipoDespesa);
                totalDespesas += d.Valor;
            }

            Console.ResetColor();
        }

        private static void ApresentarTabela(Despesa despesa)
        {
            string configuracaoColunasTabela = "{0,-10} | {1,-50} | {2,-20} | {3,-15}";

            MontarCabecalhoTabela(configuracaoColunasTabela, "Id", "Descrição", "Valor", "Tipo de Despesa");

            Console.WriteLine(configuracaoColunasTabela, despesa.Id, despesa.Descricao, despesa.Valor, despesa.TipoDespesa);

            Console.ResetColor();
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela, params object[] colunas)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(configuracaoColunasTabela, colunas);

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }
}
