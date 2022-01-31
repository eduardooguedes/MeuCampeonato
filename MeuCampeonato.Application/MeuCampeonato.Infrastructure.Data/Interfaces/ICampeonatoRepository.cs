using MeuCampeonato.Domain.Projecoes.Campeonato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.Data.Interfaces
{
    public interface ICampeonatoRepository
    {
        Task<ProjecaoDeCampeonato> PostIniciarCampeonato(List<string> timesParticipantes);
        Task<ProjecaoDeCampeonato> GetSituacaoCampeonato(Guid idCampeonato);
        Task<List<ProjecaoDeCampeonato>> GetCampeonatos(DateTime? dataInicio = null);

    }
}
