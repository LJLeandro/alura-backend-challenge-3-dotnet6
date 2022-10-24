using alura_backend_challenge_3.Data.ValueObjects;
using alura_backend_challenge_3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> FindAllVideos()
        {
            var videos = await _repository.FindAll();

            return Ok(videos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VideoVO videoVO)
        {
            if (videoVO == null) return BadRequest();

            var product = await _repository.Create(videoVO);

            return Ok(product);
        }


    }
}
