using AutoMapper;
using DotnetYuzuncuYilBootcamp.Core.DTOs;
using DotnetYuzuncuYilBootcamp.Core.Models;
using DotnetYuzuncuYilBootcamp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetYuzuncuYilBootcamp.API.Controllers
{
    public class DutyController: CustomBaseController
    {
        private readonly IMapper _mapper; 
        private readonly IDutyService _dutyService; 
        public DutyController(IMapper mapper, IDutyService dutyService)
        {
            _mapper = mapper;
            _dutyService = dutyService;
        }
        // api/Team/
        [HttpGet]
        public async Task<IActionResult> All()  
        {
            var dutys = await _dutyService.GetAllAsync();  
            var dutysDto = _mapper.Map<List<DutyDto>>(dutys.ToList());  
            return CreateActionResult(GlobalResultDto<List<DutyDto>>.Success(200, dutysDto));                                                                                      
        }

        [HttpGet("{id}")]  
        // Get api/team/3 
        public async Task<IActionResult> GetById(int id) 
        {
            var duty = await _dutyService.GetByIdAsync(id);
            var dutyDto = _mapper.Map<DutyDto>(duty);
            return CreateActionResult(GlobalResultDto<DutyDto>.Success(200, dutyDto));  
        }
       
        [HttpPost]
        public async Task<IActionResult> Save(DutyDto dutyDto) 
        {
            var duty = await _dutyService.AddAsync(_mapper.Map<Duty>(dutyDto));  
            var dutyDtos = _mapper.Map<DutyDto>(duty);  
            return CreateActionResult(GlobalResultDto<DutyDto>.Success(201, dutyDtos)); 
        }
        
       [HttpPut]
       public async Task<IActionResult> Update(DutyDto dutyDto)
       { 
           await _dutyService.UpdateAsync(_mapper.Map<Duty>(dutyDto));
           return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
       }
       
       [HttpDelete("{id}")]
       public async Task<IActionResult> Remove(int id)
       {
           var duty = await _dutyService.GetByIdAsync(id);
           await _dutyService.RemoveAsync(duty);
           return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
    }
}
