using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the EquipmentTypes entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypesController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public EquipmentTypesController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/equipmentTypes
        //This request returns a list of GymService entities in a JSON format representing the EquipmentType database.
        [HttpGet]
        public ActionResult <IEnumerable<GymServiceDto>> GetAllEquipmentTypes()
        {
            var equipmentTypesItem = _repository.GetAllEquipmentTypes();
            return Ok(_mapper.Map<IEnumerable<GymServiceDto>>(equipmentTypesItem));
        }

        //GET api/equipmentTypes/{id}
        //This request returns a single EquipmentType entity in a JSON format. This entity has the same id
        //as the received in the request header.
        [HttpGet("{id}", Name = "GetEquipmentTypeById")]
        public ActionResult <GymServiceDto> GetEquipmentTypeById(int id)
        {
            var equipmentTypeModel = _repository.GetEquipmentTypeById(id);
            if(equipmentTypeModel != null){
                return Ok(_mapper.Map<GymServiceDto>(equipmentTypeModel));
            }
            return NotFound();
        }

        //POST api/equipmentTypes
        //This request receives all the needed info to create a new Positon in the database.
        [HttpPost]
        public ActionResult <GymServiceDto> CreateEquipmentType(GymServiceDto equipmentTypeDto)
        {
            var equipmentTypeModel = _mapper.Map<GymService>(equipmentTypeDto);
            _repository.CreateUpdateDeleteEquipmentType(equipmentTypeModel, "INSERT");
            var newEquipmentTypeDto = _mapper.Map<GymServiceDto>(equipmentTypeModel);

            return CreatedAtRoute(nameof(GetEquipmentTypeById), new {id = newEquipmentTypeDto.id}, 
                                newEquipmentTypeDto);
        }


        //PUT api/equipmentTypes/{id}
        //This request receives all the needed info to modify an existing EquipmentType in the database.
        [HttpPut("{id}")]
        public ActionResult UpdateEquipmentType(int id, GymServiceDto equipmentTypeDto)
        {
            var equipmentTypeFromRepo = _repository.GetEquipmentTypeById(id);
            equipmentTypeDto.id = equipmentTypeFromRepo.id;
            if(equipmentTypeFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(equipmentTypeDto, equipmentTypeFromRepo);
            _repository.CreateUpdateDeleteEquipmentType(equipmentTypeFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/equipmentTypes/{id}
        //This request deletes the EquipmentType entity with the id received in the request header.
        [HttpDelete("{id}")]
        public ActionResult DeleteEquipmentType(int id)
        {
            var equipmentTypeFromRepo = _repository.GetEquipmentTypeById(id);
            if(equipmentTypeFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeleteEquipmentType(equipmentTypeFromRepo, "DELETE");
            return NoContent();
        }

    }
}