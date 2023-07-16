using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class MaterialCompradoRepository : IMaterialCompradoRepository
    {
        private readonly OficinaContext _context;

        internal OficinaContext Context => _context;

        public MaterialCompradoRepository(OficinaContext context)
        {
            _context = context;
        }


        public async Task<MaterialCompradoModel> Create(MaterialCompradoModel materialComprado)
        {
            materialComprado.InsertedAt = DateTime.Now;
            materialComprado.UpdatedAt = DateTime.Now;

            Context.MaterialComprados.Add(materialComprado);
            await Context.SaveChangesAsync();

            return materialComprado;
        }

        public async Task Delete(int id)
        {
            var materialComprado = await Context.MaterialComprados.FindAsync(id);

            if (materialComprado != null)
            {
                Context.MaterialComprados.Remove(materialComprado);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MaterialCompradoModel>?> Get()
        {
            return await Context.MaterialComprados.ToListAsync();
        }

        public async Task<MaterialCompradoModel?> Get(int id)
        {
            return await Context.MaterialComprados.FindAsync(id);
        }

        public async Task Update(MaterialCompradoModel materialComprado)
        {
            materialComprado.UpdatedAt = DateTime.Now;
            Context.Entry(materialComprado).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
