using MeuCampeonato.Domain.DTOs.Time;
using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Domain.Projecoes.Time;
using MeuCampeonato.Infrastructure.CrossCutting.Resolvedores;
using MeuCampeonato.Infrastructure.Data.Entitys;
using MeuCampeonato.Infrastructure.Data.Interfaces;

namespace MeuCampeonato.Infrastructure.Data.Repositories.Time
{
    public class TimeRepository : ITimeRepository
    {
        private readonly EntityContext _context;
        public TimeRepository(EntityContext context)
        {
            _context = context;
        }

        public async Task<ICollection<DtoDeTime>> PostTimes(List<DtoDeTime> times)
        {
            try
            {
                List<Entitys.Time> eTimes = new List<Entitys.Time>();
                foreach (var t in times)
                {
                    eTimes.Add(new Entitys.Time()
                    {
                        Id = ResolvedorDeID.GerarGuid(),
                        Nome = t.Nome,
                        DataHoraCriado = DateTime.Now,
                        GolsTomados = 0,
                        GolsFeitos = 0,
                        JogosGanhos = 0,
                        JogosPerdidos = 0
                    });
                }

                using (_context)
                {
                    _context.Times.AddRange(eTimes);
                    await _context.SaveChangesAsync();
                }

                List<DtoDeTime> timesRetorno = new List<DtoDeTime>();
                foreach (var t in eTimes)
                {
                    timesRetorno.Add(new DtoDeTime()
                    {
                        Id = t.Id.ToString(),
                        Nome = t.Nome,
                        DataHoraCriado = t.DataHoraCriado,
                    });
                }

                return timesRetorno;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar times: " + ex.GetBaseException().Message);
            }
        }

        public async Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> GetTimesNoCampeonato(List<string> times, Guid idCampeonato)
        {
            try
            {
                var timesNoCampeonato = _context.CampeonatoTimes
                    .AsEnumerable()
                    .Where(c => times.Contains(c.IdTime.ToString()) && c.IdCampeonato == idCampeonato)
                    .ToList();

                if (times.Any())
                {
                    List<ProjecaoDeSituacaoDeTimeNoCampeonato> timesRetorno = new List<ProjecaoDeSituacaoDeTimeNoCampeonato>();

                    foreach (var t in timesNoCampeonato)
                    {
                        timesRetorno.Add(new ProjecaoDeSituacaoDeTimeNoCampeonato()
                        {
                            IdTime = t.IdTime.ToString(),
                            Colocacao = t.Colocacao,
                            DataHoraInscricao = t.DataHoraInscricao,
                            JogosGanhos = t.JogosGanhos,
                            JogosPerdidos = t.JogosPerdidos,
                            Pontuacao = t.Pontuacao,
                            Situacao = t.Situacao
                        });
                    }

                    return timesRetorno;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar situacao de times no campeonato: " + ex.GetBaseException().Message);
            }
        }

        public async Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> PutTimeNoCampeonato(
            ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato> times, Guid idCampeonato)
        {
            try
            {
                var timesNoCampeonato = new List<Entitys.CampeonatoTime>();
                foreach (var time in times)
                {
                    timesNoCampeonato.Add(new CampeonatoTime()
                    {
                        IdCampeonato = idCampeonato,
                        Colocacao = time.Colocacao,
                        DataHoraInscricao = time.DataHoraInscricao,
                        IdTime = Guid.Parse(time.IdTime),
                        JogosGanhos = time.JogosGanhos,
                        JogosPerdidos = time.JogosPerdidos,
                        GolsFeitos = time.GolsFeitos,
                        GolsTomados = time.GolsTomados,
                        Pontuacao = time.Pontuacao,
                        Situacao = time.Situacao
                    });
                }

                await _context.SaveChangesAsync();
                return times;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar time no campeonato: " + ex.GetBaseException().Message);
            }
        }

        public async Task<ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato>> GetTimesNoCampeonato(Guid idCampeonato)
        {
            try
            {
                var times = _context.CampeonatoTimes.AsEnumerable().Where(t => t.IdCampeonato == idCampeonato).ToList();

                ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato> timesDoCampeonato = new List<ProjecaoDeSituacaoDeTimeNoCampeonato>();

                foreach (var time in times)
                {
                    timesDoCampeonato.Add(new ProjecaoDeSituacaoDeTimeNoCampeonato()
                    {
                        IdTime = time.IdTime.ToString(),
                        Colocacao = time.Colocacao,
                        GolsFeitos = time.GolsFeitos,
                        GolsTomados = time.GolsTomados,
                        DataHoraInscricao = time.DataHoraInscricao,
                        JogosGanhos = time.JogosGanhos,
                        JogosPerdidos = time.JogosPerdidos,
                        Nome = time.IdTimeNavigation != null ? time.IdTimeNavigation.Nome : "",
                        Pontuacao = time.Pontuacao,
                        Situacao = time.Situacao
                    });
                }

                return timesDoCampeonato;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar times do campeonato: "+ex.GetBaseException().Message);
            }
        }
    }
}
