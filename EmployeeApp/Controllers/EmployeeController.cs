using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApp.Dtos;
using EmployeeApp.Helpers;
using EmployeeApp.Models;
using EmployeeApp.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IDataBuildHelper _dataBuildHelper;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper, IDataBuildHelper dataBuildHelper)
        {
            _service = service;
            _mapper = mapper;
            _dataBuildHelper = dataBuildHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employeesQueryable = await _service.Query(e => e.Active);
            var employees = employeesQueryable.ToList();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeListDto>>(employees);
            return Ok(employeeDtos.OrderBy(e => e.Name));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(long id, [FromQuery]EmployeeParams employeeParams)
        {
            var employee = await _service.GetByIdAsync(id);

            if (employeeParams.OperationStatus[employeeParams.GetOperationIndex] == employeeParams.Mode)
            {
                var employeeDto = _mapper.Map<EmployeeDetailDto>(employee);
                return Ok(employeeDto);
            }
            else
            {
                EmployeeEditDto employeeEditDto;
                if (employeeParams.OperationStatus[employeeParams.CreateOperationIndex] == employeeParams.Mode)
                    employeeEditDto = new EmployeeEditDto();
                else
                    employeeEditDto = _mapper.Map<EmployeeEditDto>(employee);

                await _dataBuildHelper.GetAdditionalData(employeeEditDto);
                return Ok(employeeEditDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeEditDto employeeEditDto)
        {
            var employee = _mapper.Map<Employee>(employeeEditDto);
            await _service.AddAsync(employee);
            // TODO Error handling!
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(long id, EmployeeDetailDto employeeDetailDto)
        {
            var employee = await _service.GetByIdAsync(id);

            if (employee == null || !employee.Active)
                return NotFound();

            _mapper.Map(employeeDetailDto, employee);
            await _service.UpdateAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            var employee = await _service.GetByIdAsync(id);

            if (employee == null || !employee.Active)
                return NotFound();

            await _service.DeleteAsync(employee);
            // TODO handling
            return Ok();
        }
    }
}