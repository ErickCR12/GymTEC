using Microsoft.AspNetCore.Mvc;
using GymTEC_API.Data;
using AutoMapper;
using GymTEC_API.DTOs;
using System.Collections.Generic;
using GymTEC_API.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Payroll entity type. This Controller allows all the CRUD functions.
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollsController : ControllerBase
    {
        private readonly ISQLRepo _repository;
        private readonly IMapper _mapper;

        public PayrollsController (ISQLRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/payrolls
        //This request returns a list of Payroll entities in a JSON format representing the Payroll database.
        [HttpGet]
        public ActionResult <IEnumerable<PayrollDto>> GetAllPayrolls()
        {
            var payrollsItem = _repository.GetAllPayrolls();
            return Ok(_mapper.Map<IEnumerable<PayrollDto>>(payrollsItem));
        }

        //GET api/payrolls/{id}
        //This request returns a single Payroll entity in a JSON format. This entity has the same id
        //as the received in the request header.
        [HttpGet("{id}", Name = "GetPayrollById")]
        public ActionResult <PayrollDto> GetPayrollById(int id)
        {
            var payrollModel = _repository.GetPayrollById(id);
            if(payrollModel != null){
                return Ok(_mapper.Map<PayrollDto>(payrollModel));
            }
            return NotFound();
        }

        //POST api/payrolls
        //This request receives all the needed info to create a new Payroll in the database.
        [HttpPost]
        public ActionResult <PayrollDto> CreatePayrolls(PayrollDto payrollDto)
        {
            var payrollModel = _mapper.Map<Payroll>(payrollDto);
            _repository.CreateUpdateDeletePayroll(payrollModel, "INSERT");
            var newPayrollDto = _mapper.Map<PayrollDto>(payrollModel);

            return CreatedAtRoute(nameof(GetPayrollById), new {id = newPayrollDto.id}, 
                                newPayrollDto);
        }


        //PUT api/payrolls/{id}
        //This request receives all the needed info to modify an existing Payroll in the database.
        [HttpPut("{id}")]
        public ActionResult UpdatePayroll(int id, PayrollDto payrollDto)
        {
            var payrollFromRepo = _repository.GetPayrollById(id);
            payrollDto.id = payrollFromRepo.id;
            if(payrollFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(payrollDto, payrollFromRepo);
            _repository.CreateUpdateDeletePayroll(payrollFromRepo, "UPDATE");

            return NoContent();
        }

        //DELETE api/payrolls/{id}
        //This request deletes the Payroll entity with the id received in the request header.
        [HttpDelete("{id}")]
        public ActionResult DeletePayroll(int id)
        {
            var payrollFromRepo = _repository.GetPayrollById(id);
            if(payrollFromRepo == null)
            {
                return NotFound();
            }
            _repository.CreateUpdateDeletePayroll(payrollFromRepo, "DELETE");
            return NoContent();
        }

        //GET api/payrolls/generateMonthly/{id}
        //This request returns a list of PayrollGeneration entities in a JSON format showing the monthly payroll for a Gym.
        [HttpGet("generateMonthly/{id}")]
        public ActionResult <IEnumerable<PayrollGenerationDto>> GetMonthlyPayroll(int gymId)
        {
            var payrollsItem = _repository.GetMonthlyPayroll(gymId);
            return Ok(_mapper.Map<IEnumerable<PayrollGenerationDto>>(payrollsItem));
        }

        //GET api/payrolls/generatePerClass/{id}
        //This request returns a list of PayrollGeneration entities in a JSON format showing the payroll per class for a Gym.
        [HttpGet("generatePerClass/{id}")]
        public ActionResult <IEnumerable<PayrollGenerationDto>> GetPayrollPerClass(int gymId)
        {
            var payrollsItem = _repository.GetPayrollPerClass(gymId);
            return Ok(_mapper.Map<IEnumerable<PayrollDto>>(payrollsItem));
        }

        //GET api/payrolls/generatePerHour/{id}
        //This request returns a list of PayrollGeneration entities in a JSON format showing the payroll per hour for a Gym.
        [HttpGet("generatePerHour/{id}")]
        public ActionResult <IEnumerable<PayrollGenerationDto>> GetPayrollPerHours(int gymId)
        {
            var payrollsItem = _repository.GetPayrollPerHours(gymId);
            return Ok(_mapper.Map<IEnumerable<PayrollDto>>(payrollsItem));
        }

    }
}