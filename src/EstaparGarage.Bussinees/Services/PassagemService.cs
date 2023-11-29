using EstaparGarage.business.Interfaces;
using EstaparGarage.business.Models.Validations;
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Bussinees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.business.Services
{
    public class PassagemService : BaseService, IPassagemService
    {
        private readonly IPassagemRepository _PassagemRepository;

        public PassagemService(IPassagemRepository passagem,
                               INotificador notificador) : base(notificador)
        {
            _PassagemRepository = passagem;
        }

        public async Task Adicionar(Passagem passagem)
        {
            if (!ExecutarValidacao(new PassagemValidation(), passagem)) return;

            if(_PassagemRepository.Buscar(p=> p.Id == passagem.Id).Result.Any())
            {
                Notificar("Já existe um registro de passagem com esse ID");
                return;
            }

            await _PassagemRepository.Adicionar(passagem);
        }

        public Task Atualizar(Passagem passagem)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _PassagemRepository?.Dispose();
        }
    }
}
