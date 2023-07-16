using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    [Route("api/material_comprados")]
    [ApiController]
    public class MaterialCompradoController : ControllerBase
    {
        private readonly ILogger<MaterialCompradoController> _logger;

        private readonly IRepository<MaterialCompradoModel> _repository;

        public ILogger<MaterialCompradoController> Logger => _logger;

        public IRepository<MaterialCompradoModel> Repository => _repository;

        public MaterialCompradoController(ILogger<MaterialCompradoController> logger, IRepository<MaterialCompradoModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<MaterialCompradoView>> Get()
        {
            var materialComprados = await Repository.Get();

            if (materialComprados != null)
                return materialComprados.Select(x => ToView(x)).ToList();
            else
                return new List<MaterialCompradoView>();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MaterialCompradoView>> Get(int id)
        {
            var materialComprado = await Repository.Get(id);

            if (materialComprado != null)
                return ToView(materialComprado);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<MaterialCompradoView>> Post([FromBody] MaterialCompradoFromBody materialComprado)
        {
            return ToView(await Repository.Create(ToModel(materialComprado)));
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
        public async Task<ActionResult> Put(int id, [FromBody] MaterialCompradoFromBody materialComprado)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            var materialCompradoUpdate = ToModel(materialComprado);
            materialCompradoUpdate.Id = id;
            await Repository.Update(materialCompradoUpdate);

            return NoContent();
        }

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
