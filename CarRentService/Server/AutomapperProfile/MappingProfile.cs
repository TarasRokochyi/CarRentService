using AutoMapper;
using CarRentService.Server.DTOs;
using CarRentService.Server.Models;

namespace CarRentService.Server.AutomapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<Models.Client, ClientDTO>();
            CreateMap<Fine, FineDTO>();
            CreateMap<RentedCar, RentedCarDTO>();
        }
    }
}
