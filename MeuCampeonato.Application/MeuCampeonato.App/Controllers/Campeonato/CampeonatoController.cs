using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.Application.Controllers.Campeonato
{
    [Route("Campeonato")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {   
        /// <summary>
        /// Inicia campeonato a partir de uma lista de 8 times.
        /// </summary>
        /// <param name="timesParticipantes"></param>
        /// <returns></returns>
        [Route("IniciarCampeonato")]
        [HttpPost]
        public async Task<IActionResult> PostIniciarCampeonato(List<string> timesParticipantes)
        {
            try
            {
                if (timesParticipantes.Count > 8)
                    throw new Exception("Limite de 8 times por campeonato excedida.");

                //servico

                return Ok(new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao iniciar campeonato: " + ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Retorna um campeonato, bem como sua situação e colocações.
        /// </summary>
        /// <param name="idCampeonato"></param>
        /// <returns></returns>
        [Route("Campeonato/{idCampeonato}")]
        [HttpGet]
        public async Task<IActionResult> GetSituacaoCampeonato(string idCampeonato)
        {
            try
            {
                //servico
                
                return Ok(new { });
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Erro ao consultar situação do campeonato: " + ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Retorna todos os campeonatos. É possível filtrar por uma data/hora de inicio (campeonatos que foram criados após esta data/hora, serão apresentados).
        /// </summary>
        /// <param name="dataInicio"></param>
        /// <returns></returns>
        [Route("Campeonatos")]
        [Route("Campeonatos/{dataInicio}")]
        [HttpGet]
        public async Task<IActionResult> GetCampeonatosFinalizados(DateTime? dataInicio = null)
        {
            try
            {
                //servico

                return Ok(new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao consultar campeonatos anterioes: "+ex.GetBaseException().Message);
            }
        }

    }
}
