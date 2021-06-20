using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Gym entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public GymsController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/gyms
        //This request returns a list of Gym entities in a JSON format representing the gyms database.
        [HttpGet]
        public ActionResult <IEnumerable<GymDto>> GetAllGyms()
        {
            var gymsItem = _repository.GetAllGyms();
            return Ok(_mapper.Map<IEnumerable<GymDto>>(gymsItem));
        }

        //GET api/gyms/{id}
        //This request returns a single Gym entity in a JSON format. This entity has the same id
        //as the received in the request header.
        [HttpGet("{id}", Name = "GetGymById")]
        public ActionResult <GymDto> GetGymById(int id)
        {
            var gymModel = _repository.GetGymById(id);
            if(gymModel != null){
                return Ok(_mapper.Map<GymDto>(gymModel));
            }
            return NotFound();
        }

        //POST api/gyms
        //This request receives all the needed info to create a new Gym in the gyms database.
        [HttpPost]
        public ActionResult <GymDto> CreateGym(GymDto gymDto)
        {
            var gymModel = _mapper.Map<Gym>(gymDto);
            _repository.CreateUpdateDeleteGym(gymModel, "INSERT");
            var newGymDto = _mapper.Map<GymDto>(gymModel);

            return CreatedAtRoute(nameof(GetGymById), new {id = newGymDto.id}, 
                                newGymDto);
        }


        //PUT api/gyms
        //This request receives all the needed info to modify an existing Gym in the gyms database.
        [HttpPut("{id}")]
        public ActionResult UpdateGym(int id, GymDto gymDto)
        {
            var gymFromRepo = _repository.GetGymById(id);
            gymDto.id = gymFromRepo.id;
            if(gymFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(gymDto, gymFromRepo);
            _repository.CreateUpdateDeleteGym(gymFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/gym/
        //This request deletes the Gym entity with the id received in the request header.
        [HttpDelete("{id}")]
        public ActionResult DeleteGym(int id)
        {
            var gymFromRepo = _repository.GetGymById(id);
            if(gymFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeleteGym(gymFromRepo, "DELETE");
            return NoContent();
        }

        //POST api/gyms/admin/{id}
        //This request receives all the needed info to create a new Gym in the gyms database.
        [HttpPost("admin/{gymId}")]
        public ActionResult AddAdmin(EmployeeDto employeeDto, int gymId)
        {
            Console.WriteLine(gymId);
            var employeeModel = _mapper.Map<Employee>(employeeDto);
            _repository.AddAdmin(employeeModel, gymId);

            return Ok();
        }
    }
}