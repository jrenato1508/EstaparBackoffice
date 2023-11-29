using EstaparGarage.business.Interfaces;
using EstaparGarage.business.Models.Validations;
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Bussinees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.business.Services
{
    public class GarageService : BaseService, IGaragemService
    {
        private readonly IGaragemRepository _garagemrepository;

        public GarageService(IGaragemRepository garagemrepository,
                             INotificador notificador) : base(notificador)
        {
            _garagemrepository = garagemrepository;
            
        }


        public async Task Adicionar(Garagem garagem)
        {
            if (!ExecutarValidacao(new GaragemValidation(), garagem)) return;

            if(_garagemrepository.Buscar(g=>g.Codigo == garagem.Codigo).Result.Any() ||
                _garagemrepository.Buscar(g => g.Id == garagem.Id).Result.Any())
            {
                Notificar("Já Existe uma garagem com esse código");
                return;
            }

            await _garagemrepository.Adicionar(garagem);

        }

        public async Task Atualizar(Garagem garagem)
        {
            if (!ExecutarValidacao(new GaragemValidation(), garagem)) return;

            if (_garagemrepository.Buscar(g => g.Codigo == garagem.Codigo).Result.Any())
            {
                Notificar("Já Existe um ID o Código de garagem cadastrado com o valor informado");
                return;
            }

            await _garagemrepository.Atualizar(garagem);
        }


        public async Task Remover(Guid id)
        {
            var garagem = _garagemrepository.ObterPorId(id);
            if (garagem ==null)
            {
                Notificar("Garagem não encontrada");
                return;
            }
            await _garagemrepository.Remover(id);
        }

        public void Dispose()
        {
            _garagemrepository?.Dispose();
        }
    }
}
