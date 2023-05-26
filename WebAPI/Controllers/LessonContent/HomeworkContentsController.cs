using Business.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkContentsController : ControllerBase
    {
        IHomeworkContentService _homeworkContentService;

        public HomeworkContentsController(IHomeworkContentService homeworkContentService)
        {
            _homeworkContentService = homeworkContentService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] HomeworkContent homeworkContent)
        {
            var result = _homeworkContentService.Add(file, homeworkContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetHomeworkContents()
        {
            var result = _homeworkContentService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyquestionid")]
        public IActionResult GetHomeworkContentById(int id)
        {
            var result = _homeworkContentService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] HomeworkContent homeworkContent)
        {
            var result = _homeworkContentService.Update(file, homeworkContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(HomeworkContent homeworkContent)
        {
            var result = _homeworkContentService.Delete(homeworkContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
