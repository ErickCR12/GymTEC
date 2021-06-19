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
        //This request receives a spa treatment (GymService) to create a relation with the specified gym.
        [HttpPost("spaTreatments/{gymId}", Name = "SetSpaTreatmentToGym")]
        public ActionResult <GymServiceDto> SetSpaTreatmentToGym(GymServiceDto spaTreatmentDto, int gymId)
        {
            var spaTreatment = _mapper.Map<GymService>(spaTreatmentDto);
            _repository.SetSpaTreatmentToGym(spaTreatment, gymId);

            return Ok(_mapper.Map<GymServiceDto>(spaTreatment));
        }

        //POST api/gymConfig/products/{gymId}
        //This request receives a product to create a relation with the specified gym.
        [HttpPost("products/{gymId}", Name = "SetProductToGym")]
        public ActionResult <ProductDto> SetProductToGym(ProductDto productDto, int gymId)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.SetProductToGym(product, gymId);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        //POST api/gymConfig/machines/{gymId}
        //This request receives a machine to create a relation with the specified gym.
        [HttpPost("machines/{gymId}", Name = "SetMachineToGym")]
        public ActionResult <ExcerciseMachineDto> SetMachineToGym(ExcerciseMachineDto machineDto, int gymId)
        {
            var machine = _mapper.Map<ExcerciseMachine>(machineDto);
            _repository.SetMachineToGym(machine, gymId);

            return Ok(_mapper.Map<ExcerciseMachineDto>(machine));
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
        [HttpPost("copyGym/{gymId}", Name = "CopyGym")]
        public ActionResult <Gym> CopyGym(Gym originalGymDto, int newGymId)
        {
            var originalGym = _mapper.Map<Gym>(originalGymDto);
            _repository.CopyGym(originalGym, newGymId);

            return Ok(_mapper.Map<Gym>(originalGym));
        }
    }   
}