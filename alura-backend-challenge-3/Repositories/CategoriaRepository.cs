using alura_backend_challenge_3.Data.ValueObjects;
using alura_backend_challenge_3.Models.Base;
using alura_backend_challenge_3.Models.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            List<CategoriaEntity> categorias = await _context.Categorias.ToListAsync();

            return _mapper.Map<List<CategoriaVO>>(categorias);
        }

        public async Task<CategoriaVO> FindById(int id)
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

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
