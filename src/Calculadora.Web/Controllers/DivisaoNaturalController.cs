using Calculadora.Dominio.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisaoNaturalController : ControllerBase
    {
        private readonly IDivisorNaturalService _divisorNaturalService;

        public DivisaoNaturalController(IDivisorNaturalService divisorNaturalService)
        {
            _divisorNaturalService = divisorNaturalService;
        }

        [HttpGet]
        public IActionResult Get(long numero)
        {
            var result = _divisorNaturalService.DivisoresNaturais(numero);

            if (result == null) return BadRequest(new { Error = "Informe um número maior que zero" });

            return Ok(result);
        }
    }
}
