using MeuCampeonato.Domain.Projecoes.Fase;
using MeuCampeonato.Domain.Projecoes.Jogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.Data.Interfaces
{
    public interface IJogoRepository
    {
        Task<ICollection<ProjecaoDeJogo>> PostEscalaDeJogosDaFase(List<ProjecaoDeJogo> jogos);
        Task PutJogos(ICollection<ProjecaoDeJogo> jogos);
    }
}
