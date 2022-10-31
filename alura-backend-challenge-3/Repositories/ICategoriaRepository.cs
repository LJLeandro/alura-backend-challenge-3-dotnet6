using alura_backend_challenge_3.Data.ValueObjects;

namespace alura_backend_challenge_3.Repositories
{
    public interface ICategoriaRepository : IDataRepository<CategoriaVO>
    {
        public Task<IEnumerable<CategoriaVO>> GetAllVideosByCategoryId(int id);
    }
}
