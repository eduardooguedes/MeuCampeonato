using MeuCampeonato.Domain.DTOs.Time;
using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Domain.Projecoes.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.Data.Interfaces
{
    public interface ITimeRepository
    {
        Task<ICollection<DtoDeTime>> PostTimes(List<DtoDeTime> times);
        Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> GetTimesNoCampeonato(Guid idCampeonato);
        Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> GetTimesNoCampeonato(List<string> times, Guid idCampeonato);
        Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> PutTimesNoCampeonato(ICollection<string> listaTimes, Guid idCampeonato, List<ProjecaoDeJogo> jogos);
    }
}
