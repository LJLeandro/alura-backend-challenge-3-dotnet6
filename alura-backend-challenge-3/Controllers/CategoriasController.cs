using alura_backend_challenge_3.Data.ValueObjects;
using alura_backend_challenge_3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alura_backend_challenge_3.Controllers
{
    [Route("api/v1/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository _categoriaRepository;
        private IVideoRepository _videoRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository,
                                        IVideoRepository videoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _videoRepository = videoRepository;
        }

        [HttpPost]
        public async Task<CategoriaVO> Create(CategoriaVO categoriaVO)
        {
            var categoriaCriada = await _categoriaRepository.Create(categoriaVO);

            return categoriaCriada;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var categorias = await _categoriaRepository.FindAll();

            return new ObjectResult(categorias) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var video = await _categoriaRepository.FindById(id);
            if (video == null) return NotFound();

            return new ObjectResult(video) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("{id}/videos")]
        public async Task<IActionResult> FindVideosByCategoria(int id)
        {
            var videos = await _videoRepository.FindVideosByCategoryId(id);

            return new ObjectResult(new { videos }) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoriaVO categoriaVO)
        {
            if (categoriaVO == null) return BadRequest();

            var categoriaAtualizada = await _categoriaRepository.Update(categoriaVO);

            return new ObjectResult(categoriaAtualizada) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _categoriaRepository.Delete(id);
            if (!status) return BadRequest();
            return new ObjectResult(new { status }) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
