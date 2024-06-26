﻿using Asp.Versioning;
using AutoMapper;
using EstaparBackoffice.Controllers;
using EstaparBackoffice.DTO;
using EstaparBackoffice.Extensions.ClaimsAuthorize;
using EstaparGarage.business.Interfaces;
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Bussinees.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EstaparBackoffice.V1.Controllers
{
    [Authorize]
    [ClaimsAuthorize("stapar", "admin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Garagem")]
    public class GaragemController : MainController
    {

        private readonly IGaragemRepository _garagemRepository;
        private readonly IGaragemService _garagemService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private const string Garagens_Key = "Garanges";

        public GaragemController(IGaragemRepository garagem,
                                 IGaragemService garagemService,
                                 IMapper mapper,
                                 IMemoryCache memoryCache,
                                 INotificador notificador) : base(notificador)
        {
            _garagemRepository = garagem;
            _garagemService = garagemService;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IEnumerable<GaragemViewModel>> ObterTodos()
        {
            if(_memoryCache.TryGetValue(Garagens_Key, out IEnumerable<GaragemViewModel> garagens))
            {
                return garagens;
            }
            
            garagens = _mapper.Map<IEnumerable<GaragemViewModel>>(await _garagemRepository.ObterTodos());

            var memoryCache = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
                
            };

            _memoryCache.Set(Garagens_Key, garagens, memoryCache);

            return garagens;
            //return _mapper.Map<IEnumerable<GaragemViewModel>>(await _garagemRepository.ObterTodos());

        }

        [HttpGet("Obter-garage-por{id}")]
        public async Task<ActionResult<GaragemViewModel>> ObterPorId(Guid id)
        {
            var garagem = await ObterGaragem(id);
            if(garagem == null)
            {
                NotificarErro("Garagem não encontrada para o id informado");
                return CustomResponse();
            }

            return CustomResponse(garagem);
        }


        [HttpPost("Nova-garagem")]
        public async Task<ActionResult<GaragemViewModel>> Adicionar(GaragemViewModel garagemViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _garagemService.Adicionar(_mapper.Map<Garagem>(garagemViewModel));

            return CustomResponse();
        }


        [HttpPut("Atualizar-garagem {id}")]
        public async Task<IActionResult> Atualizar(Guid id, GaragemViewModel garagemViewModel)
        {
            if (id != garagemViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var garagembanco = await ObterGaragem(id);
            
            if (garagembanco == null)
            {
                NotificarErro("Garagem não encontradada para o id informado");
                return CustomResponse();
            }

            Atualizar(garagembanco, garagemViewModel);

            await _garagemService.Atualizar(_mapper.Map<Garagem>(garagemViewModel));

            return CustomResponse(garagembanco);
        }


        [HttpDelete("Excluir- garagem{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var garagem = await ObterGaragem(id);

            if (garagem == null)
            {
                NotificarErro("Garagem não encontrada para o id informado");
                return CustomResponse();
            }

            await _garagemService.Remover(id);

            return CustomResponse();
        }

        
        private async Task<GaragemViewModel> ObterGaragem(Guid id)
        {
            return _mapper.Map<GaragemViewModel>(await _garagemRepository.ObterPorId(id));
        }

        private void Atualizar(GaragemViewModel garagembanco, GaragemViewModel garagemViewModel)
        {
            garagembanco.Codigo = garagemViewModel.Codigo;
            garagembanco.Nome = garagemViewModel.Nome;
            garagembanco.Preco_1aHora = garagemViewModel.Preco_1aHora;
            garagembanco.Preco_HorasExtra = garagemViewModel.Preco_HorasExtra;
            garagembanco.Preco_Mensalista = garagemViewModel.Preco_Mensalista;
        }
    }
}
