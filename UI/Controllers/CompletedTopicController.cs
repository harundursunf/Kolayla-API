using Business.Abstract;
using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedTopicController : ControllerBase
    {
        private readonly ICompletedTopicService _completedTopicService;

        public CompletedTopicController(ICompletedTopicService completedTopicService)
        {
            _completedTopicService = completedTopicService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CompletedTopicDto dto)
        {
            if (dto == null)
                return BadRequest("Geçersiz veri.");

            _completedTopicService.Add(dto);
            return Ok("Tamamlanan konu eklendi.");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CompletedTopicDto dto)
        {
            if (dto == null)
                return BadRequest("Geçersiz veri.");

            _completedTopicService.Update(dto);
            return Ok("Tamamlanan konu güncellendi.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _completedTopicService.GetById(id);
            if (result == null)
                return NotFound("Konu bulunamadı.");

            _completedTopicService.Delete(id);
            return Ok("Tamamlanan konu silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _completedTopicService.GetById(id);
            if (result == null)
                return NotFound("Konu bulunamadı.");
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _completedTopicService.GetAll();
            return Ok(result);
        }

        [HttpGet("getbyuser/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _completedTopicService.GetByUserId(userId);
            return Ok(result);
        }

        [HttpGet("getbyuserandtopic")]
        public IActionResult GetByUserIdAndTopicId([FromQuery] int userId, [FromQuery] int topicId)
        {
            var result = _completedTopicService.GetByUserIdAndTopicId(userId, topicId);
            if (result == null)
                return NotFound("Belirtilen kullanıcı ve konuya ait tamamlanan konu bulunamadı.");
            return Ok(result);
        }
    }
}
