using EdirSalesBancoDeDados.Application.DTOs;
using EdirSalesBancoDeDados.Application.DTOs.ViewDetailsSolicitacao;
using EdirSalesBancoDeDados.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdirSalesBancoDeDados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoUseCase _solicitacaoUseCase;
        public SolicitacaoController(ISolicitacaoUseCase solicitacaoUseCase)
        {
            _solicitacaoUseCase = solicitacaoUseCase;
        }

        [HttpGet("ListarTodos")]
        public async Task<ActionResult<ICollection<DetalheSolicitacao>>> Listar(int pagina, int tamanhoPagina)
        {
            try
            {
                var result = await _solicitacaoUseCase.ListarTodos(pagina, tamanhoPagina);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet("BuscarId")]
        public async Task<ActionResult<SolicitacaoDTO>> BuscarId(int id)
        {
            try
            {
                var result = await _solicitacaoUseCase.BuscarPorId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<SolicitacaoDTO>> CadastrarSolicitacao(SolicitacaoDTO solicitacaoDto)
        {
            try
            {
                await _solicitacaoUseCase.AddSolicitacao(solicitacaoDto);
                return Ok(solicitacaoDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{int}", Name = "Atualizar")]
        public async Task<ActionResult<SolicitacaoDTO>> Atualizar(int id, SolicitacaoDTO solicitacaoDto)
        {
            try
            {
                await _solicitacaoUseCase.AtualizarSolicitacao(id, solicitacaoDto);
                return Ok(solicitacaoDto);
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{int}", Name = "Deletar")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                await _solicitacaoUseCase.DeletarSolicitacao(id);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
