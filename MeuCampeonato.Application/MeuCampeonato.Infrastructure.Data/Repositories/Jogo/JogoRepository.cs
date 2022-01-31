using MeuCampeonato.Domain.Projecoes.Fase;
using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Infrastructure.CrossCutting.Resolvedores;
using MeuCampeonato.Infrastructure.Data.Entitys;
using MeuCampeonato.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.Data.Repositories.Jogo
{
    public class JogoRepository : IJogoRepository
    {
        private readonly EntityContext _context;
        public JogoRepository(EntityContext context)
        {
            _context = context;
        }
        public async Task<ICollection<ProjecaoDeJogo>> PostEscalaDeJogosDaFase(List<ProjecaoDeJogo> jogos)
        {
            try
            {
                List<Entitys.JogosFase> jogosEscalados = new List<JogosFase>();
                foreach (var jogo in jogos)
                {
                    jogosEscalados.Add(new Entitys.JogosFase()
                    {
                        Id = ResolvedorDeID.GerarGuid(),
                        IdFase = Guid.Parse(jogo.IdFase),
                        IdTime1 = Guid.Parse(jogo.IdTime1),
                        IdTime2 = Guid.Parse(jogo.IdTime2),
                        GolsTime1 = jogo.GolsTime1,
                        GolsTime2 = jogo.GolsTime2,
                    });
                }

                await _context.JogosFases.AddRangeAsync(jogosEscalados);
                await _context.SaveChangesAsync();

                var escalaDeJogos = (from j in jogosEscalados
                                     select new ProjecaoDeJogo()
                                     {
                                         Id = j.Id.ToString(),
                                         IdFase = j.IdFase.ToString(),
                                         IdTime1 = j.IdTime1.ToString(),
                                         IdTime2 = j.IdTime2.ToString(),
                                         GolsTime1 = j.GolsTime1,
                                         GolsTime2 = j.GolsTime2
                                     }).ToList();

                return escalaDeJogos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar jogos: " + ex.GetBaseException().Message);
            }


        }

        public async Task PutJogos(ICollection<ProjecaoDeJogo> jogos)
        {
            try
            {
                List<JogosFase> jogosFase = new List<JogosFase>(); 
                foreach (var jogo in jogos)
                {
                    jogosFase.Add(new JogosFase()
                    {
                        Id = Guid.Parse(jogo.Id),
                        IdTime1 = Guid.Parse(jogo.IdTime1),
                        IdTime2 = Guid.Parse(jogo.IdTime2),
                        GolsTime1 = jogo.GolsTime1,
                        GolsTime2 = jogo.GolsTime2,
                        IdFase = Guid.Parse(jogo.IdFase),
                    });
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar jogos: " + ex.GetBaseException().Message);
            }
        }
    }
}
