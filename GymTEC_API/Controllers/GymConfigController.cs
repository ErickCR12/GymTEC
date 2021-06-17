using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Gym configurations. This Controller allows multiple POST request to create relations between entities.
    [Route("api/[controller]")]
    [ApiController]
    public class GymConfigController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public GymConfigController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        


        //POST api/gymConfig/spaTreatments/{gymId}
        //This request a list of spa treatment (GymService) to create a relation with the specified gym.
        [HttpPost("spaTreatments/{gymId}", Name = "SetSpaTreatmentsToGym")]
        public ActionResult <IEnumerable<GymServiceDto>> SetSpaTreatmentsToGym(IEnumerable<GymServiceDto> spaTreatmentDto, int gymId)
        {
            var spaTreatments = _mapper.Map<IEnumerable<GymService>>(spaTreatmentDto);
            _repository.SetSpaTreatmentsToGym(spaTreatments, gymId);

            return Ok(_mapper.Map<IEnumerable<GymServiceDto>>(spaTreatments));
        }

        //POST api/gymConfig/products/{gymId}
        //This request a list of products to create a relation with the specified gym.
        [HttpPost("products/{gymId}", Name = "SetProductsToGym")]
        public ActionResult <IEnumerable<ProductDto>> SetProductsToGym(IEnumerable<ProductDto> productDtos, int gymId)
        {
            var products = _mapper.Map<IEnumerable<Product>>(productDtos);
            _repository.SetProductsToGym(products, gymId);

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        //POST api/gymConfig/machines/{gymId}
        //This request a list of machines to create a relation with the specified gym.
        [HttpPost("machines/{gymId}", Name = "SetMachinesToGym")]
        public ActionResult <IEnumerable<ExcerciseMachineDto>> SetMachinesToGym(IEnumerable<ExcerciseMachineDto> machineDtos, int gymId)
        {
            var machines = _mapper.Map<IEnumerable<ExcerciseMachine>>(machineDtos);
            _repository.SetMachinesToGym(machines, gymId);

            return Ok(_mapper.Map<IEnumerable<ExcerciseMachineDto>>(machines));
        }

        //POST api/gymConfig/copyWeeks/{gymId}
        //This request receives a week to be copied to another week of the specified gym
        [HttpPost("copyWeeks/{gymId}", Name = "CopyGymWeek")]
        public ActionResult <GymWeekDto> CopyGymWeek(GymWeekDto weekDto, int gymId)
        {
            var week = _mapper.Map<GymWeek>(weekDto);
            _repository.CopyGymWeek(week, gymId);

            return Ok(_mapper.Map<GymWeekDto>(week));
        }

        //POST api/gymConfig/copyGym/{gymId}
        //This request receives a week to be copied to another week of the specified gym
        [HttpPost("copyWeeks/{gymId}", Name = "CopyGymWeek")]
        public ActionResult <Gym> CopyGymWeek(Gym originalGymDto, int newGymId)
        {
            var originalGym = _mapper.Map<Gym>(originalGymDto);
            _repository.CopyGym(originalGym, newGymId);

            return Ok(_mapper.Map<Gym>(originalGym));
        }
    }   
}