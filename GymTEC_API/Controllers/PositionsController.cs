using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Positions entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public PositionsController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/positions
        //This request returns a list of GymService entities in a JSON format representing the Position database.
        [HttpGet]
        public ActionResult <IEnumerable<GymServiceDto>> GetAllPositions()
        {
            var positionsItem = _repository.GetAllPositions();
            return Ok(_mapper.Map<IEnumerable<GymServiceDto>>(positionsItem));
        }

        //GET api/positions/{id}
        //This request returns a single Position entity in a JSON format. This entity has the same id
        //as the received in the request header.
        [HttpGet("{id}", Name = "GetPositionById")]
        public ActionResult <GymServiceDto> GetPositionById(int id)
        {
            var positionModel = _repository.GetPositionById(id);
            if(positionModel != null){
                return Ok(_mapper.Map<GymServiceDto>(positionModel));
            }
            return NotFound();
        }

        //POST api/positions
        //This request receives all the needed info to create a new Positon in the database.
        [HttpPost]
        public ActionResult <GymServiceDto> CreatePosition(GymServiceDto positionDto)
        {
            var positionModel = _mapper.Map<GymService>(positionDto);
            _repository.CreateUpdateDeletePosition(positionModel, "INSERT");
            var newPositionDto = _mapper.Map<GymServiceDto>(positionModel);

            return CreatedAtRoute(nameof(GetPositionById), new {id = newPositionDto.id}, 
                                newPositionDto);
        }


        //PUT api/positions/{id}
        //This request receives all the needed info to modify an existing Position in the database.
        [HttpPut("{id}")]
        public ActionResult UpdatePosition(int id, GymServiceDto positionDto)
        {
            var positionFromRepo = _repository.GetPositionById(id);
            positionDto.id = positionFromRepo.id;
            if(positionFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(positionDto, positionFromRepo);
            _repository.CreateUpdateDeletePosition(positionFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/positions/{id}
        //This request deletes the Position entity with the id received in the request header.
        [HttpDelete("{id}")]
        public ActionResult DeletePosition(int id)
        {
            var positionFromRepo = _repository.GetPositionById(id);
            if(positionFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeletePosition(positionFromRepo, "DELETE");
            return NoContent();
        }

    }
}