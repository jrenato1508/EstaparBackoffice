using System.ComponentModel.DataAnnotations;

namespace EstaparBackoffice.DTO
{
    public class PassagemViewModel
    {
        [Key]
        public Guid id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeGaragem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CarroPlaca { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CarroMarca { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CarroModelo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataHoraEntrada { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        
        public DateTime DataHoraSaida { get; set; }

        public string FormaPagamento { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal PrecoTotal { get; set; }
    }
}
