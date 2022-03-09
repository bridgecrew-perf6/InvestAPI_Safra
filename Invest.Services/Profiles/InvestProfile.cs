using AutoMapper;
using Invest.Entities.Models;
using Invest.Services.ViewModel;

namespace Invest.Services.Profiles
{
    public class InvestProfile : Profile
    {
        public InvestProfile()
        {
            CreateMap<Acao, AcaoVM>().ReverseMap();
        }
    }
}
