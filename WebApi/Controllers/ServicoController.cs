using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the controller to perform the servico CRUD operations.
    /// </summary>
    [Route("api/servicos")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ILogger<ServicoController> _logger;
        private readonly IRepository<ServicoModel> _repository;

        /// <value>
        /// Gets the logger.
        /// </value>
        public ILogger<ServicoController> Logger => _logger;
        /// <value>
        /// Gets the repository.
        /// </value>
        public IRepository<ServicoModel> Repository => _repository;

        /// <summary>
        /// This constructor initializes the logger and repository.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public ServicoController(ILogger<ServicoController> logger, IRepository<ServicoModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Gets all the records from the table <c>servicos</c>.
        /// </summary>
        /// <returns>A <see cref="Task"/> that returns a <see cref="IEnumerable{T}"/> of <see cref="ServicoView"/></returns>
        [HttpGet]
        public async Task<IEnumerable<ServicoView>> Get()
        {
            var servicos = await Repository.Get();

            if (servicos != null)
                return servicos.Select(x => ToView(x)).ToList();
            else
                return new List<ServicoView>();
        }

        /// <summary>
        /// Get a record in table <c>servicos</c> by its <c>id</c>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record in <c>servicos</c> to be fetched.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{T}"/> of <see cref="ServicoView"/> containing the data in the record with matched <c>id</c>.</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServicoView>> Get(int id)
        {
            var servico = await Repository.Get(id);

            if (servico != null)
                return ToView(servico);
            else
                return NotFound();
        }

        /// <summary>
        /// Inserts a record with the data in <paramref name="servico"/>.
        /// </summary>
        /// <param name="servico">The mapped dono object containing the data to be inserted.</param>
        /// <returns>A <see cref="Task"/> that returns an <see cref="ActionResult{TValue}"/> of <see cref=ServicoView"/> with the data inserted.</returns>
        [HttpPost]
        public async Task<ActionResult<ServicoView>> Post([FromBody] ServicoFromBody servico)
        {
            return ToView(await Repository.Create(ToModel(servico)));
        }

        /// <summary>
        /// Deletes the record in table <c>servicos</c> that matches the <c>id</c> in <paramref name="id"/>.
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
        /// Updates the record in table <c>servicos</c> that matches the <c>id</c> in <paramref name="id"/> with the data in <paramref name="servico"/>.
        /// </summary>
        /// <param name="id">The <c>id</c> of the record to be updated.</param>
        /// <param name="servico">The servico object containing the data to update the record.</param>
        /// <returns>A <see cref="Task"/> that returns a <see cref="ActionResult"/>.</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ServicoFromBody servico)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            var servicoUpdate = ToModel(servico);
            servicoUpdate.Id = id;
            await Repository.Update(servicoUpdate);

            return NoContent();
        }

        /// <summary>
        /// Method to convert <see cref="ServicoFromBody"/> to <see cref="ServicoModel"/>.
        /// </summary>
        /// <param name="servico">The <see cref="ServicoFromBody"/> object to be converted.</param>
        /// <returns>The converted <see cref="ServicoModel"/> object.</returns>
        [NonAction]
        public ServicoModel ToModel(ServicoFromBody servico)
        {
            return new ServicoModel
            {
                DonoId = servico.DonoId,
                CarroId = servico.CarroId,
                DataEntrega = servico.DataEntrega,
                Preco = servico.Preco,
                Observacao = servico.Observacao
            };
        }

        /// <summary>
        /// Method to convert <see cref="ServicoModel"/> to <see cref="ServicoView"/>.
        /// </summary>
        /// <param name="servico">The <see cref="ServicoModel"/> object to be converted.</param>
        /// <returns>The converted <see cref="ServicoView"/> object.</returns>
        [NonAction]
        public ServicoView ToView(ServicoModel servico)
        {
            return new ServicoView
            {
                Id = servico.Id,
                DonoId = servico.DonoId,
                CarroId = servico.CarroId,
                DataEntrega = servico.DataEntrega,
                Preco = servico.Preco,
                Observacao = servico.Observacao
            };
        }
    }
}
