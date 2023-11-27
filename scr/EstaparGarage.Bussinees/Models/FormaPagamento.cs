namespace EstaparGarage.Bussinees.Models
{
    public class FormaPagamento : Entity
    {
        public Guid PassagemId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public Passagem passagem { get; set; }
    }
}
