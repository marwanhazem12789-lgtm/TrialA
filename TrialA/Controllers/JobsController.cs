using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.UNITOFWORKS;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public JobsController(IUnitOfWork unitOfWork , IMapper m)
        {
            this.unitOfWork = unitOfWork;
            
            mapper = m;
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById1(int id)
        {
            var t = await unitOfWork.Job.GetById2(id);
            if (t == null)
            {
                return NotFound();
            }
            return Ok(t);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string k)
        {
            var t = await unitOfWork.Job.Searcg(k);
            if (t == null)
            {
                return BadRequest();
            }
            return Ok(t);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var t = await unitOfWork.Job.GetById(id);
            if(t == null)
            {
                return BadRequest();
            }

            unitOfWork.Job.Delete(t);
            await unitOfWork.Save();
            return NoContent();
        }
        [HttpGet("Hieghst")]
        public async Task<IActionResult> GetHeighst()
        {
            var t = await unitOfWork.Job.Hishest();
            return Ok(t);
        }

    }
}
