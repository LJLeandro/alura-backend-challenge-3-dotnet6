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
            CategoriaEntity categoriaEntity = await _context.Categorias.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<CategoriaVO>(categoriaEntity);
        }

        public async Task<CategoriaVO> Update(CategoriaVO categoriaVO)
        {
            CategoriaEntity categoriaEntity = await _context.Categorias.Where(x => x.Id == categoriaVO.Id).FirstOrDefaultAsync();

            if (categoriaEntity == null)
            {
                var videoCreated = await Create(categoriaVO);

                return videoCreated;
            }
            else
            {
                _context.Entry(categoriaEntity).CurrentValues.SetValues(_mapper.Map<VideoEntity>(categoriaVO));
                await _context.SaveChangesAsync();

                return categoriaVO;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                CategoriaEntity categoriaEntity = await _context
                    .Categorias
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (categoriaEntity == null)
                    return false;

                _context.Categorias.Remove(categoriaEntity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
