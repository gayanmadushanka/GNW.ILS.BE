using GNW.ILS.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GNW.ILS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class MatterController : Controller
    {
        private readonly IMatterService _matterService;

        public MatterController(IMatterService matterService)
        {
            _matterService = matterService;
        }
    }
}