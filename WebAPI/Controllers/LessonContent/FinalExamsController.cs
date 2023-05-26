using Business.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalExamsController : ControllerBase
    {
        IFinalExamService _finalExamService;

        public FinalExamsController(IFinalExamService finalExamService)
        {
            _finalExamService = finalExamService;
        }

        [HttpPost("add")]
        public IActionResult Add(FinalExam finalExam)
        {
            var result = _finalExamService.Add(finalExam);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _finalExamService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _finalExamService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(FinalExam finalExam)
        {
            var result = _finalExamService.Update(finalExam);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(FinalExam finalExam)
        {
            var result = _finalExamService.Delete(finalExam);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
