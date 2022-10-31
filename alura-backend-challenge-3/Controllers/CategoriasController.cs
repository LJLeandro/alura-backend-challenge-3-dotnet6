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
    }
}
