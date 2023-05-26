using Business.Abstract.LessonContent;
using Entities.LessonContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.LessonContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectContentsController : ControllerBase
    {
        IProjectContentService _projectContentService;

        public ProjectContentsController(IProjectContentService projectContentService)
        {
            _projectContentService = projectContentService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] ProjectContent projectContent)
        {
            var result = _projectContentService.Add(file, projectContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetProjectContents()
        {
            var result = _projectContentService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyquestionid")]
        public IActionResult GetProjectContentById(int id)
        {
            var result = _projectContentService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] ProjectContent projectContent)
        {
            var result = _projectContentService.Update(file, projectContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ProjectContent projectContent)
        {
            var result = _projectContentService.Delete(projectContent);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
