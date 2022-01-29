using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.Application.Controllers.Fases
{
    [Route("Fases")]
    [ApiController]
    public class FasesController : ControllerBase
    {   
        /// <summary>
        /// Retorna o chaveamento de jogos da fase.
        /// </summary>
        /// <param name="idCampeonato"></param>
        /// <returns></returns>
        [Route("JogosDaFase/{idCampeonato}")]
        [HttpGet]
        public async Task<IActionResult> GetJogosDaFase(int idCampeonato)
        {
            try
            {
                //servico

                return Ok(new { });
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
        [Route("PartidasDaFase/{idCampeonato}")]
        [HttpGet]
        public async Task<IActionResult> GetPartidasDaFase(int idCampeonato)
        {
            try
            {
                //servico

                return Ok(new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao retornar partidas da fase: " + ex.GetBaseException().Message);
            }
        }
    }
}
