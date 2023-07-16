using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>?> Get();

        public Task<T?> Get(int id);

        public Task<T> Create(T record);

        public Task Update(T update);

        public Task Delete(int id);
    }
}
