using AutoMapper;
using EstaparBackoffice.DTO;
using EstaparGarage.Bussinees.Models;

namespace EstaparBackoffice.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Garagem, GaragemViewModel>().ReverseMap();
            CreateMap<FormaPagamento, FormasPagamentoViewModel>().ReverseMap();
            CreateMap<Passagem, PassagemViewModel>().ReverseMap();
                
        }
    }
}
