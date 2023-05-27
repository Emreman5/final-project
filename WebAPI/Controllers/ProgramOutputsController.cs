using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramOutputsController : ControllerBase
    {
        private IProgramOutputService _programOutputService;

        public ProgramOutputsController(IProgramOutputService programOutputService)
        {
            _programOutputService = programOutputService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] List<IFormFile> file, [FromForm] ProgramOutput programOutput)
        {
            var result = _programOutputService.Add(file[0], programOutput);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _programOutputService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _programOutputService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] List<IFormFile> file, [FromForm] ProgramOutput programOutput)
        {
            var result = _programOutputService.Update(file[0], programOutput);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ProgramOutput programOutput)
        {
            var result = _programOutputService.Delete(programOutput);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
