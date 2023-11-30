using AutoMapper;
using EstaparBackoffice.Controllers;
using EstaparBackoffice.DTO;
using EstaparGarage.business.Interfaces;
using EstaparGarage.Bussinees.Interfaces;
using EstaparGarage.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstaparBackoffice.V1.Controllers
{
    [Authorize]
    [Route("api/Tempo-medio-veiculo")]
    public class TempoMedioController : MainController
    {
        public readonly IPassagemRepository _passagemrepository;
        public readonly IMapper _mapper;

        public TempoMedioController(IPassagemRepository passagem,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _passagemrepository = passagem;
        }

        [HttpGet("Mensalistas")]
        public async Task<IEnumerable<PassagemViewModel>> ObterPassagemPeriodoMensalista(DateTime DataEntrada, DateTime DataSaida)
        {
            return _mapper.Map<IEnumerable<PassagemViewModel>>(await _passagemrepository.ObterPassagemPeriodoMensalista(DataEntrada, DataSaida));
        }

        [HttpGet("Avulsos")]
        public async Task<IEnumerable<PassagemViewModel>> ObterPassagemPeriodoAvulso(DateTime DataEntrada, DateTime DataSaida)
        {

            return _mapper.Map<IEnumerable<PassagemViewModel>>(await _passagemrepository.ObterPassagemPeriodoAvulso(DataEntrada, DataSaida));

        }
    }
}
