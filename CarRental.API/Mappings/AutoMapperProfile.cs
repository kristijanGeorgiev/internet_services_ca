using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Domain.Entities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
       
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.client != null ? src.client.Id : 0));


        CreateMap<Client, ClientDto>()
           .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Cars))
           .ReverseMap();
    }
}