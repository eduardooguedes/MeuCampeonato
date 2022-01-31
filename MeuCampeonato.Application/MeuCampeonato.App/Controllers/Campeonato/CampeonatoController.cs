using MeuCampeonato.Domain.DTOs.Time;
using MeuCampeonato.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.Application.Controllers.Campeonato
{
    [Route("Campeonato")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoController(ICampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }

        /// <summary>
        /// Inicia campeonato a partir de uma lista de 8 times.
        /// </summary>
        /// <param name="timesParticipantes"></param>
        /// <returns></returns>
        [Route("IniciarCampeonato")]
        [HttpPost]
        public async Task<IActionResult> PostIniciarCampeonato(List<DtoDeTimesParticipantes> timesParticipantes)
        {
            try
            {
                if (timesParticipantes.Count != 8)
                    throw new Exception("Necessários 8 times por campeonato.");

                var result = _campeonatoService.PostIniciarCampeonato(timesParticipantes.Select(t => t.Id.ToString()).ToList());

                return Ok(new { data = result });
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
        [HttpGet]
        [Route("Campeonato/{idCampeonato}")]
        public async Task<IActionResult> GetSituacaoCampeonato(string idCampeonato)
        {
            try
            {
                var situacaoCampeonato = _campeonatoService.GetSituacaoCampeonato(idCampeonato);
                
                return Ok(new {data = situacaoCampeonato });
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Erro ao consultar situação do campeonato: " + ex.GetBaseException().Message);
            }
        }

        /// <summary>
        /// Retorna todos os campeonatos. É possível filtrar por uma data/hora de inicio (campeonatos que foram criados após esta data/hora, serão apresentados).
        /// </summary>
        /// <param name="dataHoraInicio"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Campeonatos")]
        [Route("Campeonatos/{dataHoraInicio}")]
        public async Task<IActionResult> GetCampeonatos(DateTime? dataHoraInicio = null)
        {
            try
            {
                var campeonatos = await _campeonatoService.GetCampeonatos(dataHoraInicio);

                return Ok(new { data = campeonatos});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao consultar campeonatos anterioes: "+ex.GetBaseException().Message);
            }
        }

    }
}
