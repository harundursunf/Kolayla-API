using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactController : ControllerBase
    {
        private readonly IFactService _factService;

        public FactController(IFactService factService)
        {
            _factService = factService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] FactDto factDto)
        {
            _factService.Add(factDto);
            return Ok("Eklendi");
        }

        [HttpPut]
        public IActionResult Update([FromBody] FactDto factDto)
        {
            _factService.Update(factDto);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _factService.Delete(id);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _factService.GetById(id);
            if (result == null)
                return NotFound("Bulunamadı");

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _factService.GetAll();
            return Ok(result);
        }
    }
}
