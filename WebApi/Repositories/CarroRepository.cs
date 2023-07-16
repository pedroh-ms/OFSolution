using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly OficinaContext _context;

        internal OficinaContext Context => _context;

        public CarroRepository(OficinaContext context)
        {
            _context = context;
        }


        public async Task<CarroModel> Create(CarroModel carro)
        {
            carro.InsertedAt = DateTime.Now;
            carro.UpdatedAt = DateTime.Now;

            Context.Carros.Add(carro);
            await Context.SaveChangesAsync();

            return carro;
        }

        public async Task Delete(int id)
        {
            var carro = await Context.Carros.FindAsync(id);

            if (carro != null)
            {
                Context.Carros.Remove(carro);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CarroModel>?> Get()
        {
            return await Context.Carros.ToListAsync();
        }

        public async Task<CarroModel?> Get(int id)
        {
            return await Context.Carros.FindAsync(id);
        }

        public async Task Update(CarroModel carro)
        {
            carro.UpdatedAt = DateTime.Now;
            Context.Entry(carro).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
