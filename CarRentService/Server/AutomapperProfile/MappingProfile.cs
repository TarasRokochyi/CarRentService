using AutoMapper;
using CarRentService.Server.Models;
using CarRentService.Server.Responses;
using CarRentService.Shared.DTOs.Requests;
using CarRentService.Shared.DTOs.Responses;

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
            CreateMap<Car, CardCarDTO>().ReverseMap();
            CreateMap<Models.Client, ClientRequestDTO>().ReverseMap();
            CreateMap<Car, CarData>().ReverseMap();
            CreateMap<CarDTO, CarData>().ReverseMap();
        }
    }
}
