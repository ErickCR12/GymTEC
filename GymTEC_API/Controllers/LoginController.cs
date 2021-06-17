using GymTEC_API.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GymTEC_API.DTOs;
using GymTEC_API.Models;

namespace WebServiceResTEC.Controllers
{

    //This is an API Controller for validation of the Login credentials. This Controller allows a POST request.
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISQLRepo _sqlRepository;
        private readonly IMongoRepo _mongoRepository;
        private readonly IMapper _mapper;

        public LoginController(ISQLRepo sqlRepository,  IMongoRepo mongoRepository, IMapper mapper)
        {
            _sqlRepository = sqlRepository;
            _mongoRepository = mongoRepository;
            _mapper = mapper;
        }        

        //POST api/login
        //This POST request receives a JSON representing the LoginProfile Data Model. It will return the type of user
        //by checking the username and password in the JSON.
        [HttpPost]
        public ActionResult <LoginProfileDto> CheckCredentials(LoginProfileDto loginDto)
        {
            var loginProfile = _mapper.Map<LoginProfile>(loginDto);
            LoginProfile user = _sqlRepository.CheckCredentials(loginProfile);
            if(user.UserType != "Invalid")
                return Ok(_mapper.Map<LoginProfileDto>(user));
            user = _mongoRepository.CheckCredentials(loginProfile);
            return Ok(_mapper.Map<LoginProfileDto>(user));

        }
    }
}