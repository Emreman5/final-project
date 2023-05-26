using Business.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidtermExamQuestionsController : ControllerBase
    {
        IMidtermExamQuestionService _midtermExamQuestionService;

        public MidtermExamQuestionsController(IMidtermExamQuestionService midtermExamQuestionService)
        {
            _midtermExamQuestionService = midtermExamQuestionService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file,[FromForm] MidtermExamQuestion question)
        {
            var result = _midtermExamQuestionService.Add(file, question);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetMidtermExamQuestions()
        {
            var result = _midtermExamQuestionService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyquestionid")]
        public IActionResult GetMidtermExamQuestionById(int id)
        {
            var result = _midtermExamQuestionService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] MidtermExamQuestion question)
        {
            var result = _midtermExamQuestionService.Update(file, question);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(MidtermExamQuestion question)
        {
            var result = _midtermExamQuestionService.Delete(question);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
