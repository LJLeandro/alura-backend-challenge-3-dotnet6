using alura_backend_challenge_3.Data.ValueObjects;

namespace alura_backend_challenge_3.Repositories
{
    public interface IDataRepository<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(int id);
        Task<T> Create(T valueObject);
        Task<T> Update(T valueObject);
        Task<bool> Delete(int id);
    }
}
