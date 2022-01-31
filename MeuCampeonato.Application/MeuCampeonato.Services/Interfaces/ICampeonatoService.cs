using MeuCampeonato.Domain.Projecoes.Campeonato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Services.Interfaces
{
    public interface ICampeonatoService
    {
        Task<ProjecaoDeCampeonato> PostIniciarCampeonato(List<string> timesParticipantes);
        Task<ProjecaoDeCampeonato> GetSituacaoCampeonato(string idCampeonato);
        Task<List<ProjecaoDeCampeonato>> GetCampeonatos(DateTime? dataInicio=null);

    }
}
