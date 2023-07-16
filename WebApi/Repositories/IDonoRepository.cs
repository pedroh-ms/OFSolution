using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IDonoRepository
    {
        public Task<IEnumerable<DonoModel>?> Get();

        public Task<DonoModel?> Get(int id);

        public Task<DonoModel> Create(DonoModel dono);

        public Task Update(DonoModel dono);

        public Task Delete(int id);
    }
}
