using System.ComponentModel.DataAnnotations;

namespace EstaparBackoffice.DTO
{
    public class GaragemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco_1aHora { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco_HorasExtra { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco_Mensalista { get; set; }
    }
}
