using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Employee entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public EmployeesController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/employees
        //This request returns a list of Employee entities in a JSON format representing the employees database.
        [HttpGet]
        public ActionResult <IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var employeesItem = _repository.GetAllEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeesItem));
        }

        //GET api/employees/{idCard}
        //This request returns a single Employee entity in a JSON format. This entity has the same idCard
        //as the received in the request header.
        [HttpGet("{idCard}", Name = "GetEmployeeByIdCard")]
        public ActionResult <EmployeeDto> GetEmployeeByIdCard(int idCard)
        {
            var employeeModel = _repository.GetEmployeeByIdCard(idCard);
            if(employeeModel != null){
                return Ok(_mapper.Map<EmployeeDto>(employeeModel));
            }
            return NotFound();
        }

        //POST api/employees
        //This request receives all the needed info to create a new Employee in the employees database.
        [HttpPost]
        public ActionResult <EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
            var employeeModel = _mapper.Map<Employee>(employeeDto);
            _repository.CreateUpdateDeleteEmployee(employeeModel, "INSERT");
            var newEmployeeDto = _mapper.Map<EmployeeDto>(employeeModel);

            return CreatedAtRoute(nameof(GetEmployeeByIdCard), new {idCard = newEmployeeDto.idCard}, 
                                newEmployeeDto);
        }


        //PUT api/employees
        //This request receives all the needed info to modify an existing Employee in the employees database.
        [HttpPut("{idCard}")]
        public ActionResult UpdateEmployee(int idCard, EmployeeDto employeeDto)
        {
            var employeeFromRepo = _repository.GetEmployeeByIdCard(idCard);
            employeeDto.idCard = employeeFromRepo.idCard;
            if(employeeFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeDto, employeeFromRepo);
            _repository.CreateUpdateDeleteEmployee(employeeFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/employee/
        //This request deletes the Employee entity with the idCard received in the request header.
        [HttpDelete("{idCard}")]
        public ActionResult DeleteEmployee(int idCard)
        {
            var employeeFromRepo = _repository.GetEmployeeByIdCard(idCard);
            if(employeeFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeleteEmployee(employeeFromRepo, "DELETE");
            return NoContent();
        }

    }
}