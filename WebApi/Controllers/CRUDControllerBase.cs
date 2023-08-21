using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the generic controller to perform CRUD operations.
    /// </summary>
    [ApiController]
    public class CRUDControllerBase<T, TController, TFromBody, TView> : ControllerBase where T : BaseModel, new() where TController : CRUDControllerBase<T, TController, TFromBody, TView> where TView : new()
    {
        private readonly ILogger<TController> _logger;
        private readonly IRepository<T> _repository;

        /// <value>
        /// Gets the logger.
        /// </value>
        public ILogger<TController> Logger => _logger;
        /// <value>
        /// Gets the repository.
        /// </value>
        public IRepository<T> Repository => _repository;

        /// <summary>
        /// This constructor initializes the logger and repository.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public CRUDControllerBase(ILogger<TController> logger, IRepository<T> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Gets all the records from the table mapped to type of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> that returns a <see cref="IEnumerable{T}"/> of <typeparamref name="TView"/>.</returns>
        [HttpGet]
        public async Task<IEnumerable<TView>> Get()
        {
            var obj = await Repository.Get();

            if (obj != null)
                return obj.Select(x => ToView(x)).ToList();
            else
                return new List<TView>();
        }

        /// <summary>
        /// Get a record in table mapped to type <typeparamref name="T"/> by its <c>id</c>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record to be fetched.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{TValue}"/> of <typeparamref name="TView"/> containing the data in the record with matched <c>id</c>.</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TView>> Get(int id)
        {
            var obj = await Repository.Get(id);

            if (obj != null)
                return ToView(obj);
            else
                return NotFound();
        }

        /// <summary>
        /// Inserts a record with the data in <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The mapped object containing the data to be inserted.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{TValue}"/> of <typeparamref name="TView"/> with the data inserted.</returns>
        [HttpPost]
        public async Task<ActionResult<TView>> Post([FromBody] TFromBody obj)
        {
            return ToView(await Repository.Create(ToModel(obj)));
        }

        /// <summary>
        /// Deletes the record in table mapped to type <typeparamref name="T"/> that matches the <c>id</c> in <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record to be deleted.</param>
        /// <returns>A <see cref="Task"/> that returns a <see cref="ActionResult"/>.</returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            await Repository.Delete(id);

            return NoContent();
        }

        /// <summary>
        /// Updates the record in table mapped to <typeparamref name="T"/> that matches the <c>id</c> in <paramref name="id"/> with the data in <paramref name="obj"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record to be updated.</param>
        /// <param name="obj">The dono object containing the data to update the record.</param>
        /// <returns>A <see cref="Task"/> that returns a <see cref="ActionResult"/>.</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] TFromBody obj)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            var objUpdate = ToModel(obj);
            objUpdate.Id = id;
            await Repository.Update(objUpdate);

            return NoContent();
        }

        /// <summary>
        /// Method to convert <typeparamref name="TFromBody"/> to <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">The <typeparamref name="TFromBody"/> object to be converted.</param>
        /// <returns>The converted <typeparamref name="T"/> object.</returns>
        [NonAction]
        public T ToModel(TFromBody obj)
        {
            var ret = new T();

            foreach (var tFromBodyProperty in typeof(TFromBody).GetProperties())
            {
                var tProperty = typeof(T).GetProperties().Where(p => p.Name == tFromBodyProperty.Name).FirstOrDefault() ??
                    throw new Exception("Null property when converting FromBody object to Model.");

                if (!(tProperty.PropertyType == tFromBodyProperty.PropertyType))
                    throw new Exception("Error when converting FromBody object to Model. Property types are not the same.");

                if (tProperty.CanWrite)
                    tProperty.SetValue(ret, tFromBodyProperty.GetValue(obj));
            }

            return ret;
        }

        /// <summary>
        /// Method to convert <typeparamref name="T"/> to <typeparamref name="TView"/>.
        /// </summary>
        /// <param name="obj">The <typeparamref name="T"/> object to be converted.</param>
        /// <returns>The converted <typeparamref name="TView"/> object.</returns>
        [NonAction]
        public TView ToView(T obj)
        {
            var ret = new TView();

            foreach (var tViewProperty in typeof(TView).GetProperties())
            {
                var tProperty = typeof(T).GetProperties().Where(p => p.Name == tViewProperty.Name).FirstOrDefault() ??
                    throw new Exception("Null property when converting Model object do View.");

                if (!(tProperty.PropertyType == tViewProperty.PropertyType))
                    throw new Exception("Error when converting Model object to View. Property types are not the same.");

                if (tViewProperty.CanWrite)
                    tViewProperty.SetValue(ret, tProperty.GetValue(obj));
            }

            return ret;
        }
    }
}
