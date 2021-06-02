using AutoMapper;
using GymTEC_API.Models;
using GymTEC_API.DTOs;
using System;

namespace WebServiceResTEC.Profiles
{

    //This class set all the available mapping for the data models of the database.
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<GymService, GymServiceDto>().ReverseMap();
            // CreateMap<Distributor, DistributorDto>()
            //     .ForMember(s => s.legal_card, c => c.MapFrom(m => m.legal_card))
            //     .ForMember(s => s.devices, c => c.MapFrom(m => m.devices_))
            //     .ReverseMap();
            CreateMap<Gym, GymDto>()
                .ForMember(x => x.openingDate,
                    opt => opt.MapFrom(src => ((DateTime)src.openingDate).ToShortDateString()))
                .ForMember(x => x.openingTime,
                    opt=> opt.MapFrom(src => ((DateTime)src.openingTime).ToShortTimeString()))
                .ForMember(x => x.closingTime,
                    opt=> opt.MapFrom(src => ((DateTime)src.closingTime).ToShortTimeString()))
            .ReverseMap();
        }
    }

}