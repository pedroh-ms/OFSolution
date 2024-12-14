using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the controller to perform the servico CRUD operations.
    /// </summary>
    [Route("api/servicos")]
    public class ServicoController : CRUDControllerBase<ServicoModel, ServicoController, ServicoFromBody, ServicoView>
    {
        /// <summary>
        /// This constructor initializes the logger and repository using the generic controller constructor.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public ServicoController(ILogger<ServicoController> logger, IRepository<ServicoModel> repository) : base(logger, repository) { }
    }
}
