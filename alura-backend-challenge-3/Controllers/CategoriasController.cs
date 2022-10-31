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
        private ICategoriaRepository _repository;

        public CategoriasController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<CategoriaVO> Create(CategoriaVO categoriaVO)
        {
            var categoriaCriada = await _repository.Create(categoriaVO);

            return categoriaCriada;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var categorias = await _repository.FindAll();

            return new ObjectResult(categorias) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var video = await _repository.FindById(id);
            if (video == null) return NotFound();

            return new ObjectResult(video) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoriaVO categoriaVO)
        {
            if (categoriaVO == null) return BadRequest();

            var categoriaAtualizada = await _repository.Update(categoriaVO);

            return new ObjectResult(categoriaAtualizada) { StatusCode = StatusCodes.Status200OK };
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
