namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // IMPLEMENTADO!!!
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // IMPLEMENTADO!!!
                throw new Exception("Ops! parece que a capacidade da suíte é menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // IMPLEMENTADO!!!
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // IMPLEMENTADO!!!
            if (Suite == null)
            {
                throw new Exception("Suite não cadastrada!");
            }
            
              decimal valor = DiasReservados * Suite.ValorDiaria;
            

            if (DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;   
        }
    }
}