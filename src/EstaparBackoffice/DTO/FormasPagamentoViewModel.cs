using System.ComponentModel.DataAnnotations;

namespace EstaparBackoffice.DTO
{
    public class FormasPagamentoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
