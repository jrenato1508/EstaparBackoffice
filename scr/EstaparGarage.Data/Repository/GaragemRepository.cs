using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Bussinees.Models;
using EstaparGarage.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Data.Repository
{
    public class GaragemRepository : Repository<Garagem>, IGaragemRepository
    {
        public GaragemRepository(EstaparDbcontext db) : base(db)
        {
        }

        public async Task<Garagem> ObeterGaragemPorId(Guid id)
        {
            return await _context.Garagens.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Garagem> ObterGaragemPorCodigo(string codigo)
        {
            return await _context.Garagens.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public async Task<Garagem> ObterGaragemPorNome(string nome)
        {
            return await _context.Garagens.AsNoTracking().FirstOrDefaultAsync(x => x.Nome == nome);
        }
    }
}
