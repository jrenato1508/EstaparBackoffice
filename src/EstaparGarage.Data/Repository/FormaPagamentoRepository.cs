using EstaparGarage.business.Interfaces;
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
    public class FormaPagamentoRepository : Repository<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(EstaparDbcontext db) : base(db){}

        public async Task<FormaPagamento> ObterFormaPagamentoPorId(Guid id)
        {
            return await _context.FormasPagamento.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FormaPagamento> ObterFormaPagamentoPorSigla(string codigo)
        {
            return await _context.FormasPagamento.AsNoTracking().FirstOrDefaultAsync(c => c.Codigo == codigo);
        }
    }
}
