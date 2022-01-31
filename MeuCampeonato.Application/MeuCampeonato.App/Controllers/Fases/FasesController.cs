using MeuCampeonato.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.Application.Controllers.Fases
{
    [Route("Fases")]
    [ApiController]
    public class FasesController : ControllerBase
    {
        private readonly IFaseService _faseService;
        public FasesController(IFaseService faseService)
        {
            _faseService = faseService;
        }

        /// <summary>
        /// Retorna o chaveamento de jogos da fase.
        /// </summary>
        /// <param name="idCampeonato"></param>
        /// <returns></returns>
        [Route("JogosDaFaseAtual/{idCampeonato}")]
        [HttpGet]
        public async Task<IActionResult> GetJogosDaFase([FromRoute] Guid idCampeonato)
        {
            try
            {
                var jogosDaFase = await _faseService.GetJogosDaFaseEmAndamento(idCampeonato);

                if (jogosDaFase == null)
                    return StatusCode(500, "Nenhuma fase em andamento. Campeonato finalizado.");

                return Ok(new { data = jogosDaFase });
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Erro ao retornar jogos da fase: " + ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Retorna as partidas da fase, bem como seus placares e pontuação.
        /// </summary>
        /// <param name="idCampeonato"></param>
        /// <returns></returns>
        [Route("ExecutarPartidasDaFaseAtual/{idCampeonato}")]
        [HttpGet]
        public async Task<IActionResult> GetPartidasDaFase(Guid idCampeonato)
        {
            try
            {
                var partidasRealizadas = await _faseService.ExecutarPartidasDaFase(idCampeonato);

                return Ok(new { data = partidasRealizadas});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao retornar partidas da fase: " + ex.GetBaseException().Message);
            }
        }
    }
}
