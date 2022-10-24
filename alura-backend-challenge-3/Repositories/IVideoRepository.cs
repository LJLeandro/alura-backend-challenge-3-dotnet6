using alura_backend_challenge_3.Data.ValueObjects;

namespace alura_backend_challenge_3.Repositories
{
    public interface IVideoRepository
    {
        Task<IEnumerable<VideoVO>> FindAll();
        Task<VideoVO> FindById(Guid id);
        Task<VideoVO> Create(VideoVO videoVO);
        Task<VideoVO> Update(VideoVO videoVO);
        Task<bool> Delete(Guid id);
    }
}
