using Business.Abstract;
using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] QuoteDto dto)
        {
            _quoteService.Add(dto);
            return Ok("Alıntı başarıyla eklendi.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] QuoteDto dto)
        {
            _quoteService.Update(dto);
            return Ok("Alıntı başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quoteDto = new QuoteDto { Id = id };
            _quoteService.Delete(quoteDto);
            return Ok("Alıntı başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _quoteService.GetById(id);
            if (result == null)
                return NotFound("Alıntı bulunamadı.");
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _quoteService.GetAll();
            return Ok(result);
        }
    }
}
