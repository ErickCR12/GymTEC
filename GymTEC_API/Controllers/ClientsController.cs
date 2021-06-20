using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Client entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMongoRepo _mongoRepo;
        private readonly ISQLRepo _sqlRepo;
        private readonly IMapper _mapper;

        public ClientsController (IMongoRepo mongoRepo, ISQLRepo sqlRepo, IMapper mapper)
        {
            _mongoRepo = mongoRepo;
            _sqlRepo = sqlRepo;
            _mapper = mapper;
        }        

        //GET api/clients
        //This request returns a list of Client entities in a JSON format representing the clients database.
        [HttpGet]
        public ActionResult <IEnumerable<ClientDto>> GetAllClients()
        {
            var clientsItem = _mongoRepo.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientsItem));
        }

        //GET api/clients/{idCard}
        //This request returns a single Client entity in a JSON format. This entity has the same idCard
        //as the received in the request header.
        [HttpGet("{idCard}", Name = "GetClientByIdCard")]
        public ActionResult <ClientDto> GetClientByIdCard(int idCard)
        {
            var clientModel = _mongoRepo.GetClientByIdCard(idCard);
            if(clientModel != null){
                return Ok(_mapper.Map<ClientDto>(clientModel));
            }
            return NotFound();
        }

        //POST api/clients
        //This request receives all the needed info to create a new Client in the clients database.
        [HttpPost]
        public ActionResult <ClientDto> CreateClient(ClientDto clientDto)
        {
            var clientModel = _mapper.Map<Client>(clientDto);
            _mongoRepo.CreateClient(clientModel);
            var newClientDto = _mapper.Map<ClientDto>(clientModel);

            return CreatedAtRoute(nameof(GetClientByIdCard), new {idCard = newClientDto.idCard}, 
                                newClientDto);
        }

        //POST api/clients/registerToClass
        //This request receives all the needed info to create a new Client in the clients database.
        [HttpPost("registerToClass/{id}")]
        public ActionResult <ClientDto> RegisterToClass(ClientDto clientDto, int classId)
        {
            var clientModel = _mapper.Map<Client>(clientDto);
            _sqlRepo.RegisterToClass(clientModel,classId);
            var newClientDto = _mapper.Map<ClientDto>(clientModel);

            return CreatedAtRoute(nameof(GetClientByIdCard), new {idCard = newClientDto.idCard}, 
                                newClientDto);
        }


        //PUT api/clients
        //This request receives all the needed info to modify an existing Client in the clients database.
        [HttpPut("{idCard}")]
        public ActionResult UpdateClient(int idCard, ClientDto clientDto)
        {
            var clientFromRepo = _mongoRepo.GetClientByIdCard(idCard);
            clientDto.idCard = clientFromRepo.idCard;
            if(clientFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(clientDto, clientFromRepo);
            _mongoRepo.UpdateClient(clientFromRepo);

            return NoContent();
        }

        //DELETE api/client/
        //This request deletes the Client entity with the idCard received in the request header.
        [HttpDelete("{idCard}")]
        public ActionResult DeleteClient(int idCard)
        {
            var clientFromRepo = _mongoRepo.GetClientByIdCard(idCard);
            if(clientFromRepo == null)
            {
                return NotFound();
            }
            _mongoRepo.DeleteClient(clientFromRepo);
            return NoContent();
        }

    }
}