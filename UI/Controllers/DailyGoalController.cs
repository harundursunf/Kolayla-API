using Business.Abstract;
using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyGoalController : ControllerBase
    {
        private readonly IDailyGoalService _dailyGoalService;

        public DailyGoalController(IDailyGoalService dailyGoalService)
        {
            _dailyGoalService = dailyGoalService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] DailyGoalDto dto)
        {
            if (dto == null)
                return BadRequest("Günlük hedef boş olamaz.");

            _dailyGoalService.Add(dto);
            return Ok("Günlük hedef başarıyla eklendi.");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] DailyGoalDto dto)
        {
            _dailyGoalService.Update(dto);
            return Ok("Günlük hedef başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _dailyGoalService.Delete(id);
            return Ok("Günlük hedef başarıyla silindi.");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _dailyGoalService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _dailyGoalService.GetById(id);
            return result == null ? NotFound("Günlük hedef bulunamadı.") : Ok(result);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _dailyGoalService.GetByUserId(userId);
            return Ok(result);
        }
    }
}
