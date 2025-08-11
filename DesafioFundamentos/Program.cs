using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Clear();

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

decimal faturamentoTotal = 0;

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente

string opcao = string.Empty;
bool exibirMenu = true;

Estacionamento es = new(precoInicial, precoPorHora, faturamentoTotal, exibirMenu);

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo (ENTRADA)");
    Console.WriteLine("2 - Remover veículo (SAÍDA)");
    Console.WriteLine("3 - Listar veículos estacionados");
    Console.WriteLine("4 - Encerrar programa\n");
    es.MostrarFaturamento();

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;
        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Estacionamento esFinal = new(precoInicial, precoPorHora, faturamentoTotal, exibirMenu);

esFinal.MostrarFaturamento();
Console.WriteLine("O programa se encerrou");