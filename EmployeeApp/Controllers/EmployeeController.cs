using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApp.Dtos;
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
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
        public async Task<IActionResult> GetEmployee(long id)
        {
            var employee = await _service.GetByIdAsync(id);
            var employeeDto= _mapper.Map<EmployeeDetailDto>(employee);
            return Ok(employeeDto);
        }
    }
}