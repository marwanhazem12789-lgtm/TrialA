using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.DTOs.CandidateDTOs;
using TrialA.UNITOFWORKS;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatessController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public CandidatessController(IUnitOfWork unitofwork, IMapper m)
        {
            mapper = m;
            _unitofwork = unitofwork;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id , UpdateCandidate dto)
        {
            var t = await _unitofwork.Profile.GetById(id);
            if(t == null)
            {
                return NotFound(); 
            }
            var y = await _unitofwork.User.GetById(dto.CandidateId);
            if (y == null)
            {
                return NotFound();
            }
            t.ResumeURL = dto.ResumeURL;
            t.CandidateId = dto.CandidateId;
            t.Skill = dto.Skill;
            t.YearsOfExperience = dto.YearsOfExperience;
            t.Phone = dto.Phone;

            _unitofwork.Profile.Update(t);
            await _unitofwork.Save();
            return NoContent();
        }
    }
}
