using alura_backend_challenge_3.Data.ValueObjects;
using alura_backend_challenge_3.Models.Base;
using alura_backend_challenge_3.Models.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace alura_backend_challenge_3.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public VideoRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VideoVO> Create(VideoVO videoVO)
        {
            VideoEntity videoEntity = _mapper.Map<VideoEntity>(videoVO);
            _context.Videos.Add(videoEntity);

            await _context.SaveChangesAsync();

            return _mapper.Map<VideoVO>(videoEntity);
        }

        public async Task<IEnumerable<VideoVO>> FindAll()
        {
            List<VideoEntity> videos = await _context.Videos.ToListAsync();

            return _mapper.Map<List<VideoVO>>(videos);
        }

        public async Task<VideoVO> FindById(int id)
        {
            VideoEntity videoEntity = await _context.Videos.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<VideoVO>(videoEntity);
        }

        public async Task<VideoVO> Update(VideoVO videoVO)
        {
            VideoEntity videoEntity = await _context.Videos.Where(x => x.Id == videoVO.Id ).FirstOrDefaultAsync();

            if (videoEntity == null)
            {
                var videoCreated = await Create(videoVO);

                return videoCreated;
            } 
            else
            {
                _context.Entry(videoEntity).CurrentValues.SetValues(_mapper.Map<VideoEntity>(videoVO));
                await _context.SaveChangesAsync();

                return videoVO;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                VideoEntity videoEntity = await _context
                    .Videos
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (videoEntity == null)
                    return false;

                _context.Videos.Remove(videoEntity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<VideoVO>> FindAllVideosByCategoryId(int id)
        {
            List<VideoEntity> videos = await _context.Videos.Where(x => x.CategoriaId == id).ToListAsync();

            return _mapper.Map<List<VideoVO>>(videos);
        }
    }
}
