using AutoMapper;
using EstaparBackoffice.Controllers;
using EstaparBackoffice.DTO;
using EstaparGarage.business.Interfaces;
using EstaparGarage.Bussinees.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstaparBackoffice.V1.Controllers
{
    [Route("api/Veiculos")]
    public class VeiculosController : MainController
    {
        private readonly IPassagemRepository _passagemrepository;
        private readonly IMapper _mapper;

        public VeiculosController(IPassagemRepository passagem,
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _passagemrepository = passagem;    
            _mapper = mapper;
            
        }


        [HttpGet]
        public async Task<IEnumerable<PassagemViewModel>> ObterTodosEntre(DateTime DataEntrada, DateTime DataSaida)
        {
         
            return _mapper.Map<IEnumerable<PassagemViewModel>>(await _passagemrepository.ObterPassagemPeriodo(DataEntrada, DataSaida));
            
        }

        [HttpGet("Obter-Veiculos-Garagem")]
        public async Task<IEnumerable<PassagemViewModel>> ObterVeiculosGaragem()
        {

            return _mapper.Map<IEnumerable<PassagemViewModel>>(await _passagemrepository.ObterVeiculosGaragem());

        }

        [HttpGet("Obter-Veiculos-CheckOut-Garagem")]
        public async Task<IEnumerable<PassagemViewModel>> ObterVeicuCheckOutlosGaragem()
        {

            return _mapper.Map<IEnumerable<PassagemViewModel>>(await _passagemrepository.ObterVeicuCheckOutlosGaragem());

        }
    }
}
