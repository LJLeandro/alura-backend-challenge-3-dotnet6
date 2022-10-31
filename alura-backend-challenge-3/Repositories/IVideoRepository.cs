using alura_backend_challenge_3.Data.ValueObjects;

namespace alura_backend_challenge_3.Repositories
{
    public interface IVideoRepository : IDataRepository<VideoVO>
    {
        public Task<IEnumerable<VideoVO>> FindAllVideosByCategoryId(int id);
    }
}
