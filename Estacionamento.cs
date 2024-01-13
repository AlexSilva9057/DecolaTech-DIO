using System;
using System.Collections.Generic;

namespace SistemaEstacionamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Estacionamento estacionamento = new Estacionamento();

            while (true)
            {
                Console.WriteLine("Sistema de Estacionamento");
                Console.WriteLine("1 - Adicionar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");
                
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite a placa do veículo: ");
                        string placa = Console.ReadLine();
                        Console.Write("Digite a marca do veículo: ");
                        string marca = Console.ReadLine();
                        Veiculo veiculo = new Veiculo(placa, marca);
                        estacionamento.AdicionarVeiculo(veiculo);
                        Console.WriteLine("Veículo adicionado com sucesso.");
                        break;
                    case 2:
                        Console.Write("Digite a placa do veículo a ser removido: ");
                        string placaRemover = Console.ReadLine();
                        double valor = estacionamento.RemoverVeiculo(placaRemover);
                        if (valor >= 0)
                        {
                            Console.WriteLine($"Veículo removido. Valor a pagar: R${valor:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Veículo não encontrado no estacionamento.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Veículos no estacionamento:");
                        foreach (Veiculo v in estacionamento.ListarVeiculos())
                        {
                            Console.WriteLine($"{v.Placa} - {v.Marca}");
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Escolha novamente.");
                        break;
                }
            }
        }
    }

    class Veiculo
    {
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public DateTime HoraEntrada { get; private set; }

        public Veiculo(string placa, string marca)
        {
            Placa = placa;
            Marca = marca;
            HoraEntrada = DateTime.Now;
        }

        public double CalcularValor()
        {
            TimeSpan tempoEstacionado = DateTime.Now - HoraEntrada;
            double horasEstacionado = tempoEstacionado.TotalHours;

            if (horasEstacionado <= 2)
            {
                return 5.00; //valor para 2 horas estacionado
            }
            else if (horasEstacionado <= 4)
            {
                return 10.00; //valor para 4 horas estacionado
            }
            else if
            {
                return 15.00; //valor para 6 horas estacionado
            }
            else
            {
                return 120.00; // Valor para aluguel de vaga por dia
            }
        }
    }

    class Estacionamento
    {
        private List<Veiculo> veiculosEstacionados;

        public Estacionamento()
        {
            veiculosEstacionados = new List<Veiculo>();
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            veiculosEstacionados.Add(veiculo);
        }

        public double RemoverVeiculo(string placa)
        {
            foreach (Veiculo veiculo in veiculosEstacionados)
            {
                if (veiculo.Placa == placa)
                {
                    veiculosEstacionados.Remove(veiculo);
                    return veiculo.CalcularValor();
                }
            }
            return -1; // Retorna um valor negativo se o veículo não for encontrado
        }

        public List<Veiculo> ListarVeiculos()
        {
            return veiculosEstacionados;
        }
    }
}
