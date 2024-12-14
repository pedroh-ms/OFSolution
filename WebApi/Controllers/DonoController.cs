using Core.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repositories;
using WebApi.Views;

namespace WebApi.Controllers
{
    /// <summary>
    /// This is the controller to perform the dono CRUD operations.
    /// </summary>
    [Route("api/donos")]
    public class DonoController : CRUDControllerBase<DonoModel, DonoController, DonoFromBody, DonoView>
    {
        /// <summary>
        /// This constructor initializes the logger and repository using the generic controller constructor.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public DonoController(ILogger<DonoController> logger, IRepository<DonoModel> repository) : base(logger, repository) { }
    }
}
