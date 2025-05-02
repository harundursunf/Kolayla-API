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
        public IActionResult Add([FromBody] DailyGoalDto dailyGoalDto)
        {
            if (dailyGoalDto == null)
            {
                return BadRequest("Daily goal cannot be null");
            }

            _dailyGoalService.Add(dailyGoalDto);
            return Ok("Daily goal added successfully");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] DailyGoalDto dailyGoalDto)
        {
            _dailyGoalService.Update(dailyGoalDto);
            return Ok("Daily goal updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _dailyGoalService.Delete(id);
            return Ok("Daily goal deleted successfully");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var goals = _dailyGoalService.GetAll();
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var goal = _dailyGoalService.GetById(id);
            if (goal == null)
                return NotFound();

            return Ok(goal);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var goals = _dailyGoalService.GetByUserId(userId);
            return Ok(goals);
        }
    }
}
