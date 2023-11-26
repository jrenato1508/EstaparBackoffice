using EstaparGarage.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Data.Repository
{
    public class PassagemRepository : Repository<Passagem>
    {
        public PassagemRepository(EstaparDbcontext db) : base(db) { }
     
        // Falta criar as interfaces de PassagemRepository, GaragemRepositoy e FormaDePagamentoRepository e aplica-las. Ainda não criei 
    }
}
