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
    public class MaterialCompradoController : CRUDControllerBase<MaterialCompradoModel, MaterialCompradoController, MaterialCompradoFromBody, MaterialCompradoView>
    {
        /// <summary>
        /// This constructor initializes the logger and repository using the generic controller constructor.
        /// </summary>
        /// <param name="logger">The logger object.</param>
        /// <param name="repository">The repository object.</param>
        public MaterialCompradoController(ILogger<MaterialCompradoController> logger, IRepository<MaterialCompradoModel> repository) : base(logger, repository) { }
    }
}
