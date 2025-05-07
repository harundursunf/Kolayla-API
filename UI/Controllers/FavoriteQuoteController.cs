using Business.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteQuoteController : ControllerBase
    {
        private readonly IFavoriteQuoteService _favoriteQuoteService;

        public FavoriteQuoteController(IFavoriteQuoteService favoriteQuoteService)
        {
            _favoriteQuoteService = favoriteQuoteService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] FavoriteQuoteDto dto)
        {
            _favoriteQuoteService.Add(dto);
            return Ok("Favori alıntı eklendi.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] FavoriteQuoteDto dto)
        {
            _favoriteQuoteService.Update(dto);
            return Ok("Favori alıntı güncellendi.");
        }

        [HttpDelete("{userId:int}/{quoteId:int}")]
        public IActionResult Delete(int userId, int quoteId)
        {
            var dto = new FavoriteQuoteDto
            {
                UserId = userId,
                QuoteId = quoteId
            };
            _favoriteQuoteService.Delete(dto);
            return Ok("Favori alıntı silindi.");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _favoriteQuoteService.GetById(id);
            if (result == null)
                return NotFound("Alıntı bulunamadı.");
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _favoriteQuoteService.GetAll();
            return Ok(result);
        }

        [HttpGet("user/{userId:int}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _favoriteQuoteService.GetByUserId(userId);
            return Ok(result);
        }
    }
}
