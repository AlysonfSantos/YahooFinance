using APIYahooFinance.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIYahooFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceAtivoController : ControllerBase
    {

        private readonly IVariacaoAtivoAppService _variacaoAtivoAppService;
        public FinanceAtivoController(IVariacaoAtivoAppService variacaoAtivoAppService)
        {
            _variacaoAtivoAppService = variacaoAtivoAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarYahooFinance()
        {
            var Result = await _variacaoAtivoAppService.ConsultarYahooFinance();
            if (Result == null) return NotFound("Nenhum Dado encontrado");
            return Ok(Result);
        }

    }




}
