using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Classes entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public ClassesController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/classes
        //This request returns a list of GymClass entities in a JSON format representing the Class database.
        [HttpGet]
        public ActionResult <IEnumerable<GymClassDto>> GetAllClasses()
        {
            var classesItem = _repository.GetAllClasses();
            return Ok(_mapper.Map<IEnumerable<GymClassDto>>(classesItem));
        }

        //GET api/classes/{id}
        //This request returns a single Class entity in a JSON format. This entity has the same id
        //as the received in the request header.
        [HttpGet("{id}", Name = "GetClassById")]
        public ActionResult <GymClassDto> GetClassById(int id)
        {
            var classModel = _repository.GetClassById(id);
            if(classModel != null){
                return Ok(_mapper.Map<GymClassDto>(classModel));
            }
            return NotFound();
        }

        //POST api/classes
        //This request receives all the needed info to create a new Positon in the database.
        [HttpPost]
        public ActionResult <GymClassDto> CreateClass(GymClassDto classDto)
        {
            var classModel = _mapper.Map<GymClass>(classDto);
            _repository.CreateUpdateDeleteClass(classModel, "INSERT");
            var newClassDto = _mapper.Map<GymClassDto>(classModel);

            return CreatedAtRoute(nameof(GetClassById), new {id = newClassDto.id}, 
                                newClassDto);
        }


        //PUT api/classes/{id}
        //This request receives all the needed info to modify an existing Class in the database.
        [HttpPut("{id}")]
        public ActionResult UpdateClass(int id, GymClassDto classDto)
        {
            var classFromRepo = _repository.GetClassById(id);
            classDto.id = classFromRepo.id;
            if(classFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(classDto, classFromRepo);
            _repository.CreateUpdateDeleteClass(classFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/classes/{id}
        //This request deletes the Class entity with the id received in the request header.
        [HttpDelete("{id}")]
        public ActionResult DeleteClass(int id)
        {
            var classFromRepo = _repository.GetClassById(id);
            if(classFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeleteClass(classFromRepo, "DELETE");
            return NoContent();
        }

    }
}