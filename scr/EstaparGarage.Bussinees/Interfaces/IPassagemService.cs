using EstaparGarage.Bussinees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Bussinees.Interfaces
{
    public interface IPassagemService : IDisposable
    {
        Task Adicionar(Passagem passagem);

        Task Atualizar(Passagem passagem);

        Task Remover(Guid id);

    }
}
