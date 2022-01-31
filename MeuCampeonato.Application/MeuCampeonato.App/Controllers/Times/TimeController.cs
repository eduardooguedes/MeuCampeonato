using MeuCampeonato.Domain.DTOs.Time;
using MeuCampeonato.Services.Interfaces;
using MeuCampeonato.Services.TimeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.Application.Controllers.Times
{
    [Route("Times")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _timeService;
        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        /// <summary>
        /// Cadastra uma lista de times.
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CadastrarTimes")]
        public async Task<IActionResult> PostTimes(List<DtoDeTime> times)
        {
            try
            {
                var timesCadastrados = _timeService.PostTimes(times); 

                return Ok(new { data = timesCadastrados });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao inserir times: " + ex.GetBaseException().Message);
            }
        }
    }
}
