using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.DTOs.ViewDetails;
using EdirSalesBancoDeDados.Application.Exceptions.GrupoExeption;
using EdirSalesBancoDeDados.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdirSalesBancoDeDados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoUseCase _grupoUseCase;
        public GrupoController(IGrupoUseCase grupoUseCase)
        {
            _grupoUseCase = grupoUseCase;
        }
        [HttpGet]
        public async Task<ActionResult> Listar(int pagina, int tamanhoPagina)
        {
            var result = await _grupoUseCase.ListarTodos(pagina, tamanhoPagina);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GrupoDTO>> Add([FromBody] GrupoDTO grupoDto)
        {
            var result = await _grupoUseCase.AddGrupo(grupoDto);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalheGrupoDTO>> Detalhe(int id)
        {
            try
            {
                var result = await _grupoUseCase.DetalhesDoGrupo(id);
                return Ok(result);
            } catch (ExceptionGrupo ex)
            {
                return NotFound(new {mensagemErro = ex.Message});
            }
        }
    }
}
