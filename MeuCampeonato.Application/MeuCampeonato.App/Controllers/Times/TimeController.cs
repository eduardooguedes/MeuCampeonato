using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.Application.Controllers.Times
{
    [Route("Times")]
    [ApiController]
    public class TimeController : ControllerBase
    {

        /// <summary>
        /// Cadastra uma lista de times.
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        [Route("CadastrarTimes")]
        [HttpPost]
        public async Task<IActionResult> PostTimes(List<dynamic> times)
        {
            try
            {   
                //servico 

                return Ok(new { });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao inserir times: " + ex.GetBaseException().Message);
            }
        }
    }
}
