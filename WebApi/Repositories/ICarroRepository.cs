using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ICarroRepository
    {
        public Task<IEnumerable<CarroModel>?> Get();

        public Task<CarroModel?> Get(int id);

        public Task<CarroModel> Create(CarroModel carro);

        public Task Update(CarroModel carro);

        public Task Delete(int id);
    }
}
