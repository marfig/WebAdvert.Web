using AutoMapper;
using AdvertApi.Models;

namespace WebAdvert.Web.ServiceClients
{
    public class AdvertApiProfile: Profile
    {
        public AdvertApiProfile()
        {
            CreateMap<AdvertModel, CreateAdvertApiModel>().ReverseMap();
            CreateMap<CreateAdvertResponse, AdvertResponse>().ReverseMap();
            CreateMap<ConfirmAdvertModel, ConfirmAdvertRequest>().ReverseMap();
        }
    }
}
