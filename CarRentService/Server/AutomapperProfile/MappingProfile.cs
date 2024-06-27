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
            CreateMap<Fine, FineDTO>().ReverseMap();

            CreateMap<RentedCar, RentedCarDTO>().ReverseMap();
            CreateMap<RentedCar, RentedCarRequestDTO>().ReverseMap();

            CreateMap<DAL.Models.Client, ShortClientDTO>().ReverseMap();
            CreateMap<DAL.Models.Client, ClientDTO>().ReverseMap();
            CreateMap<DAL.Models.Client, ClientRequestDTO>().ReverseMap();

            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<Car, CardCarDTO>().ReverseMap();
            CreateMap<Car, CarData>().ReverseMap();
            CreateMap<CarDTO, CarData>().ReverseMap();
        }
    }
}
