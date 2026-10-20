using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.DTOs.ApplicationDTOs;
using TrialA.UNITOFWORKS;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public ApplicationsController(IUnitOfWork unitofwork , IMapper m)
        {
            mapper = m;
            _unitofwork = unitofwork;
        }

        [HttpPatch("{id}")]
       
        public async Task<IActionResult> EditInStatus(int id , PatchStatus DTO)
        {
            var E = await _unitofwork.Application.GetById(id);
            if (E == null)
            {
                return NotFound();
            }
            E.Status = DTO.Status;  
            _unitofwork.Application.Update(E);
            await _unitofwork.Save();
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAl()
        {
            var e = await _unitofwork.Application.GetAll();
            var t = mapper.Map<List<GetAllApplication>>(e);
            return Ok(t);
        }



    }
}
