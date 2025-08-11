using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Reserva reserva = null;

bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("-------Menu das Resevas-------");
    Console.WriteLine("1 - Cadastrar suíte");
    Console.WriteLine("2 - Cadastrar hóspedes");
    Console.WriteLine("3 - Ver quantidade de hóspedes");
    Console.WriteLine("4 - Calcular valor da diária");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("------------------------------");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Informe o tipo da suíte: ");
            string tipo = Console.ReadLine();

            Console.Write("Informe a capacidade da suíte: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor da diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            Suite suite = new Suite(tipo, capacidade, valorDiaria);

            reserva = new Reserva();
            reserva.CadastrarSuite(suite);

            Console.WriteLine("Suíte cadastrada com sucesso!");
            Console.ReadKey();
            break;11

        case "2":
            if (reserva == null || reserva.Suite == null)
            {
                Console.WriteLine("Cadastre uma suíte antes de adicionar hóspedes.");
                Console.ReadKey();
                break;
            }

            Console.Write("Quantos hóspedes deseja cadastrar? ");
            int qtd = int.Parse(Console.ReadLine());

            List<Pessoa> hospedes = new List<Pessoa>();

            for (int i = 0; i < qtd; i++)
            {
                Console.Write($"Digite o nome do hóspede {i + 1}: ");
                string nome = Console.ReadLine();

                Console.Write($"Digite o sobrenome do hóspede {i + 1}: ");
                string sobrenome = Console.ReadLine();

                hospedes.Add(new Pessoa(nome, sobrenome));
            }

            try
            {
                reserva.CadastrarHospedes(hospedes);
                Console.WriteLine("Hóspedes cadastrados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            Console.ReadKey();
            break;

        case "3":
            if (reserva != null)
                Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            else
                Console.WriteLine("Nenhuma reserva cadastrada.");
            Console.ReadKey();
            break;

        case "4":
            if (reserva != null)
            {
                Console.Write("Informe o número de dias reservados: ");
                reserva.DiasReservados = int.Parse(Console.ReadLine());

                try
                {
                    decimal valor = reserva.CalcularValorDiaria();
                    Console.WriteLine($"Valor total da diária: R$ {valor}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma reserva cadastrada.");
            }
            Console.ReadKey();
            break;

        case "0":
            continuar = false;
            break;

        default:
            Console.WriteLine("Opção inválida!");
            Console.ReadKey();
            break;
    }
}

