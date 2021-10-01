﻿using EntityFrameworkDemo.Aplicacao.Modules.DespesaModule;
using EntityFrameworkDemo.ConsoleApp.Modules.DespesaModule;
using EntityFrameworkDemo.Dominio.Shared;
using EntityFrameworkDemo.Infra.Modules.DespesaModule;
using System;

namespace EntityFrameworkDemo.ConsoleApp
{
    public class Program
    {
        private static readonly DespesaAppService despesaService = new DespesaAppService(new DespesaRepositoryEF());
        private static readonly IOperacaoCadastravel operacoes = new OperacoesDespesa(despesaService);

        static void Main(string[] args)
        {
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
                    case "2": operacoes.SelecionarTodosRegistros(); break;
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
            Console.WriteLine("2 - Visualizar despesas");
            Console.WriteLine("S - Sair do programa");

            Console.Write("\nO que deseja fazer? ");
        }
    }
}