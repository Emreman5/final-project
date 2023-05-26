using Business.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningOutComesController : ControllerBase
    {
        ILearningOutComeService _learningOutComeService;

        public LearningOutComesController(ILearningOutComeService learningOutComeService)
        {
            _learningOutComeService = learningOutComeService;
        }

        [HttpPost("add")]
        public IActionResult Add(LearningOutCome learningOutCome)
        {
            var result = _learningOutComeService.Add(learningOutCome);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _learningOutComeService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _learningOutComeService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(LearningOutCome learningOutCome)
        {
            var result = _learningOutComeService.Update(learningOutCome);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(LearningOutCome learningOutCome)
        {
            var result = _learningOutComeService.Delete(learningOutCome);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getlearningoutcomedetailsbyid")]
        public IActionResult GetLearningOutComeDetails(int learningOutComeId)
        {
            var result = _learningOutComeService.GetLearningOutComeDetails(learningOutComeId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
