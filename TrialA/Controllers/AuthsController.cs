using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.DTOs.AuthDTOs;
using TrialA.Models;
using TrialA.UNITOFWORKS;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public AuthsController(IUnitOfWork unitofwork , IMapper m)
        {
            _unitofwork = unitofwork;
            mapper = m;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTOs dto)
        {
            var t = await _unitofwork.User.Login(dto);
            if (t == null)
            {
                return Unauthorized();
            }
            return Ok(t);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTOs dto)
        {
            var e = await _unitofwork.User.Register(dto);
            if(e == false)
            {
                return BadRequest();
            }
            var t = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PassWord = dto.PassWord,
                CreatedAt = dto.CreatedAt,
                Role = dto.Role,
            };

            await _unitofwork.User.Add(t);
            await _unitofwork.Save();
            return Created("",t);
        }
    }
}
