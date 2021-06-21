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
            
            CreateMap<GymService, GymServiceDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Payroll, PayrollDto>().ReverseMap();
            CreateMap<ExcerciseMachine, ExcerciseMachineDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<LoginProfile, LoginProfileDto>().ReverseMap();
            CreateMap<PayrollGeneration, PayrollGenerationDto>().ReverseMap();
            CreateMap<GymWeek, GymWeekDto>().ForMember(x => x.startingDate,
                    opt => opt.MapFrom(src => ((DateTime)src.startingDate).ToShortDateString()))
                                            .ForMember(x => x.finishingDate,
                    opt => opt.MapFrom(src => ((DateTime)src.finishingDate).ToShortDateString()))
                                            .ForMember(x => x.startingDateToCopy,
                    opt => opt.MapFrom(src => ((DateTime)src.startingDateToCopy).ToShortDateString()))
                                            .ForMember(x => x.finishingDateToCopy,
                    opt => opt.MapFrom(src => ((DateTime)src.finishingDateToCopy).ToShortDateString()))
                    .ReverseMap();
            
            CreateMap<GymClass, GymClassDto>().ForMember(x => x.date,
                    opt => opt.MapFrom(src => ((DateTime)src.date).ToShortDateString()))
                .ForMember(x => x.startTime,
                    opt=> opt.MapFrom(src => ((DateTime)src.startTime).ToShortTimeString()))
                .ForMember(x => x.endTime,
                    opt=> opt.MapFrom(src => ((DateTime)src.endTime).ToShortTimeString()))
                    .ReverseMap();

            CreateMap<ClassFilter, ClassFilterDto>().ForMember(x => x.date,
                    opt => opt.MapFrom(src => ((DateTime)src.date).ToShortDateString()))
                .ForMember(x => x.startTime,
                    opt=> opt.MapFrom(src => ((DateTime)src.startTime).ToShortTimeString()))
                .ForMember(x => x.endTime,
                    opt=> opt.MapFrom(src => ((DateTime)src.endTime).ToShortTimeString()))
                    .ReverseMap();
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
            CreateMap<Client, ClientDto>()
            .ForMember(x => x.birthday,
                    opt => opt.MapFrom(src => ((DateTime)src.birthday).ToShortDateString()))
            .ReverseMap();
        }
    }

}