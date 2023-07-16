using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    [Route("api/carros")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ILogger<CarroController> _logger;

        private readonly IRepository<CarroModel> _repository;

        public ILogger<CarroController> Logger => _logger;

        public IRepository<CarroModel> Repository => _repository;

        public CarroController(ILogger<CarroController> logger, IRepository<CarroModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<CarroView>> Get()
        {
            var carros = await Repository.Get();

            if (carros != null)
                return carros.Select(x => ToView(x)).ToList();
            else
                return new List<CarroView>();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarroView>> Get(int id)
        {
            var carro = await Repository.Get(id);

            if (carro != null)
                return ToView(carro);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CarroView>> Post([FromBody] CarroFromBody carro)
        {
            return ToView(await Repository.Create(ToModel(carro)));
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
        public async Task<ActionResult> Put(int id, [FromBody] CarroFromBody carro)
        {
            if ((await Repository.Get(id)) == null)
                return NotFound();

            var carroUpdate = ToModel(carro);
            carroUpdate.Id = id;
            await Repository.Update(carroUpdate);

            return NoContent();
        }

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
