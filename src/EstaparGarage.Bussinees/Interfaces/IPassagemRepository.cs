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

        Task<List<Passagem>> ObterPassagemPeriodo(DateTime dtentrada, DateTime dtsaida);

        Task<List<Passagem>> ObterPassagemPeriodoMensalista(DateTime dtentrada, DateTime dtsaida);

        Task<List<Passagem>> ObterPassagemPeriodoAvulso(DateTime dtentrada, DateTime dtsaida);

        Task<List<Passagem>> ObterVeiculosGaragem();

        Task<List<Passagem>> ObterVeicuCheckOutlosGaragem();


    }
}
