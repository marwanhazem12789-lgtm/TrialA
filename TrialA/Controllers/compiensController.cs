using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.UNITOFWORKS;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class compiensController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;
        public compiensController(IUnitOfWork unitofwork, IMapper m)
        {
            _unitofwork = unitofwork;
            mapper = m;
        }
        [HttpGet("MostJobs")]
        public async Task<IActionResult> Getall()
        {
            var t = await _unitofwork.Company.GetTob();
            return Ok(t);
        }
    }
}
