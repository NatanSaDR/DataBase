using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EdirSalesBancoDeDados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipeController : ControllerBase
    {
        private readonly IMunicipeUseCase _municipeUseCase;
        public MunicipeController(IMunicipeUseCase municipeUseCase)
        {
            _municipeUseCase = municipeUseCase;
        }
        [HttpGet]
        public async Task<ActionResult> Listar(int pagina, int tamanhoPagina)
        {
            var result = await _municipeUseCase.ListarTodos(pagina, tamanhoPagina);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MunicipeDTO>> AddMunicipe([FromBody]MunicipeDTO municipeDto)
        {
            var result = await _municipeUseCase.AddMunicipe(municipeDto);
            return Ok(result);
        }
    }
}
