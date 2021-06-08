using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Service entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public ServicesController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/services
        //This request returns a list of GymService entities in a JSON format representing the Service database.
        [HttpGet]
        public ActionResult <IEnumerable<GymServiceDto>> GetAllServices()
        {
            var servicesItem = _repository.GetAllServices();
            return Ok(_mapper.Map<IEnumerable<GymServiceDto>>(servicesItem));
        }

        //GET api/services/{id}
        //This request returns a single Service entity in a JSON format. This entity has the same id
        //as the received in the request header.
        [HttpGet("{id}", Name = "GetServiceById")]
        public ActionResult <GymServiceDto> GetServiceById(int id)
        {
            var serviceModel = _repository.GetServiceById(id);
            if(serviceModel != null){
                return Ok(_mapper.Map<GymServiceDto>(serviceModel));
            }
            return NotFound();
        }

        //POST api/services
        //This request receives all the needed info to create a new Service in the Service database.
        [HttpPost]
        public ActionResult <GymServiceDto> CreateService(GymServiceDto serviceDto)
        {
            var serviceModel = _mapper.Map<GymService>(serviceDto);
            _repository.CreateUpdateDeleteService(serviceModel, "INSERT");
            var newServiceDto = _mapper.Map<GymServiceDto>(serviceModel);

            return CreatedAtRoute(nameof(GetServiceById), new {id = newServiceDto.id}, 
                                newServiceDto);
        }


        //PUT api/services/{id}
        //This request receives all the needed info to modify an existing Service in the database.
        [HttpPut("{id}")]
        public ActionResult UpdateService(int id, GymServiceDto serviceDto)
        {
            var serviceFromRepo = _repository.GetServiceById(id);
            serviceDto.id = serviceFromRepo.id;
            if(serviceFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(serviceDto, serviceFromRepo);
            _repository.CreateUpdateDeleteService(serviceFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/services/{id}
        //This request deletes the Service entity with the id received in the request header.
        [HttpDelete("{id}")]
        public ActionResult DeleteService(int id)
        {
            var serviceFromRepo = _repository.GetServiceById(id);
            if(serviceFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeleteService(serviceFromRepo, "DELETE");
            return NoContent();
        }

    }
}