using alura_backend_challenge_3.Data.ValueObjects;
using alura_backend_challenge_3.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

            var videoCreated = await _repository.Create(videoVO);

            return new ObjectResult(videoCreated) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var videos = await _repository.FindAll();

            return new ObjectResult(videos) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var video = await _repository.FindById(id);
            if (video == null) return NotFound();

            return new ObjectResult(video) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPut]
        public async Task<IActionResult> Update(VideoVO videoVO)
        {
            if (videoVO == null) return BadRequest();

            var videoRegistered = await _repository.Update(videoVO);

            return new ObjectResult(videoRegistered) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return new ObjectResult(new { status }) { StatusCode = StatusCodes.Status200OK };
        }

    }
}
