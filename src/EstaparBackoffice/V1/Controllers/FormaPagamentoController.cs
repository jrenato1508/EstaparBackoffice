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
using Microsoft.Extensions.Caching.Memory;

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
        private readonly IMemoryCache _memoryCache;
        private const string FORMA_DE_PAGAMENTOS_KEY = "FORMAPAGAMENTOS";

        public FormaPagamentoController(IMapper mapper,
                                        IFormaPagamentoRepository repository,
                                        IMemoryCache memoryCache,
                                        INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _FormaPagamentoRepository = repository;
            _memoryCache = memoryCache;
        }

        [HttpGet("Obter-forma-pagamento")]
        public async Task<IEnumerable<FormasPagamentoViewModel>> ObterTodos()
        {
            #region _memoryCache 
            /*
             * Explicação na Class ApiConfig, region AddMemoryCache - Adicionando o Cahce de Memoria
             * 
             Checa se existe esse dado(FORMA_DE_PAGAMENTOS_KEY que representa o Ienumerable FormasPagamentoViewModel) alocado na memoria,
             se existir ele irá retornar os dados sem a necessidade de ir ao banco de dados, caso não exista ele irá consutar no banco de
             dados e depois de consutar, vamos adicionar essa consulta ao cache na memoria através do  _memoryCache.Set(FORMA_DE_PAGAMENTOS_KEY, formaPagamento);
             
             AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600) - Tempos de expiração, ou seja, quando se passar 3600 segundos o
             cache será liberado(desalovado) da memória, o que forçará uma nova consulta ao banco de dados depois desse tempos.

             SlidingExpiration = TimeSpan.FromSeconds(1200) - Caso se passe 1200 segundos sem ninguém consultar a action, o cache será
             liberado(desalocado) da memória.
             */
            #endregion

            if (_memoryCache.TryGetValue(FORMA_DE_PAGAMENTOS_KEY, out IEnumerable<FormasPagamentoViewModel> formaPagamento))
            {
                return formaPagamento;
            }
            
            formaPagamento = _mapper.Map<IEnumerable< FormasPagamentoViewModel>>(await _FormaPagamentoRepository.ObterTodos());

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600), 
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };

            // Adicionar a consulta a memoria cache
            _memoryCache.Set(FORMA_DE_PAGAMENTOS_KEY, formaPagamento, memoryCacheEntryOptions);

            return formaPagamento;
            //return _mapper.Map<IEnumerable<FormasPagamentoViewModel>>(await _FormaPagamentoRepository.ObterTodos());

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
