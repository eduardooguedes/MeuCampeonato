using MeuCampeonato.Domain.DTOs.Time;
using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Domain.Projecoes.Time;
using MeuCampeonato.Infrastructure.CrossCutting.Resolvedores;
using MeuCampeonato.Infrastructure.Data.Interfaces;
using MeuCampeonato.Services.Interfaces;

namespace MeuCampeonato.Services.TimeService
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _timeRepository;
        public TimeService(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> GetTimesDoCampeonato(Guid idCampeonato)
        {
            return await _timeRepository.GetTimesNoCampeonato(idCampeonato);
        }

        public async Task<ICollection<DtoDeTime>> PostTimes(List<DtoDeTime> times)
        {
            return await _timeRepository.PostTimes(times);
        }

        public async Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> PutTimeNoCampeonato(List<ProjecaoDeJogo> jogos, Guid idCampeonato)
        {
            var listaDosTimes = new List<string>();
            listaDosTimes.AddRange(jogos.Select(j => j.IdTime1.ToString()).ToList());
            listaDosTimes.AddRange(jogos.Select(j => j.IdTime2.ToString()).ToList());

            return await _timeRepository.PutTimesNoCampeonato(listaDosTimes, idCampeonato, jogos);
        }
    }
}
