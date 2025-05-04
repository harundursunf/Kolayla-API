using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Kullanıcı giriş yapmış olmalı
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
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] NoteDto dto)
        {
            _noteService.Add(dto);
            return Ok(new { message = "Not başarıyla eklendi." });
        }

        [HttpPut]
        public IActionResult Update([FromBody] NoteDto dto)
        {
            _noteService.Update(dto);
            return Ok(new { message = "Not başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.Delete(id);
            return Ok(new { message = "Not başarıyla silindi." });
        }
    }
}
