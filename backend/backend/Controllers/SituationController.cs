using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("situation")]
    public class SituationController : Controller
    {
        private readonly ISituationService _situationService;
        public SituationController(ISituationService situationService)
        { 
            _situationService = situationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var situations = await _situationService.GetSituationsAsync();
            return Ok(situations);
        }
    }
}
