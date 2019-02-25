using GNW.ILS.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GNW.ILS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            _clientService.GetClients();
            return null;
        }
    }
}