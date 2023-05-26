using Business.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningOutComeContentsController : ControllerBase
    {
        ILearningOutComeContentService _learningOutComeContentService;

        public LearningOutComeContentsController(ILearningOutComeContentService learningOutComeContentService)
        {
            _learningOutComeContentService = learningOutComeContentService;
        }

        [HttpPost("add")]
        public IActionResult Add(LearningOutComeContent learningOutComeContent)
        {
            var result = _learningOutComeContentService.Add(learningOutComeContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetLearningOutComeContents()
        {
            var result = _learningOutComeContentService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetLearningOutComeContentById(int id)
        {
            var result = _learningOutComeContentService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(LearningOutComeContent learningOutComeContent)
        {
            var result = _learningOutComeContentService.Update(learningOutComeContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(LearningOutComeContent learningOutComeContent)
        {
            var result = _learningOutComeContentService.Delete(learningOutComeContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}