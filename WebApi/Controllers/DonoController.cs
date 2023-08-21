using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the controller to perform the dono CRUD operations.
    /// </summary>
    [Route("api/donos")]
    [ApiController]
    public class DonoController : ControllerBase
    {
        private readonly ILogger<DonoController> _logger;
        private readonly IRepository<DonoModel> _repository;

        /// <value>
        /// Gets the logger.
        /// </value>
        public ILogger<DonoController> Logger => _logger;
        /// <value>
        /// Gets the repository.
        /// </value>
        public IRepository<DonoModel> Repository => _repository;

        /// <summary>
        /// This constructor initializes the logger and repository.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public DonoController(ILogger<DonoController> logger, IRepository<DonoModel> repository) 
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Gets all the records from the table <c>donos</c>.
        /// </summary>
        /// <returns>A <see cref="Task"/> that returns a <see cref="IEnumerable{T}"/> of <see cref="DonoView"/></returns>
        [HttpGet]
        public async Task<IEnumerable<DonoView>> Get()
        {
            var donos = await Repository.Get();

            if (donos != null)
                return donos.Select(x => ToView(x)).ToList();
            else
                return new List<DonoView>();
        }

        /// <summary>
        /// Get a record in table <c>donos</c> by its <c>id</c>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record in <c>donos</c> to be fetched.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{T}"/> of <see cref="DonoView"/> containing the data in the record with matched <c>id</c>.</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DonoView>> Get(int id)
        {
            var dono = await Repository.Get(id);

            if (dono != null)
                return ToView(dono);
            else
                return NotFound();
        }

        /// <summary>
        /// Inserts a record with the data in <paramref name="dono"/>.
        /// </summary>
        /// <param name="dono">The mapped dono object containing the data to be inserted.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{TValue}"/> of <see cref=DonoView"/> with the data inserted.</returns>
        [HttpPost]
        public async Task<ActionResult<DonoView>> Post([FromBody] DonoFromBody dono)
        {
            return ToView(await Repository.Create(ToModel(dono)));
        }

        /// <summary>
        /// Deletes the record in table <c>donos</c> that matches the <c>id</c> in <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record in <c>donos</c> to be deleted.</param>
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
        /// Updates the record in table <c>donos</c> that matches the <c>id</c> in <paramref name="id"/> with the data in <paramref name="dono"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record to be updated.</param>
        /// <param name="dono">The dono object containing the data to update the record.</param>
        /// <returns>A <see cref="Task"/> that returns a <see cref="ActionResult"/>.</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DonoFromBody dono)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            var donoUpdate = ToModel(dono);
            donoUpdate.Id = id;
            await Repository.Update(donoUpdate);

            return NoContent();
        }

        /// <summary>
        /// Method to convert <see cref="DonoFromBody"/> to <see cref="DonoModel"/>.
        /// </summary>
        /// <param name="dono">The <see cref="DonoFromBody"/> object to be converted.</param>
        /// <returns>The converted <see cref="DonoModel"/> object.</returns>
        [NonAction]
        public DonoModel ToModel(DonoFromBody dono)
        {
            return new DonoModel()
            {
                Nome = dono.Nome,
                NumeroCelular = dono.NumeroCelular
            };
        }

        /// <summary>
        /// Method to convert <see cref="DonoModel"/> to <see cref="DonoView"/>.
        /// </summary>
        /// <param name="dono">The <see cref="DonoModel"/> object to be converted.</param>
        /// <returns>The converted <see cref="DonoView"/> object.</returns>
        [NonAction]
        public DonoView ToView(DonoModel dono)
        {
            return new DonoView
            {
                Id = dono.Id,
                Nome = dono.Nome,
                NumeroCelular = dono.NumeroCelular,
            };
        }
    }
}
