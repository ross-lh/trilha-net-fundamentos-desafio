using System.Collections.Generic;
using System.Dynamic;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; set; }
        private decimal PrecoPorHora { get; set; }
        private List<string> Veiculos = new List<string>(); 
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        private string Placa { get; set; }

        public void AdicionarVeiculo()
        {
            // Pede ao usuário que digite uma placa (ReadLine) e adiciona esta à lista "Veiculos"
            Console.WriteLine("Insira a placa do veículo a ser estacionado: ");
            string Placa = Console.ReadLine();

            // Verifica a nulidade ou ausência de valor na string inserida
            if (String.IsNullOrEmpty(Placa))
            {   
                // Caso esteja vazia, então se pede ao usuário que insira uma placa válida, retornando ao método de cadastro
                Console.WriteLine("Insira uma placa válida: ");
                AdicionarVeiculo();
            }
            else
            {
                Veiculos.Add(Placa);
                Console.WriteLine("Veículo adicionado no sistema.");
            }
        }

        public void RemoverVeiculo()
        {
            // Pede ao usuário que insira a placa para armazená-la na variável "Placa"
            Console.WriteLine("Digite a placa do veículo a ser removido: ");
            string RemoverPlaca = Console.ReadLine();

            // Verifica se a placa do veículo inserida existe na lista
            if (Veiculos.Any(x => x.ToUpper() == RemoverPlaca.ToUpper()))
            {
                // Pede ao usuário para digitar a quantidade de horas que o veículo permaneceu estacionado:
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int HorasEstacionado = Convert.ToInt32(Console.ReadLine());

                decimal ValorTotal = PrecoInicial + PrecoPorHora * HorasEstacionado; 
                // Remove a placa digitada da lista de veículos
                Veiculos.Remove(RemoverPlaca);

                // Detalha ao usuário qual placa(veículo) foi removido do sistema e o valor total relativo ao tempo estacionado
                Console.WriteLine($"O veículo de placa {RemoverPlaca} foi removido e o preço total foi de: R$ {ValorTotal:F2}");
            }
            else
            {
                // Relata ao usuário que não encontrou a placa mencionada e força um retorno ao menu principal
                Console.WriteLine("Desculpe, o veículo mencionado não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento

            if (Veiculos.Count > 0)
            {
                // Explicita cada veículo estacionado de acordo com a respectiva vaga
                foreach (string placa in Veiculos)
                {
                    Console.WriteLine($"Veículo na vaga {Veiculos.IndexOf(placa)+1} possui a placa: {placa}");
                }
            }
            else
            {
                // Diz ao usuário caso não haja veículo(s) estacionado(s)
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}