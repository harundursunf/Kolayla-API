using Businness.Abstract;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var topics = _topicService.GetAll();
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var topic = _topicService.GetById(id);
            if (topic == null)
                return NotFound();
            return Ok(topic);
        }

        [HttpPost]
        public IActionResult Add([FromBody] TopicDto topicDto)
        {
            _topicService.Add(topicDto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] TopicDto topicDto)
        {
            _topicService.Update(topicDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _topicService.Delete(id);
            return Ok();
        }
    }
}
