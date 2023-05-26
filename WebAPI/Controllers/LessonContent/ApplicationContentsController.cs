using Business.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationContentsController : ControllerBase
    {
        IApplicationContentService _appContentService;

        public ApplicationContentsController(IApplicationContentService applicationContentService)
        {
            _appContentService = applicationContentService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] ApplicationContent appContent)
        {
            var result = _appContentService.Add(file, appContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetApplicationContents()
        {
            var result = _appContentService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyquestionid")]
        public IActionResult GetApplicationContentById(int id)
        {
            var result = _appContentService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] ApplicationContent appContent)
        {
            var result = _appContentService.Update(file, appContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ApplicationContent appContent)
        {
            var result = _appContentService.Delete(appContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
