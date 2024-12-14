using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the controller to perform the carro CRUD operations.
    /// </summary>
    [Route("api/carros")]
    public class CarroController : CRUDControllerBase<CarroModel, CarroController, CarroFromBody, CarroView>
    {
        /// <summary>
        /// This constructor initializes the logger and repository using the generic controller constructor.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public CarroController(ILogger<CarroController> logger, IRepository<CarroModel> repository) : base(logger, repository) { }
    }
}
