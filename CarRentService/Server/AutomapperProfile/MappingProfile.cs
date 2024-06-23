using AutoMapper;
using CarRentService.Shared.DTOs;
using CarRentService.Server.Models;

namespace CarRentService.Server.AutomapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<Models.Client, ClientDTO>().ReverseMap();
            CreateMap<Fine, FineDTO>().ReverseMap();
            CreateMap<RentedCar, RentedCarDTO>().ReverseMap();
            CreateMap<Models.Client, ShortClientDTO>().ReverseMap();
        }
    }
}
