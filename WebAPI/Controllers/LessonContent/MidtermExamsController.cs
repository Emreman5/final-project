using Business.Abstract;
using Business.Abstract.LessonContent;
using Entities;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidtermExamsController : ControllerBase
    {
        IMidtermExamService _midtermExamService;

        public MidtermExamsController(IMidtermExamService midtermExamService)
        {
            _midtermExamService = midtermExamService;
        }

        [HttpPost("add")]
        public IActionResult Add(MidtermExam midtermExam)
        {
            var result = _midtermExamService.Add(midtermExam);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _midtermExamService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _midtermExamService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(MidtermExam midtermExam)
        {
            var result = _midtermExamService.Update(midtermExam);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(MidtermExam midtermExam)
        {
            var result = _midtermExamService.Delete(midtermExam);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getmidtermexamdetailsbyid")]
        public IActionResult GetMidtermExamDetails(int midtermExId)
        {
            var result = _midtermExamService.GetMidtermExamDetails(midtermExId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
