﻿namespace EstaparGarage.Bussinees.Models
{
    public class Garagem : Entity
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco_1aHora { get; set; }
        public decimal Preco_HorasExtra { get; set; }
        public decimal Preco_Mensalista { get; set; }

    }

}
