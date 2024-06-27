using AutoMapper;
using CarRentService.BLL.ExternalAPIResponses;
using CarRentService.DAL.Models;
using CarRentService.Shared.DTOs.Requests;
using CarRentService.Shared.DTOs.Responses;

namespace CarRentService.Server.AutomapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<DAL.Models.Client, ClientDTO>().ReverseMap();
            CreateMap<Fine, FineDTO>().ReverseMap();
            CreateMap<RentedCar, RentedCarDTO>().ReverseMap();
            CreateMap<DAL.Models.Client, ShortClientDTO>().ReverseMap();
            CreateMap<Car, CardCarDTO>().ReverseMap();
            CreateMap<DAL.Models.Client, ClientRequestDTO>().ReverseMap();
            CreateMap<Car, CarData>().ReverseMap();
            CreateMap<CarDTO, CarData>().ReverseMap();
        }
    }
}
