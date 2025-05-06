using Business.Abstract;
using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _noteService.GetAll();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = _noteService.GetAllByUserId(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _noteService.GetById(id);
            return result == null ? NotFound("Not bulunamadı.") : Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] NoteDto dto)
        {
            if (dto == null)
                return BadRequest("Not bilgisi boş olamaz.");

            _noteService.Add(dto);
            return Ok("Not başarıyla eklendi.");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] NoteDto dto)
        {
            _noteService.Update(dto);
            return Ok("Not başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.Delete(id);
            return Ok("Not başarıyla silindi.");
        }
    }
}
