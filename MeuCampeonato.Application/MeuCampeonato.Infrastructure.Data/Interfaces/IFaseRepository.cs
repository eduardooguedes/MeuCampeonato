using MeuCampeonato.Domain.Projecoes.Fase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Infrastructure.Data.Interfaces
{
    public interface IFaseRepository
    {
        Task<ProjecaoDeFase> GetJogosDaFase(ProjecaoDeFase fase);
        Task<ProjecaoDeFase> GetPartidasRealizadasNaFase(Guid idCampeonato);
        Task<ICollection<ProjecaoDeFase>> PostFasesAoCampeonato(Guid idCampeonato);
        Task<ProjecaoDeFase> PutAvancarFaseDoCampeonato(Guid idCampeonato);
        Task<ProjecaoDeFase> GetFaseEmAndamento(Guid idCampeonato);

    }
}
