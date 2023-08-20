using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the controller to perform the carro CRUD operations.
    /// </summary>
    [Route("api/carros")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ILogger<CarroController> _logger;
        private readonly IRepository<CarroModel> _repository;

        /// <value>
        /// Gets the logger.
        /// </value>
        public ILogger<CarroController> Logger => _logger;
        /// <value>
        /// Gets the repository.
        /// </value>
        public IRepository<CarroModel> Repository => _repository;

        /// <summary>
        /// This constructor initializes the logger and repository.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public CarroController(ILogger<CarroController> logger, IRepository<CarroModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Gets all the records from the table <c>carros</c>.
        /// </summary>
        /// <returns>A <see cref="Task"/> that returns a <see cref="IEnumerable{T}"/> of <see cref="CarroView"/></returns>
        [HttpGet]
        public async Task<IEnumerable<CarroView>> Get()
        {
            var carros = await Repository.Get();

            if (carros != null)
                return carros.Select(x => ToView(x)).ToList();
            else
                return new List<CarroView>();
        }

        /// <summary>
        /// Get a record in table <c>carros</c> by its <c>id</c>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record in <c>carros</c> to be fetched.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{T}"/> of <see cref="CarroView"/> containing the data in the record with matched <c>id</c>.</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarroView>> Get(int id)
        {
            var carro = await Repository.Get(id);

            if (carro != null)
                return ToView(carro);
            else
                return NotFound();
        }

        /// <summary>
        /// Inserts a record with the data in <paramref name="carro"/>.
        /// </summary>
        /// <param name="carro">The mapped carro object containing the data to be inserted.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{TValue}"/> of <see cref="CarroView"/> with the data inserted.</returns>
        [HttpPost]
        public async Task<ActionResult<CarroView>> Post([FromBody] CarroFromBody carro)
        {
            return ToView(await Repository.Create(ToModel(carro)));
        }

        /// <summary>
        /// Deletes the record in table <c>carros</c> that matches the <c>id</c> in <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record in <c>carros</c> to be deleted.</param>
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
        /// Updates the record in table <c>carros</c> that matches the <c>id</c> in <paramref name="id"/> with the data in <paramref name="carro"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record to be updated.</param>
        /// <param name="carro">The carro object containing the data to update the record.</param>
        /// <returns>A <see cref="Task"/> that returns a <see cref="ActionResult"/>.</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CarroFromBody carro)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            var carroUpdate = ToModel(carro);
            carroUpdate.Id = id;
            await Repository.Update(carroUpdate);

            return NoContent();
        }

        /// <summary>
        /// Method to convert <see cref="CarroFromBody"/> to <see cref="CarroModel"/>.
        /// </summary>
        /// <param name="carro">The <see cref="CarroFromBody"/> object to be converted.</param>
        /// <returns>The converted <see cref="CarroModel"/> object.</returns>
        [NonAction]
        public CarroModel ToModel(CarroFromBody carro)
        {
            return new CarroModel
            {
                DonoId = carro.DonoId,
                Nome = carro.Nome,
                Cor = carro.Cor
            };
        }

        /// <summary>
        /// Method to convert <see cref="CarroModel"/> to <see cref="CarroView"/>.
        /// </summary>
        /// <param name="carro">The <see cref="CarroModel"/> object to be converted.</param>
        /// <returns>The converted <see cref="CarroView"/> object.</returns>
        [NonAction]
        public CarroView ToView(CarroModel carro)
        {
            return new CarroView
            {
                Id = carro.Id,
                DonoId = carro.DonoId,
                Nome = carro.Nome,
                Cor = carro.Cor
            };
        }
    }
}
