using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the controller to perform the material comprado CRUD operations.
    /// </summary>
    [Route("api/material_comprados")]
    [ApiController]
    public class MaterialCompradoController : ControllerBase
    {
        private readonly ILogger<MaterialCompradoController> _logger;
        private readonly IRepository<MaterialCompradoModel> _repository;

        /// <value>
        /// Gets the logger.
        /// </value>
        public ILogger<MaterialCompradoController> Logger => _logger;
        /// <value>
        /// Gets the repository.
        /// </value>
        public IRepository<MaterialCompradoModel> Repository => _repository;

        /// <summary>
        /// This constructor initializes the logger and repository.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public MaterialCompradoController(ILogger<MaterialCompradoController> logger, IRepository<MaterialCompradoModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Gets all the records from the table <c>material_comprados</c>.
        /// </summary>
        /// <returns>A <see cref="Task"/> that returns a <see cref="IEnumerable{T}"/> of <see cref="DonoView"/></returns>
        [HttpGet]
        public async Task<IEnumerable<MaterialCompradoView>> Get()
        {
            var materialComprados = await Repository.Get();

            if (materialComprados != null)
                return materialComprados.Select(x => ToView(x)).ToList();
            else
                return new List<MaterialCompradoView>();
        }

        /// <summary>
        /// Get a record in table <c>material_comprados</c> by its <c>id</c>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record in <c>material_comprados</c> to be fetched.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{T}"/> of <see cref="MaterialCompradoView"/> containing the data in the record with matched <c>id</c>.</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MaterialCompradoView>> Get(int id)
        {
            var materialComprado = await Repository.Get(id);

            if (materialComprado != null)
                return ToView(materialComprado);
            else
                return NotFound();
        }

        /// <summary>
        /// Inserts a record with the data in <paramref name="materialComprado"/>.
        /// </summary>
        /// <param name="materialComprado">The mapped dono object containing the data to be inserted.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{TValue}"/> of <see cref=MaterialCompradoView"/> with the data inserted.</returns>
        [HttpPost]
        public async Task<ActionResult<MaterialCompradoView>> Post([FromBody] MaterialCompradoFromBody materialComprado)
        {
            return ToView(await Repository.Create(ToModel(materialComprado)));
        }

        /// <summary>
        /// Deletes the record in table <c>material_comprados</c> that matches the <c>id</c> in <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record in <c>material_comprados</c> to be deleted.</param>
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
        /// Updates the record in table <c>material_comprados</c> that matches the <c>id</c> in <paramref name="id"/> with the data in <paramref name="materialComprado"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record to be updated.</param>
        /// <param name="materialComprado">The material comprado object containing the data to update the record.</param>
        /// <returns>A <see cref="Task"/> that returns a <see cref="ActionResult"/>.</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] MaterialCompradoFromBody materialComprado)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            var materialCompradoUpdate = ToModel(materialComprado);
            materialCompradoUpdate.Id = id;
            await Repository.Update(materialCompradoUpdate);

            return NoContent();
        }

        /// <summary>
        /// Method to convert <see cref="MaterialCompradoFromBody"/> to <see cref="MaterialCompradoModel"/>.
        /// </summary>
        /// <param name="materialComprado">The <see cref="MaterialCompradoFromBody"/> object to be converted.</param>
        /// <returns>The converted <see cref="MaterialCompradoModel"/> object.</returns>
        [NonAction]
        public MaterialCompradoModel ToModel(MaterialCompradoFromBody materialComprado)
        {
            return new MaterialCompradoModel
            {
                Nome = materialComprado.Nome,
                Dia = materialComprado.Dia,
                Preco = materialComprado.Preco
            };
        }

        /// <summary>
        /// Method to convert <see cref="MaterialCompradoModel"/> to <see cref="MaterialCompradoView"/>.
        /// </summary>
        /// <param name="materialComprado">The <see cref="MaterialCompradoModel"/> object to be converted.</param>
        /// <returns>The converted <see cref="MaterialCompradoView"/> object.</returns>
        [NonAction]
        public MaterialCompradoView ToView(MaterialCompradoModel materialComprado)
        {
            return new MaterialCompradoView
            {
                Id = materialComprado.Id,
                Nome = materialComprado.Nome,
                Dia = materialComprado.Dia,
                Preco = materialComprado.Preco
            };
        }
    }
}
