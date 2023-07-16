using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    [Route("api/donos")]
    [ApiController]
    public class DonoController : ControllerBase
    {
        private readonly ILogger<DonoController> _logger;

        private readonly IRepository<DonoModel> _repository;

        public ILogger<DonoController> Logger => _logger;

        public IRepository<DonoModel> Repository => _repository;

        public DonoController(ILogger<DonoController> logger, IRepository<DonoModel> repository) 
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<DonoView>> Get()
        {
            var donos = await Repository.Get();

            if (donos != null)
                return donos.Select(x => ToView(x)).ToList();
            else
                return new List<DonoView>();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DonoView>> Get(int id)
        {
            var dono = await Repository.Get(id);

            if (dono != null)
                return ToView(dono);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<DonoView>> Post([FromBody] DonoFromBody dono)
        {
            return ToView(await Repository.Create(ToModel(dono)));
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
        public async Task<ActionResult> Put(int id, [FromBody] DonoFromBody dono)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            var donoUpdate = ToModel(dono);
            donoUpdate.Id = id;
            await Repository.Update(donoUpdate);

            return NoContent();
        }

        [NonAction]
        public DonoModel ToModel(DonoFromBody dono)
        {
            return new DonoModel()
            {
                Nome = dono.Nome,
                NumeroCelular = dono.NumeroCelular
            };
        }

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
