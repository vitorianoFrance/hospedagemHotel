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
            if (hospedes.Count <= Suite.Capacidade) //utilizando o .count para "contar" a quantidade de hospedes e o .Capacidade para ver quantas suites estão disponíveis, para assim efetuar a verificar atráves do IF
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("O número de hóspedes é maior que a capacidade dos quartos."); //Exception apenas para retornar o erro e a causa do mesmo, caso estoure a capacidade de suítes
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int id_hospede = 1;
            int quantidadeHospedes = Hospedes.Count;
            foreach( Pessoa hospedes in Hospedes)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"O hospede N° {id_hospede} é {hospedes.NomeCompleto}.");

                id_hospede ++;
            }

            return quantidadeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria; //Calculo para saber o valor da diária
            decimal valorDesconto = valor - 0.9m;               //Calculo desconto diária, para o IF linha 56

            if (DiasReservados >= 10) //validação da quantidade de dias para desconto, se for maior que 10 dias, recebe 10% de desconto
            {
                valor = valorDesconto;
            }

            return valor;
        }
    }
}