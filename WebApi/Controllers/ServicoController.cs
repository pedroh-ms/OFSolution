using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    [Route("api/servicos")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ILogger<ServicoController> _logger;

        private readonly IRepository<ServicoModel> _repository;

        public ILogger<ServicoController> Logger => _logger;

        public IRepository<ServicoModel> Repository => _repository;

        public ServicoController(ILogger<ServicoController> logger, IRepository<ServicoModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ServicoView>> Get()
        {
            var servicos = await Repository.Get();

            if (servicos != null)
                return servicos.Select(x => ToView(x)).ToList();
            else
                return new List<ServicoView>();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServicoView>> Get(int id)
        {
            var servico = await Repository.Get(id);

            if (servico != null)
                return ToView(servico);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ServicoView>> Post([FromBody] ServicoFromBody servico)
        {
            return ToView(await Repository.Create(ToModel(servico)));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            await Repository.Delete(id);

            return NoContent();
        }

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
