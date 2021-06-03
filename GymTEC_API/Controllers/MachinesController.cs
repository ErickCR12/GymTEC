using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Machine Treatment entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public MachinesController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/machines
        //This request returns a list of ExcerciseMachine entities in a JSON format representing the Machine Treatment database.
        [HttpGet]
        public ActionResult <IEnumerable<ExcerciseMachineDto>> GetAllMachines()
        {
            var machinesItem = _repository.GetAllMachines();
            return Ok(_mapper.Map<IEnumerable<ExcerciseMachineDto>>(machinesItem));
        }

        //GET api/machines/{serialNumber}
        //This request returns a single Machine Treatment entity in a JSON format. This entity has the same serialNumber
        //as the received in the request header.
        [HttpGet("{serialNumber}", Name = "GetMachineBySerialNumber")]
        public ActionResult <ExcerciseMachineDto> GetMachineBySerialNumber(int serialNumber)
        {
            var machineModel = _repository.GetMachineBySerialNumber(serialNumber);
            if(machineModel != null){
                return Ok(_mapper.Map<ExcerciseMachineDto>(machineModel));
            }
            return NotFound();
        }

        //POST api/machines
        //This request receives all the needed info to create a new Machine Treatment in the Machine Treatment database.
        [HttpPost]
        public ActionResult <ExcerciseMachineDto> CreateMachine(ExcerciseMachineDto machineDto)
        {
            var machineModel = _mapper.Map<ExcerciseMachine>(machineDto);
            _repository.CreateUpdateDeleteMachine(machineModel, "INSERT");
            var newMachineDto = _mapper.Map<ExcerciseMachineDto>(machineModel);

            return CreatedAtRoute(nameof(GetMachineBySerialNumber), new {serialNumber = newMachineDto.serialNumber}, 
                                newMachineDto);
        }


        //PUT api/machines/{serialNumber}
        //This request receives all the needed info to modify an existing Machine Treatment in the database.
        [HttpPut("{serialNumber}")]
        public ActionResult UpdateMachine(int serialNumber, ExcerciseMachineDto machineDto)
        {
            var machineFromRepo = _repository.GetMachineBySerialNumber(serialNumber);
            machineDto.serialNumber = machineFromRepo.serialNumber;
            if(machineFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(machineDto, machineFromRepo);
            _repository.CreateUpdateDeleteMachine(machineFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/machines/{serialNumber}
        //This request deletes the Machine Treatment entity with the serialNumber received in the request header.
        [HttpDelete("{serialNumber}")]
        public ActionResult DeleteMachine(int serialNumber)
        {
            var machineFromRepo = _repository.GetMachineBySerialNumber(serialNumber);
            if(machineFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeleteMachine(machineFromRepo, "DELETE");
            return NoContent();
        }

    }
}