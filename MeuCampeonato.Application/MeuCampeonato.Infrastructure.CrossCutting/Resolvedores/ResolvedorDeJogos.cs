using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Domain.Projecoes.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.CrossCutting.Resolvedores
{
    public static class ResolvedorDeJogos
    {

        public static List<ProjecaoDeJogo> ChavearJogosSorteados(List<string> times, int qtdeJogos)
        {
            var rnd = new Random();
            int qtdeDeJogosParaSortear = qtdeJogos;
            List<ProjecaoDeJogo> jogosChaveados = new List<ProjecaoDeJogo>();

            while (qtdeDeJogosParaSortear > 0)
            {
                var time1 = times[rnd.Next(times.Count)];
                times.Remove(time1);

                var time2 = times[rnd.Next(times.Count)];
                times.Remove(time2);

                jogosChaveados.Add(new ProjecaoDeJogo()
                {
                    IdTime1 = time1,
                    IdTime2 = time2,
                });

                qtdeDeJogosParaSortear--;
            }
            return jogosChaveados;
        }

        public static List<ProjecaoDeJogo> DefinirPlacares(List<ProjecaoDeJogo> jogos)
        {
            var rnd = new Random();
            var placarasPossiveis = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            foreach (var jogo in jogos)
            {
                jogo.GolsTime1 = placarasPossiveis[rnd.Next(placarasPossiveis.Count)];
                jogo.GolsTime2 = placarasPossiveis[rnd.Next(placarasPossiveis.Count)];
            }

            return jogos;
        }


        public static ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato> DefinirSituacaoTimesFase(
            List<ProjecaoDeJogo> jogos, ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato> times)
        {
            foreach (var jogo in jogos)
            {
                var time1 = times.FirstOrDefault(t => t.IdTime == jogo.IdTime1);
                var time2 = times.FirstOrDefault(t => t.IdTime == jogo.IdTime2);

                if (jogo.GolsTime1 == jogo.GolsTime2)
                {
                    if (time1.Pontuacao == time2.Pontuacao)
                    {
                        if (time1.DataHoraInscricao > time2.DataHoraInscricao)
                            time1.Situacao = "Eliminado";
                        else
                            time2.Situacao = "Eliminado";
                    }
                    else
                    {
                        if (time1.Pontuacao > time2.Pontuacao)
                        {
                            time2.Situacao = "Eliminado";
                        }
                        else
                        {
                            time1.Situacao = "Eliminado";
                        }
                    }
                }
                else if (jogo.GolsTime1 > jogo.GolsTime2)
                {
                    time1.JogosGanhos++;
                    
                    time2.Situacao = "Eliminado";
                    time2.JogosPerdidos++;
                }
                else
                {
                    time2.JogosGanhos++;

                    time1.Situacao = "Eliminado";
                
                    time1.JogosPerdidos++;
                }

                time1.Pontuacao += jogo.GolsTime1 - jogo.GolsTime2;
                time1.GolsFeitos += jogo.GolsTime1;
                time1.GolsTomados += jogo.GolsTime2;

                time2.Pontuacao += jogo.GolsTime2 - jogo.GolsTime1;
                time2.GolsFeitos += jogo.GolsTime2;
                time2.GolsTomados += jogo.GolsTime1;
            }

            return times;
        }

    }
}
