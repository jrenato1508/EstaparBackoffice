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

namespace EstaparBackoffice.V1.Controllers
{
    [Authorize]
    [ClaimsAuthorize("stapar", "admin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Passagem")]
    public class PassagemController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IPassagemRepository _passagemRepository;
        private readonly IPassagemService _passagemService;

        public PassagemController(IMapper mapper,
                                  IPassagemRepository passagemrepository,
                                  IPassagemService passagem,
                                  INotificador notificador) : base(notificador)
        {
            _mapper= mapper;
            _passagemRepository= passagemrepository;
            _passagemService= passagem;
        }

        [HttpGet("Obter-Todos")]
        public async Task<IEnumerable<PassagemViewModel>> ObterTodos()
        {

            return _mapper.Map<IEnumerable<PassagemViewModel>>(await _passagemRepository.ObterTodos());

        }

        [HttpGet("Obter-por-{id}")]
        public async Task<ActionResult<PassagemViewModel>> ObterPorId(Guid id)
        {
            var Passagem = await ObterPassagemId(id);

            if (Passagem == null)
            {
               NotificarErro("Passagem não encontrada para o ID informado");
               return CustomResponse();
            }
            
            return CustomResponse(Passagem);
        }


        [HttpPost("Nova-passagem")]
        public async Task<ActionResult<PassagemViewModel>> Adicionar(PassagemViewModel passagemViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _passagemService.Adicionar(_mapper.Map<Passagem>(passagemViewModel));

            return CustomResponse(passagemViewModel);
        }

        private async Task<PassagemViewModel> ObterPassagemId(Guid id)
        {

            return _mapper.Map<PassagemViewModel>(await _passagemRepository.ObterPorId(id));
        }

      
    }
}
