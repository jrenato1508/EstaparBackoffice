
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Bussinees.Models;
using EstaparGarage.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EstaparGarage.Data.Repository
{
    public class PassagemRepository : Repository<Passagem> , IPassagemRepository
    {
        public PassagemRepository(EstaparDbcontext db) : base(db) { }

        public async Task<Passagem> ObterPassagemPorCodigoGaragem(string codigo)
        {
            return await _context.Passagens.AsNoTracking().FirstOrDefaultAsync(c => c.NomeGaragem == codigo);
        }

        public async Task<Passagem> ObterPassagemPorId(Guid id)
        {
            return await _context.Passagens.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Passagem> ObterPassagemPorPlavaVeiculo(string placa)
        {
            return await _context.Passagens.AsNoTracking().FirstOrDefaultAsync(c => c.CarroPlaca == placa);
        }


        // Falta criar as interfaces de PassagemRepository, GaragemRepositoy e FormaDePagamentoRepository e aplica-las. Ainda não criei 
    }
}
