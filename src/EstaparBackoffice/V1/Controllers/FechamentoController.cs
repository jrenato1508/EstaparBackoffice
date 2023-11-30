using AutoMapper;
using EstaparBackoffice.Controllers;
using EstaparBackoffice.DTO;
using EstaparGarage.business.Interfaces;
using EstaparGarage.Bussinees.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstaparBackoffice.V1.Controllers
{
    [Authorize]
    [Route("api/Fechamento")]
    public class FechamentoController : MainController
    {
        private readonly IGaragemRepository _garagemRepository;
        private readonly IPassagemRepository _passagemRepository;
        private readonly IMapper _mapper;

        public FechamentoController(IGaragemRepository garagem,
                                    IPassagemRepository passagem,
                                    IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _garagemRepository = garagem;
            _passagemRepository = passagem;
            _mapper = mapper;
        }

        [HttpGet("obter-por-placa{placa}")]
        public async Task<ActionResult<PassagemViewModel>> Fechamento(string placa)
        {
            if (placa == null)
            {
                NotificarErro("Insira uma placa para consulta");
                return CustomResponse();
            }
            
            PassagemViewModel passagem = await ObterEntradasESaidas(placa);
            if (passagem == null)
            {
                NotificarErro("Veiculo não Encontrado para a placa informada");
                return CustomResponse();
            }
                       
            GaragemViewModel garagem = await ObterGaragemPorCodigo(passagem.NomeGaragem);
            Contabilizar(passagem, garagem);

            return CustomResponse(passagem);

        }

        private async Task<PassagemViewModel> ObterEntradasESaidas(string placa)
        {
            return _mapper.Map<PassagemViewModel>(await _passagemRepository.ObterPassagemPorPlavaVeiculo(placa));
        }

        private async Task<GaragemViewModel> ObterGaragemPorCodigo(string codigo)
        {
            return _mapper.Map<GaragemViewModel>(await _garagemRepository.ObterGaragemPorCodigo(codigo));
        }

        private void Contabilizar(PassagemViewModel passagem, GaragemViewModel garagem)
        {
            TimeSpan diferenca = passagem.DataHoraSaida - passagem.DataHoraEntrada;

            int horas = diferenca.Hours;
            int minutos = diferenca.Minutes;
            string formapagamento = passagem.FormaPagamento;
            decimal ValorTotal;

           if(formapagamento == "MEN")
            {
                ValorTotal = garagem.Preco_Mensalista;
            }
            else
            {
                ValorTotal = horas * garagem.Preco_1aHora;
                if( minutos <= 30)
                {
                    ValorTotal +=  2/garagem.Preco_HorasExtra;
                }
                else
                {
                    ValorTotal += garagem.Preco_HorasExtra;
                }
            }

            passagem.PrecoTotal = ValorTotal;
        }
    }
}
