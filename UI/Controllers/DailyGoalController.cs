using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyGoalController : ControllerBase
    {
        private readonly IDailyGoalService dailyGoalService;
        public DailyGoalController(IDailyGoalService dailyGoalService)
        {
            this.dailyGoalService = dailyGoalService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] DailyGoalDto  dailyGoalDto)
        {
            if (dailyGoalDto == null)
            {
                return BadRequest("Daily goal cannot be null");
            }
            dailyGoalService.Add(dailyGoalDto);
            return Ok("Daily goal added successfully");
        }
    }
}
