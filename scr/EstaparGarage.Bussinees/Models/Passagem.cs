namespace EstaparGarage.Bussinees.Models
{
    public class Passagem : Entity
    {
        public string NomeGaragem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public decimal PrecoTotal { get; set; }


        public FormaPagamento FormaPagamento { get; set; }
        public Garagem Garagem { get; set; }

    }
}


