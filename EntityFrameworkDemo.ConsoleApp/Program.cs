using EntityFrameworkDemo.Aplicacao.Modules.DespesaModule;
using EntityFrameworkDemo.ConsoleApp.Modules.DespesaModule;
using EntityFrameworkDemo.Dominio.Shared;
using EntityFrameworkDemo.Infra;
using EntityFrameworkDemo.Infra.Logging;
using EntityFrameworkDemo.Infra.Modules.DespesaModule;
using System;

namespace EntityFrameworkDemo.ConsoleApp
{
    public class Program
    {
        private static FinancaDbContext dbContext = new FinancaDbContext();
        private static DespesaRepositoryEF despesaRepository = new DespesaRepositoryEF(dbContext);
        private static readonly DespesaAppService despesaService = new DespesaAppService(despesaRepository);
        private static readonly IOperacaoCadastravel operacoes = new OperacoesDespesa(despesaService);

        static void Main(string[] args)
        {
            SerilogConfig.CriarLogger();

            while (true)
            {
                ApresentarMenu();
                string opcao = Console.ReadLine();

                if (opcao == "S" || opcao == "s")
                    break;

                Console.Clear();

                switch (opcao)
                {
                    case "1": operacoes.InserirNovoRegistro(); break;
                    case "2": operacoes.EditarRegistro(); break;
                    case "3": operacoes.ExcluirRegistro(); break;
                    case "4": operacoes.SelecionarRegistroPorId(); break;
                    case "5": operacoes.SelecionarTodosRegistros(); break;
                    default: break;
                }

                Console.ReadLine();
            }
        }

        private static void ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Finanças");
            Console.WriteLine("-----------------------------------\n");
            Console.WriteLine("1 - Inserir nova despesa");
            Console.WriteLine("2 - Editar despesa");
            Console.WriteLine("3 - Excluir despesa");
            Console.WriteLine("4 - Selecionar despesa por ID");
            Console.WriteLine("5 - Selecionar todas as despesas");
            Console.WriteLine("S - Sair do programa");

            Console.Write("\nO que deseja fazer? ");
        }
    }
}
