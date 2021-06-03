using System;
using System.Collections.Generic;

namespace DevFitness.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite seu nome.");
            var nome = Console.ReadLine();

            Console.WriteLine("Digite sua altura.");
            var altura = Console.ReadLine();

            Console.WriteLine("Digite seu peso.");
            var peso = Console.ReadLine();

            var opcao = "-1";
            var refeicoes = new List<Refeicao>();
            while (opcao != "0")
            {
                ExibirOpcoes();
                opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.WriteLine($"Nome: {nome}, Altura: {altura}, Peso: {altura}");
                }
                else if (opcao == "2")
                {
                    Cadastrar(refeicoes);
                }
                else if (opcao == "3")
                {
                    ListarRefeicoes(refeicoes);
                }
                else
                {
                    Console.WriteLine("Por favor, digite outra opção.");
                }
            }
            //var bebida = new Bebida("leite integral", 500, true);
            //var comida = new Comida("Sanduba", 600, 15.00m);

            //var listaComidas = new List<Refeicao> { bebida, comida };
            //ListarRefeicoes(listaComidas);
            Console.WriteLine("Fechando o app.");
            //Console.Read();
        }

        private static void ListarRefeicoes(List<Refeicao> refeicaos)
        {
            refeicaos.ForEach(item =>
            {
                item.ImprimirMensagem();
            });
        }

        private static void Cadastrar(List<Refeicao> refeicaos)
        {
            Console.WriteLine("Digite a descrição da refeição.");
            var descricao = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de calorias.");
            var calorias = Console.ReadLine();

            if (int.TryParse(calorias, out int caloriaInt))
            {
                var refeicao = new Refeicao(descricao, caloriaInt);
                refeicaos.Add(refeicao);
                Console.WriteLine("Refeição adicionada com sucesso.");
            }
            else
            {
                Console.WriteLine("Valor de calorias inválido.");
            }

        }

        public static void ExibirOpcoes()
        {
            Console.WriteLine("--- Seja bem-vindo (a) ao DevFitness ---");
            Console.WriteLine("1 - Exibir detalhes de usuario.");
            Console.WriteLine("2 - Cadastrar nova refeição.");
            Console.WriteLine("3 - Listar todas refeições.");
            Console.WriteLine("0 - Finalizar aplicação.");
            Console.WriteLine("------");
        }
    }
}
