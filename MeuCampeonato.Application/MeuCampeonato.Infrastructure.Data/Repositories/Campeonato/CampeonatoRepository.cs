using MeuCampeonato.Domain.Projecoes.Campeonato;
using MeuCampeonato.Domain.Projecoes.Time;
using MeuCampeonato.Infrastructure.CrossCutting.Resolvedores;
using MeuCampeonato.Infrastructure.Data.Entitys;
using MeuCampeonato.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.Data.Repositories.Campeonato
{
    public class CampeonatoRepository : ICampeonatoRepository
    {
        private readonly EntityContext _context;

        public CampeonatoRepository(EntityContext context)
        {
            _context = context;
        }

        public async Task<ProjecaoDeCampeonato> PostIniciarCampeonato(List<string> timesParticipantes)
        {
            try
            {
                Guid idCampeonato = ResolvedorDeID.GerarGuid();
                var campeonato = new Entitys.Campeonato()
                {
                    Id = idCampeonato,
                    Nome = $"Novo campeonato: {idCampeonato.ToString().Remove(10)}",
                    DataHoraInicio = DateTime.Now,
                    Situacao = "Em andamento",
                };

                _context.Campeonatos.Add(campeonato);
                await _context.SaveChangesAsync();


                var timesDoCampeonato = new List<Entitys.CampeonatoTime>();

                foreach (var time in timesParticipantes)
                {
                    timesDoCampeonato.Add(new Entitys.CampeonatoTime()
                    {
                        IdCampeonato = campeonato.Id,
                        IdTime = Guid.Parse(time),
                        DataHoraInscricao = DateTime.Now,
                        Pontuacao = 0,
                        Situacao = "Jogando",
                        JogosGanhos = 0,
                        JogosPerdidos = 0,
                        GolsFeitos = 0,
                        GolsTomados = 0,
                    });
                }

                _context.CampeonatoTimes.AddRange(timesDoCampeonato);
                await _context.SaveChangesAsync();

                var novoCampeonato = new ProjecaoDeCampeonato()
                {
                    IdCampeonato = campeonato.Id.ToString(),
                    Nome = campeonato.Nome,
                    Situacao = campeonato.Situacao,
                    DataHoraInicio = campeonato.DataHoraInicio,
                    TimesNoCampeonato = (from timeNoCampeonato in timesDoCampeonato
                                         select new ProjecaoDeSituacaoDeTimeNoCampeonato()
                                         {
                                             IdTime = timeNoCampeonato.IdTime.ToString(),
                                             Nome = timeNoCampeonato.IdTimeNavigation != null ? timeNoCampeonato.IdTimeNavigation.Nome : "",
                                             DataHoraInscricao = timeNoCampeonato.DataHoraInscricao,
                                             Situacao = timeNoCampeonato.Situacao,
                                             JogosGanhos = timeNoCampeonato.JogosGanhos,
                                             JogosPerdidos = timeNoCampeonato.JogosPerdidos,
                                             GolsFeitos = timeNoCampeonato.GolsFeitos,
                                             GolsTomados = timeNoCampeonato.GolsTomados,
                                             Pontuacao = timeNoCampeonato.Pontuacao,
                                             Colocacao = timeNoCampeonato.Colocacao
                                         }).ToList()
                };

                return novoCampeonato;

            }
            catch (Exception ex)
            {
                //deletar campeonato
                throw new Exception("Erro ao iniciar campeonato: " + ex.GetBaseException().Message);
            }
        }

        public async Task<ProjecaoDeCampeonato> GetSituacaoCampeonato(Guid idCampeonato)
        {
            try
            {
                var campeonato = _context.Campeonatos.Where(c => c.Id == idCampeonato).FirstOrDefault();
                var timesNoCampeonato = _context.CampeonatoTimes.Where(t => t.IdCampeonato == campeonato.Id);

                if (campeonato!=null)
                    return new ProjecaoDeCampeonato()
                    {
                        IdCampeonato = campeonato.Id.ToString(),
                        Nome = campeonato.Nome,
                        DataHoraInicio = campeonato.DataHoraInicio,
                        DataHoraFim = campeonato.DataHoraFim,
                        Situacao = campeonato.Situacao,
                        TimesNoCampeonato = (from timeNoCampeonato in timesNoCampeonato
                                             select new ProjecaoDeSituacaoDeTimeNoCampeonato()
                                             {
                                                 IdTime = timeNoCampeonato.IdTime.ToString(),
                                                 Nome = timeNoCampeonato.IdTimeNavigation != null ? timeNoCampeonato.IdTimeNavigation.Nome : "",
                                                 Situacao = timeNoCampeonato.Situacao,
                                                 Colocacao = timeNoCampeonato.Colocacao,
                                                 DataHoraInscricao =timeNoCampeonato.DataHoraInscricao,
                                                 Pontuacao = timeNoCampeonato.Pontuacao,
                                                 JogosGanhos = timeNoCampeonato.JogosGanhos,
                                                 JogosPerdidos = timeNoCampeonato.JogosPerdidos,
                                             }).ToList(),
                    };

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar situacao de campeonato: "+ex.GetBaseException().Message);
            }
        }

        public async Task<List<ProjecaoDeCampeonato>> GetCampeonatos(DateTime? dataHoraInicio = null)
        {
            try
            {
                List<Entitys.Campeonato> campeonatos = new List<Entitys.Campeonato>();
                if (dataHoraInicio == null)
                {
                    campeonatos = _context.Campeonatos.ToList();
                }
                else
                {
                    campeonatos = _context.Campeonatos.Where(c => c.DataHoraInicio >= dataHoraInicio).ToList();
                }

                var listaCampeonatos = campeonatos.Select(c => c.Id).ToList();

                var times = _context.CampeonatoTimes.Where(c => listaCampeonatos.Contains(c.IdCampeonato)).ToList();

                List<ProjecaoDeCampeonato> situacaoCampeonatos = new List<ProjecaoDeCampeonato>();
                foreach (var c in campeonatos)
                {
                    situacaoCampeonatos.Add(new ProjecaoDeCampeonato()
                    {
                        IdCampeonato = c.Id.ToString(),
                        Nome = c.Nome,
                        DataHoraInicio = c.DataHoraInicio,
                        DataHoraFim = c.DataHoraFim,
                        Situacao = c.Situacao,
                        TimesNoCampeonato = (from t in times
                                             where t.IdCampeonato == c.Id
                                             select new ProjecaoDeSituacaoDeTimeNoCampeonato()
                                             {
                                                 IdTime = t.IdTime.ToString(),
                                                 Nome = t.IdTimeNavigation != null ? t.IdTimeNavigation.Nome : "",
                                                 Colocacao = t.Colocacao,
                                                 Situacao = t.Situacao,
                                                 Pontuacao = t.Pontuacao,
                                                 DataHoraInscricao = t.DataHoraInscricao,
                                                 JogosGanhos = t.JogosGanhos,
                                                 JogosPerdidos = t.JogosPerdidos,
                                             }).ToList(),
                    }) ;
                }

                return situacaoCampeonatos;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar campeonatos: "+ex.GetBaseException().Message);
            }
        }
    }
}