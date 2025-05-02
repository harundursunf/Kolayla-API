using Business.Abstract;
using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyRecordController : ControllerBase
    {
        private readonly IStudyRecordService _studyRecordService;

        public StudyRecordController(IStudyRecordService studyRecordService)
        {
            _studyRecordService = studyRecordService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] StudyRecordDto dto)
        {
            _studyRecordService.Add(dto);
            return Ok("Çalışma kaydı başarıyla eklendi.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] StudyRecordDto dto)
        {
            _studyRecordService.Update(dto);
            return Ok("Çalışma kaydı başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studyRecordService.Delete(id);
            return Ok("Çalışma kaydı başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _studyRecordService.GetById(id);
            if (result == null)
                return NotFound("Çalışma kaydı bulunamadı.");
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _studyRecordService.GetAll();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _studyRecordService.GetByUserId(userId);
            return Ok(result);
        }
    }
}
