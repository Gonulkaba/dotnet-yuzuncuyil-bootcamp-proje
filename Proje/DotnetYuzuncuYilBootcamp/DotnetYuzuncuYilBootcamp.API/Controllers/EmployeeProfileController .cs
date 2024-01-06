using AutoMapper;
using DotnetYuzuncuYilBootcamp.Core.DTOs;
using DotnetYuzuncuYilBootcamp.Core.Models;
using DotnetYuzuncuYilBootcamp.Core.Services;
using DotnetYuzuncuYilBootcamp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetYuzuncuYilBootcamp.API.Controllers
{
    public class EmployeeProfileController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeProfileService _employeeProfileService;
        public EmployeeProfileController(IMapper mapper, IEmployeeProfileService employeeProfileService)
        {
            _mapper = mapper;
            _employeeProfileService = employeeProfileService;
        }
        // api/EmployeeProfile/
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var employeeProfiles = await _employeeProfileService.GetAllAsync();
            var employeeProfilesDto = _mapper.Map<List<EmployeeProfileDto>>(employeeProfiles.ToList());
            return CreateActionResult(GlobalResultDto<List<EmployeeProfileDto>>.Success(200, employeeProfilesDto));
        }

        [HttpGet("{id}")]
        // Get api/EmployeeProfile/3
        public async Task<IActionResult> GetById(int id)
        {
            var employeeProfile = await _employeeProfileService.GetByIdAsync(id);
            var employeeProfileDto = _mapper.Map<EmployeeProfileDto>(employeeProfile);
            return CreateActionResult(GlobalResultDto<EmployeeProfileDto>.Success(200, employeeProfileDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmployeeProfileDto employeeProfileDto)
        {
            var employeeProfile = await _employeeProfileService.AddAsync(_mapper.Map<EmployeeProfile>(employeeProfileDto));
            var employeeProfileDtos = _mapper.Map<EmployeeProfileDto>(employeeProfile);
            return CreateActionResult(GlobalResultDto<EmployeeProfileDto>.Success(201, employeeProfileDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeProfileDto employeeProfileDto)
        {
            await _employeeProfileService.UpdateAsync(_mapper.Map<EmployeeProfile>(employeeProfileDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var employeeProfile = await _employeeProfileService.GetByIdAsync(id);
            await _employeeProfileService.RemoveAsync(employeeProfile);

            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
    }
}
