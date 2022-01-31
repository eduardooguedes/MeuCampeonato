using MeuCampeonato.Domain.DTOs.Time;
using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Domain.Projecoes.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Services.Interfaces
{
    public interface ITimeService
    {
        Task<ICollection<DtoDeTime>> PostTimes(List<DtoDeTime> times);
        Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> PutTimeNoCampeonato(List<ProjecaoDeJogo> jogos, Guid idCampeonato);
        Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> GetTimesDoCampeonato(Guid idCampeonato);

    }
}
