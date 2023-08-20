using WebApi.Models;

namespace WebApi.Repositories
{
    /// <summary>
    /// Generic repository for the Entity Framework Core.
    /// </summary>
    /// <typeparam name="T">A model class that inherits from BaseModel.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// This method gets all the records from the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> that returns all the records from the database.</returns>
        public Task<IEnumerable<T>?> Get();

        /// <summary>
        /// This method gets the record that matches the ID in the parameter.
        /// </summary>
        /// <param name="id">The ID of the record that will be fetched.</param>
        /// <returns>A <see cref="Task"/> that returns the record.</returns>
        public Task<T?> Get(int id);

        /// <summary>
        /// This method inserts a new record into the database.
        /// </summary>
        /// <param name="record">The record to be inserted.</param>
        /// <returns>A <see cref="Task"/> that returns the inserted record.</returns>
        public Task<T> Create(T record);

        /// <summary>
        /// This method updates the record that matches the update object ID passed in the parameter.
        /// </summary>
        /// <param name="update">The object containing the data to be updated.</param>
        /// <returns></returns>
        public Task Update(T update);

        /// <summary>
        /// This method deletes a record from the database.
        /// </summary>
        /// <param name="id">The ID of the record to be deleted.</param>
        /// <returns></returns>
        public Task Delete(int id);
    }
}
