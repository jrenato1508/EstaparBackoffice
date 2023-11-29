
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Bussinees.Models;
using EstaparGarage.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstaparGarage.Data.Repository
{
    public class PassagemRepository : Repository<Passagem> , IPassagemRepository
    {
        public PassagemRepository(EstaparDbcontext db) : base(db) { }

        public async Task<List<Passagem>> ObterPassagemPeriodo(DateTime dtentrada, DateTime dtsaida)
        {
            return await _context.Passagens.AsNoTracking().
                Where(p => p.DataHoraEntrada >= dtentrada && p.DataHoraSaida <= dtsaida).ToListAsync();
                                         
        }

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

        public async Task<List<Passagem>> ObterVeiculosGaragem()
        {
            return await _context.Passagens.AsNoTracking().Where(p=>p.DataHoraSaida == null).ToListAsync();
                
        }

        public async Task<List<Passagem>> ObterVeicuCheckOutlosGaragem()
        {
            return await _context.Passagens.AsNoTracking().Where(p => p.DataHoraSaida != null).ToListAsync();

        }

        public async Task<List<Passagem>> ObterPassagemPeriodoMensalista(DateTime dtentrada, DateTime dtsaida)
        {
            return await _context.Passagens.AsNoTracking().
               Where(p => p.DataHoraEntrada >= dtentrada && p.DataHoraSaida <= dtsaida && p.FormaPagamento=="MEN").ToListAsync();
        }

        public async Task<List<Passagem>> ObterPassagemPeriodoAvulso(DateTime dtentrada, DateTime dtsaida)
        {
            return await _context.Passagens.AsNoTracking().
               Where(p => p.DataHoraEntrada >= dtentrada && p.DataHoraSaida <= dtsaida && p.FormaPagamento != "MEN").ToListAsync();
        }

        
    }
}
