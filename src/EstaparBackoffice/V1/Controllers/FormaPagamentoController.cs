using Asp.Versioning;
using AutoMapper;
using EstaparBackoffice.Controllers;
using EstaparBackoffice.DTO;
using EstaparBackoffice.Extensions.ClaimsAuthorize;
using EstaparGarage.business.Interfaces;
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstaparBackoffice.V1.Controllers
{
    [Authorize]
    [ClaimsAuthorize("stapar", "admin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/FormaPagamento")]
    public class FormaPagamentoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IFormaPagamentoRepository _FormaPagamentoRepository;

        public FormaPagamentoController(IMapper mapper,
                                        IFormaPagamentoRepository repository,
                                 INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _FormaPagamentoRepository= repository;
        }

        [HttpGet("Obter-forma-pagamento")]
        public async Task<IEnumerable<FormasPagamentoViewModel>> ObterTodos()
        {

            return _mapper.Map<IEnumerable<FormasPagamentoViewModel>>(await _FormaPagamentoRepository.ObterTodos());

        }

        [HttpGet("Obter-forma-pagamento-por {id:guid}")]
        public async Task<ActionResult<FormasPagamentoViewModel>> ObterPorId(Guid id)
        {
            var formaDePagamento = await ObterFormaPagamentoPorId(id);
            if(formaDePagamento == null)
            {
                NotificarErro("Forma de Pagamento não Encontrada pada o Id fornecido");
                return CustomResponse();
            }

            return CustomResponse(formaDePagamento);
            
        }

        [HttpGet("obter-por-sigla{sigla}")]
        public async Task<ActionResult<FormasPagamentoViewModel>> ObterPorSigla(string sigla)
        { 
            if(sigla == null)
            {
                NotificarErro("Insira uma sigla para ser consultado");
                return CustomResponse();
            }

            var formaDePagamento = await ObterFormaPagamentoPorSigla(sigla);
            if(formaDePagamento == null)
            {
                NotificarErro("Forma de pagamento não encontrada para sigla informada");
                return CustomResponse();
            }

            return CustomResponse(formaDePagamento);
        }

        private async Task<FormasPagamentoViewModel> ObterFormaPagamentoPorId(Guid id)
        {
            return _mapper.Map<FormasPagamentoViewModel>(await _FormaPagamentoRepository.ObterFormaPagamentoPorId(id));
        }

        private async Task<FormasPagamentoViewModel> ObterFormaPagamentoPorSigla(string sigla)
        {
            return _mapper.Map<FormasPagamentoViewModel>(await _FormaPagamentoRepository.ObterFormaPagamentoPorSigla(sigla));
        }

        
    }
}
