using Business.Abstact.LessonContent;
using Business.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalExamQuestionsController : ControllerBase
    {
        IFinalExamQuestionService _finalExamQuestionService;

        public FinalExamQuestionsController(IFinalExamQuestionService finalExamQuestionService)
        {
            _finalExamQuestionService = finalExamQuestionService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] FinalExamQuestion question)
        {
            var result = _finalExamQuestionService.Add(file, question);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetFinalExamQuestions()
        {
            var result = _finalExamQuestionService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyquestionid")]
        public IActionResult GetFinalExamQuestionById(int id)
        {
            var result = _finalExamQuestionService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] FinalExamQuestion question)
        {
            var result = _finalExamQuestionService.Update(file, question);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(FinalExamQuestion question)
        {
            var result = _finalExamQuestionService.Delete(question);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
