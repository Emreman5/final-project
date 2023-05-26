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
    public class LessonDocumentsController : ControllerBase
    {
        private ILessonDocumentService _lessonDocumentService;

        public LessonDocumentsController(ILessonDocumentService lessonDocumentService)
        {
            _lessonDocumentService = lessonDocumentService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] LessonDocument lessonDocument)
        {
            var result = _lessonDocumentService.Add(file, lessonDocument);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _lessonDocumentService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _lessonDocumentService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] LessonDocument lessonDocument)
        {
            var result = _lessonDocumentService.Update(file, lessonDocument);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(LessonDocument lessonDocument)
        {
            var result = _lessonDocumentService.Delete(lessonDocument);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
