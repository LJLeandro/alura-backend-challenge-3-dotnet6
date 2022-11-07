using alura_backend_challenge_3.Data.ValueObjects;

namespace alura_backend_challenge_3.Repositories
{
    public interface IVideoRepository : IDataRepository<VideoVO>
    {
        public Task<IEnumerable<VideoVO>> FindVideosByCategoryId(int id);

        public Task<IEnumerable<VideoVO>> FindVideosByName(string name);
    }
}
