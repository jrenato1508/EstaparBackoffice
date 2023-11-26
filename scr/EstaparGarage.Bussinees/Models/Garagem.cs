using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Bussinees.Models
{
    public class Garagem : Entity
    {
        public Guid PassagemId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco_1aHora { get; set; }
        public decimal Preco_HorasExtra { get; set; }
        public decimal Preco_Mensalista { get; set; }
        public Passagem passagem { get; set; }
    }

   
}
