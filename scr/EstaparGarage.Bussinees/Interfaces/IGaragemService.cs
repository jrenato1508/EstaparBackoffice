using EstaparGarage.Bussinees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Bussinees.Interfaces
{
    public interface IGaragemService : IDisposable
    {
        Task Adicionar(Garagem garagem);

        Task Atualizar(Garagem garagem);

        Task Remover(Guid id);
    }
}
