using MeuCampeonato.Domain.Projecoes.Fase;
using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Domain.Projecoes.Time;
using MeuCampeonato.Infrastructure.CrossCutting.Resolvedores;
using MeuCampeonato.Infrastructure.Data.Entitys;
using MeuCampeonato.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.Data.Repositories.Fase
{
    public class FaseRepository : IFaseRepository
    {
        private readonly EntityContext _context;
        public FaseRepository(
            EntityContext context)
        {
            _context = context;
        }

        public async Task<ProjecaoDeFase> GetFaseEmAndamento(Guid idCampeonato)
        {
            try
            {
                var fase = _context.Fases
                    .Where(f => f.IdCampeonato == idCampeonato && f.Situacao == "Em andamento")
                    .FirstOrDefault();

                if (fase!=null)
                {
                    var projecaoFase = new ProjecaoDeFase()
                    {
                        IdFase = fase.Id.ToString(),
                        Nome = fase.Nome,
                        QtdeJogos = fase.QtdeJogos,
                        Situacao = fase.Situacao ?? "",
                        DataHoraInicio = fase.DataHoraInicio,
                        DataHoraFim = fase.DataHoraFim,
                    };

                    return projecaoFase;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar fase em andamento: "+ex.GetBaseException().Message);
            }
        }

        public async Task<ProjecaoDeFase> GetJogosDaFase(Guid idFase)
        {
            try
            {
                var fase = _context.Fases.Where(f => f.Id == idFase && f.Situacao == "Em andamento").FirstOrDefault();

                if (fase!=null)
                {
                    var jogos = _context.JogosFases.Where(j => j.IdFase == fase.Id).ToList();

                    var projecaoFase = new ProjecaoDeFase()
                    {
                        IdFase = fase.Id.ToString(),
                        Nome = fase.Nome,
                        Situacao = fase.Situacao,
                        DataHoraInicio = fase.DataHoraInicio,
                        QtdeJogos = fase.QtdeJogos,
                        DataHoraFim = fase.DataHoraFim,
                        Jogos = (from jogo in jogos
                                 select new ProjecaoDeJogo()
                                 {
                                     Id = jogo.Id.ToString(),
                                     IdFase = fase.Id.ToString(),
                                     IdTime1 = jogo.IdTime1.ToString(),
                                     IdTime2 = jogo.IdTime2.ToString(),
                                     GolsTime1 = jogo.GolsTime1,
                                     GolsTime2= jogo.GolsTime2,
                                 }).ToList(),
                    };

                    jogos.Clear();
                    return projecaoFase;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar jogos da fase: " + ex.GetBaseException().Message);
            }
        }

        public async Task<ProjecaoDeFase> GetPartidasRealizadasNaFase(Guid idFase)
        {
            try
            {
                var fase = _context.Fases.Where(f => f.Id == idFase).FirstOrDefault();
                var jogos = _context.JogosFases.Where(j => j.IdFase == fase.Id).ToList();

                var projecaoFase = new ProjecaoDeFase()
                {
                    IdFase = fase.Id.ToString(),
                    Nome = fase.Nome,
                    DataHoraInicio = fase.DataHoraInicio,
                    DataHoraFim = fase.DataHoraFim,
                    QtdeJogos = fase.QtdeJogos,
                    Situacao = fase.Situacao,
                    Jogos = (from j in jogos
                             select new ProjecaoDeJogo()
                             {
                                 Id = j.Id.ToString(),
                                 IdFase = fase.Id.ToString(),
                                 GolsTime1 = j.GolsTime1,
                                 GolsTime2 = j.GolsTime2,
                                 IdTime1 = j.IdTime1.ToString(),
                                 IdTime2 = j.IdTime2.ToString(),
                             }).ToList(),
                };

                return projecaoFase;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar partidas realizadas na fase: " + ex.GetBaseException().Message);
            }
        }

        public async Task<ICollection<ProjecaoDeFase>> PostFasesAoCampeonato(Guid idCampeonato)
        {
            try
            {
                List<Entitys.Fase> fases = new List<Entitys.Fase>();

                fases.Add(new Entitys.Fase()
                {
                    Id = ResolvedorDeID.GerarGuid(),
                    DataHoraInicio = DateTime.Now,
                    Nome = "Quartas de finais",
                    Situacao = "Em andamento",
                    QtdeJogos = 4,
                    IdCampeonato = idCampeonato
                });

                fases.Add(new Entitys.Fase()
                {
                    Id = ResolvedorDeID.GerarGuid(),
                    Nome = "Semifinal",
                    Situacao = "",
                    QtdeJogos = 2,
                    IdCampeonato = idCampeonato
                });

                fases.Add(new Entitys.Fase()
                {
                    Id = ResolvedorDeID.GerarGuid(),
                    Nome = "Terceiro lugar",
                    Situacao = "",
                    QtdeJogos = 1,
                    IdCampeonato = idCampeonato
                });

                fases.Add(new Entitys.Fase()
                {
                    Id = ResolvedorDeID.GerarGuid(),
                    Nome = "Final",
                    Situacao = "",
                    QtdeJogos = 1,
                    IdCampeonato = idCampeonato
                });

                await _context.Fases.AddRangeAsync(fases);
                await _context.SaveChangesAsync();

                List<ProjecaoDeFase> fasesNovas = new List<ProjecaoDeFase>();
                foreach (var fase in fases)
                {
                    fasesNovas.Add(new ProjecaoDeFase()
                    {
                        IdFase = fase.Id.ToString(),
                        DataHoraInicio = fase.DataHoraInicio,
                        Situacao = fase.Situacao ?? "",
                        Nome = fase.Nome,
                        QtdeJogos = fase.QtdeJogos,
                        DataHoraFim = fase.DataHoraFim,
                    });
                }

                return fasesNovas;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir fases ao campeonato: " + ex.GetBaseException().Message);
            }
        }

        public async Task<ProjecaoDeFase> PutAvancarFaseDoCampeonato(Guid idCampeonato)
        {
            try
            {
                var fases = _context.Fases.Where(f => f.IdCampeonato == idCampeonato).ToList();

                var faseEmAndamento = fases.Where(f => f.Situacao == "Em andamento").FirstOrDefault();
                faseEmAndamento.Situacao = "Finalizada";
                faseEmAndamento.DataHoraFim = DateTime.Now;

                Entitys.Fase proximaFase = new Entitys.Fase();
                switch (faseEmAndamento.Nome)
                {
                    case "Quartas de finais":
                        proximaFase = fases.Where(f => f.Nome == "Semifinal").FirstOrDefault();
                        break;
                    case "Semifinal":
                        proximaFase = fases.Where(f => f.Nome == "Terceiro lugar").FirstOrDefault();
                        break;
                    case "Terceiro lugar":
                        proximaFase = fases.Where(f => f.Nome == "Final").FirstOrDefault();
                        break;
                }
                proximaFase.Situacao = "Em andamento";
                proximaFase.DataHoraInicio = DateTime.Now;

                _context.Fases.Update(faseEmAndamento);
                _context.Fases.Update(proximaFase);
                await _context.SaveChangesAsync();

                return new ProjecaoDeFase()
                {
                    IdFase = proximaFase.Id.ToString(),
                    Nome = proximaFase.Nome,
                    Situacao = proximaFase.Situacao,
                    DataHoraInicio = proximaFase.DataHoraInicio,
                    QtdeJogos = proximaFase.QtdeJogos,
                };

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao avancar fase do campeonato: "+ex.GetBaseException().Message);
            }
        }
    }
}
