using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IMaterialCompradoRepository
    {
        public Task<IEnumerable<MaterialCompradoModel>?> Get();

        public Task<MaterialCompradoModel?> Get(int id);

        public Task<MaterialCompradoModel> Create(MaterialCompradoModel materialComprado);

        public Task Update(MaterialCompradoModel materialComprado);

        public Task Delete(int id);
    }
}
