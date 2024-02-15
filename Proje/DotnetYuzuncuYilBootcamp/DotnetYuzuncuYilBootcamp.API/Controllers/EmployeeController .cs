using AutoMapper;
using DotnetYuzuncuYilBootcamp.Core.DTOs;
using DotnetYuzuncuYilBootcamp.Core.DTOs.Authentication;
using DotnetYuzuncuYilBootcamp.Core.Models;
using DotnetYuzuncuYilBootcamp.Core.Services;
using DotnetYuzuncuYilBootcamp.Service.Abstraction;
using DotnetYuzuncuYilBootcamp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetYuzuncuYilBootcamp.API.Controllers
{
    public class EmployeeController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
       }
        // api/Employee/
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var employees = await _employeeService.GetAllAsync();
            var employeeDto = _mapper.Map<List<EmployeeDto>>(employees.ToList());
            return CreateActionResult(GlobalResultDto<List<EmployeeDto>>.Success(200, employeeDto));
        }

        [HttpGet("{id}")]
        // Get api/Employee/3
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return CreateActionResult(GlobalResultDto<EmployeeDto>.Success(200, employeeDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(AuthRequestDto authRequestDto, int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            employee = _employeeService.UpdateEmployee(employee, authRequestDto);
            _employeeService.UpdateAsync(employee);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            await _employeeService.RemoveAsync(employee);

            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp(AuthRequestDto authDto)
        {
            var employee = _employeeService.SignUp(authDto);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return CreateActionResult(GlobalResultDto<EmployeeDto>.Success(201, employeeDto));
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthLoginDto authDto)
        {
            var result = _employeeService.Login(authDto);
            if (result.Employee != null)
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(200, result));
            else
                return CreateActionResult(GlobalResultDto<AuthResponseDto>.Success(401, result));
        }

    }
}
