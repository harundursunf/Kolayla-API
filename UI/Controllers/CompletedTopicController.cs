using Business.Abstract;
using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

            // Aynı userId ve topicId için bir kayıt var mı kontrol et
            var existingTopic = _completedTopicService.GetByUserIdAndTopicId(dto.UserId, dto.TopicId);
            if (existingTopic != null)
            {
                return BadRequest("Bu konu zaten tamamlanmış.");
            }

            dto.CompletedDate = DateTime.UtcNow;  // Tamamlanma tarihi ayarla
            _completedTopicService.Add(dto);
            return Ok("Tamamlanmış konu eklendi.");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CompletedTopicDto dto)
        {
            if (dto == null)
                return BadRequest("Güncelleme verisi geçersiz.");

            var existingTopic = _completedTopicService.GetById(dto.Id);
            if (existingTopic == null)
            {
                return NotFound("Konu bulunamadı.");
            }

            _completedTopicService.Update(dto);
            return Ok("Tamamlanmış konu güncellendi.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingTopic = _completedTopicService.GetById(id);
            if (existingTopic == null)
            {
                return NotFound("Konu bulunamadı.");
            }

            _completedTopicService.Delete(id);
            return Ok("Tamamlanmış konu silindi.");
        }

        [HttpGet("getbyuser/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _completedTopicService.GetByUserId(userId);
            return Ok(result);
        }
    }
}
