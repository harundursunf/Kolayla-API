using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
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
                return BadRequest("Tamamlanmış konu bilgisi boş olamaz.");

            _completedTopicService.Add(dto);
            return Ok("Tamamlanmış konu eklendi.");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CompletedTopicDto dto)
        {
            if (dto == null)
                return BadRequest("Güncelleme verisi geçersiz.");

            _completedTopicService.Update(dto);
            return Ok("Tamamlanmış konu güncellendi.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _completedTopicService.Delete(id);
            return Ok("Tamamlanmış konu silindi.");
        }

        [HttpGet("get/{id}")]
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
    }
}
