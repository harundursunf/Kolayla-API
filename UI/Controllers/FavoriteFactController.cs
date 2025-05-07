using Business.Abstract;
using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteFactController : ControllerBase
    {
        private readonly IFavoriteFactService _favoriteFactService;

        public FavoriteFactController(IFavoriteFactService favoriteFactService)
        {
            _favoriteFactService = favoriteFactService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] FavoriteFactDto dto)
        {
            _favoriteFactService.Add(dto);
            return Ok("Favori bilgi eklendi.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] FavoriteFactDto dto)
        {
            _favoriteFactService.Update(dto);
            return Ok("Favori bilgi güncellendi.");
        }

        
        [HttpDelete("{userId}/{factId}")]
        public IActionResult Delete(int userId, int factId)
        {
            var dto = new FavoriteFactDto
            {
                UserId = userId,
                FactId = factId
            };

            _favoriteFactService.Delete(dto);
            return Ok("Favori bilgi silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _favoriteFactService.GetById(id);
            if (result == null)
                return NotFound("Bilgi bulunamadı.");
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _favoriteFactService.GetAll();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _favoriteFactService.GetByUserId(userId);
            return Ok(result);
        }
    }
}
