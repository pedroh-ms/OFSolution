using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly OficinaContext _context;

        internal OficinaContext Context => _context;

        public ServicoRepository(OficinaContext context)
        {
            _context = context;
        }


        public async Task<ServicoModel> Create(ServicoModel servico)
        {
            servico.InsertedAt = DateTime.Now;
            servico.UpdatedAt = DateTime.Now;

            Context.Servicos.Add(servico);
            await Context.SaveChangesAsync();

            return servico;
        }

        public async Task Delete(int id)
        {
            var servico = await Context.Servicos.FindAsync(id);

            if (servico != null)
            {
                Context.Servicos.Remove(servico);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ServicoModel>?> Get()
        {
            return await Context.Servicos.ToListAsync();
        }

        public async Task<ServicoModel?> Get(int id)
        {
            return await Context.Servicos.FindAsync(id);
        }

        public async Task Update(ServicoModel servico)
        {
            servico.UpdatedAt = DateTime.Now;
            Context.Entry(servico).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
