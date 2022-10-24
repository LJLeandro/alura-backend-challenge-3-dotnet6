using alura_backend_challenge_3.Data.ValueObjects;
using alura_backend_challenge_3.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace alura_backend_challenge_3.Controllers
{
    [Route("api/v1/videos")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private IVideoRepository _repository;

        public VideoController(IVideoRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<IActionResult> Create(VideoVO videoVO)
        {
            if (videoVO == null) return BadRequest();

            var product = await _repository.Create(videoVO);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var videos = await _repository.FindAll();

            return Ok(videos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var video = await _repository.FindById(id);
            if (video == null) return NotFound();

            return Ok(video);
        }

        [HttpPut]
        public async Task<IActionResult> Update(VideoVO videoVO)
        {
            if (videoVO == null) return BadRequest();

            var videoRegistered = await _repository.Update(videoVO);

            return Ok(videoRegistered);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(new { status });
        }

    }
}
