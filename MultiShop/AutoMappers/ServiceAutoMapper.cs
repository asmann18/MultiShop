using AutoMapper;
using MultiShop.Models;
using MultiShop.ViewModels;

namespace MultiShop.AutoMappers;

public class ServiceAutoMapper:Profile
{
    public ServiceAutoMapper()
    {
        CreateMap<Service, ServiceGetVM>().ReverseMap();
        CreateMap<Service, ServicePostVM>().ReverseMap();
        CreateMap<Service, ServicePutVM>().ForMember(x=>x.IconPath,s=>s.Ignore()).ReverseMap();
        CreateMap<ServiceGetVM, ServicePutVM>().ReverseMap();
    }
}
