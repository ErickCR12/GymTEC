using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Spa Treatment entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class SpasController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public SpasController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/spas
        //This request returns a list of GymService entities in a JSON format representing the Spa Treatment database.
        [HttpGet]
        public ActionResult <IEnumerable<GymServiceDto>> GetAllSpaTreatments()
        {
            var spaTreatmentsItem = _repository.GetAllSpaTreatments();
            return Ok(_mapper.Map<IEnumerable<GymServiceDto>>(spaTreatmentsItem));
        }

        //GET api/spas/{id}
        //This request returns a single Spa Treatment entity in a JSON format. This entity has the same id
        //as the received in the request header.
        [HttpGet("{id}", Name = "GetSpaTreatmentById")]
        public ActionResult <GymServiceDto> GetSpaTreatmentById(int id)
        {
            var spaTreatmentModel = _repository.GetSpaTreatmentById(id);
            if(spaTreatmentModel != null){
                return Ok(_mapper.Map<GymServiceDto>(spaTreatmentModel));
            }
            return NotFound();
        }

        //POST api/spas
        //This request receives all the needed info to create a new Spa Treatment in the Spa Treatment database.
        [HttpPost]
        public ActionResult <GymServiceDto> CreateSpaTreatment(GymServiceDto spaTreatmentDto)
        {
            var spaTreatmentModel = _mapper.Map<GymService>(spaTreatmentDto);
            _repository.CreateUpdateDeleteSpaTreatment(spaTreatmentModel, "INSERT");
            var newSpaTreatmentDto = _mapper.Map<GymServiceDto>(spaTreatmentModel);

            return CreatedAtRoute(nameof(GetSpaTreatmentById), new {id = newSpaTreatmentDto.id}, 
                                newSpaTreatmentDto);
        }


        //PUT api/spas/{id}
        //This request receives all the needed info to modify an existing Spa Treatment in the database.
        [HttpPut("{id}")]
        public ActionResult UpdateSpaTreatment(int id, GymServiceDto spaTreatmentDto)
        {
            var spaTreatmentFromRepo = _repository.GetSpaTreatmentById(id);
            spaTreatmentDto.id = spaTreatmentFromRepo.id;
            if(spaTreatmentFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(spaTreatmentDto, spaTreatmentFromRepo);
            _repository.CreateUpdateDeleteSpaTreatment(spaTreatmentFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/spas/{id}
        //This request deletes the Gym entity with the id received in the request header.
        [HttpDelete("{id}")]
        public ActionResult DeleteSpaTreatment(int id)
        {
            var spaTreatmentFromRepo = _repository.GetSpaTreatmentById(id);
            if(spaTreatmentFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeleteSpaTreatment(spaTreatmentFromRepo, "DELETE");
            return NoContent();
        }

    }
}