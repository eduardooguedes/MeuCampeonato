using MeuCampeonato.Domain.Projecoes.Fase;
using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Domain.Projecoes.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Services.Interfaces
{
    public interface IJogoService
    {
        Task<ICollection<ProjecaoDeJogo>> PostEscalaDeJogosDaFase(ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato> times, ProjecaoDeFase fase);
        Task PutJogos(ICollection<ProjecaoDeJogo> jogos);
    }
}
