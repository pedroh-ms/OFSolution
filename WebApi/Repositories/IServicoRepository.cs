using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IServicoRepository
    {
        public Task<IEnumerable<ServicoModel>?> Get();

        public Task<ServicoModel?> Get(int id);

        public Task<ServicoModel> Create(ServicoModel servico);

        public Task Update(ServicoModel servico);

        public Task Delete(int id);
    }
}
