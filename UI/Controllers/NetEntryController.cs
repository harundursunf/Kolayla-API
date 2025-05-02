using Business.Abstract;
using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetEntryController : ControllerBase
    {
        private readonly INetEntryService _netEntryService;

        public NetEntryController(INetEntryService netEntryService)
        {
            _netEntryService = netEntryService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] NetEntryDto dto)
        {
            _netEntryService.Add(dto);
            return Ok("Net giriş eklendi.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] NetEntryDto dto)
        {
            _netEntryService.Update(dto);
            return Ok("Net giriş güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _netEntryService.Delete(id);
            return Ok("Net giriş silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _netEntryService.GetById(id);
            if (result == null)
                return NotFound("Net giriş bulunamadı.");
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _netEntryService.GetAll();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _netEntryService.GetByUserId(userId);
            return Ok(result);
        }
    }
}
    