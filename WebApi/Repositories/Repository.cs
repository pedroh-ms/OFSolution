using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.EF;

namespace WebApi.Repositories
{
    /// <summary>
    /// Generic repository for the Entity Framework Core.
    /// </summary>
    /// <typeparam name="T">A model class that inherits from BaseModel.</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;

        /// <value>Property <c>Context</c> gets the context object.</value>
        public Context Context => _context;

        /// <summary>
        /// This constructor initializes the context object.
        /// </summary>
        /// <param name="context">The context object</param>
        public Repository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// This method inserts a new record into the database.
        /// </summary>
        /// <param name="record">The record to be inserted.</param>
        /// <returns>A <see cref="Task"/> that returns the inserted record.</returns>
        public async Task<T> Create(T record)
        {
            record.InsertedAt = DateTime.Now;
            record.UpdatedAt = DateTime.Now;

            Context.Set<T>().Add(record);
            await Context.SaveChangesAsync();

            return record;
        }

        /// <summary>
        /// This method deletes a record from the database.
        /// </summary>
        /// <param name="id">The ID of the record to be deleted.</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var record = await Context.Set<T>().FindAsync(id);

            if (record != null)
            {
                Context.Set<T>().Remove(record);
                await Context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method gets all the records from the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> that returns all the records from the database.</returns>
        public async Task<IEnumerable<T>?> Get()
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// This method gets the record that matches the ID in the parameter.
        /// </summary>
        /// <param name="id">The ID of the record that will be fetched.</param>
        /// <returns>A <see cref="Task"/> that returns the record.</returns>
        public async Task<T?> Get(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// This method updates the record that matches the update object ID passed in the parameter.
        /// </summary>
        /// <param name="update">The object containing the data to be updated.</param>
        /// <returns></returns>
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
