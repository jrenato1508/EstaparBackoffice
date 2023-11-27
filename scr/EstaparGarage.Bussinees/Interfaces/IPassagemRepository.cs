using EstaparGarage.Bussinees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Bussinees.Interfaces
{
    public interface IPassagemRepository : IRepository<Passagem>
    {
        
        
        Task<Passagem> ObterPassagemPorId(Guid id);

        Task <Passagem> ObterPassagemPorCodigoGaragem(string codigo);

        Task<Passagem> ObterPassagemPorPlavaVeiculo(string placa);

        

    }
}
