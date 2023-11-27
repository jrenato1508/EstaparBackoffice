using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Bussinees.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.business.Interfaces
{
    public interface IFormaPagamentoRepository : IRepository<FormaPagamento>
    {
        Task<FormaPagamento> ObterFormaPagamentoPorId(Guid id);
        Task<FormaPagamento> ObterFormaPagamentoPorSigla(string codigo);
    }
}
