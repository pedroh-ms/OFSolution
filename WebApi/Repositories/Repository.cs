using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.EF;

namespace WebApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : AbstractModel
    {
        private readonly OFContext _context;

        public OFContext Context => _context;

        public Repository(OFContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T record)
        {
            record.InsertedAt = DateTime.Now;
            record.UpdatedAt = DateTime.Now;

            Context.Set<T>().Add(record);
            await Context.SaveChangesAsync();

            return record;
        }

        public async Task Delete(int id)
        {
            var record = await Context.Set<T>().FindAsync(id);

            if (record != null)
            {
                Context.Set<T>().Remove(record);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>?> Get()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T?> Get(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task Update(T update)
        {
            var record = await Context.Set<T>().FindAsync(update.Id);

            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(update);

                if (property.CanWrite && value != null)
                    property.SetValue(record, value);
            }

            record!.UpdatedAt = DateTime.Now;
            Context.Entry(record).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
