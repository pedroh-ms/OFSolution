using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class DonoRepository : IDonoRepository
    {
        private readonly OficinaContext _context;

        internal OficinaContext Context => _context;

        public DonoRepository(OficinaContext context)
        {
            _context = context;
        }


        public async Task<DonoModel> Create(DonoModel dono)
        {
            dono.InsertedAt = DateTime.Now;
            dono.UpdatedAt = DateTime.Now;

            Context.Donos.Add(dono);
            await Context.SaveChangesAsync();

            return dono;
        }

        public async Task Delete(int id)
        {
            var dono = await Context.Donos.FindAsync(id);

            if (dono != null)
            {
                Context.Donos.Remove(dono);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DonoModel>?> Get()
        {
            return await Context.Donos.ToListAsync();
        }

        public async Task<DonoModel?> Get(int id)
        {
            return await Context.Donos.FindAsync(id);
        }

        public async Task Update(DonoModel dono)
        {
            dono.UpdatedAt = DateTime.Now;
            Context.Entry(dono).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
