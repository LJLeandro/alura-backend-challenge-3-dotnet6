using alura_backend_challenge_3.Data.ValueObjects;
using alura_backend_challenge_3.Models.Base;
using alura_backend_challenge_3.Models.Context;
using AutoMapper;

namespace alura_backend_challenge_3.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public CategoriaRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoriaVO> Create(CategoriaVO categoriaVO)
        {
            CategoriaEntity categoriaEntity = _mapper.Map<CategoriaEntity>(categoriaVO);
            _context.Categorias.Add(categoriaEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<CategoriaVO>(categoriaEntity);
        }

        public async Task<IEnumerable<CategoriaVO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaVO> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoriaVO>> GetAllVideosByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaVO> Update(CategoriaVO valueObject)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
