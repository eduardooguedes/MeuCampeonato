using MeuCampeonato.Domain.Projecoes.Fase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Services.Interfaces
{
    public interface IFaseService
    {
        Task<ProjecaoDeFase> GetJogosDaFaseEmAndamento(Guid idCampeonato);
        Task<ProjecaoDeFase> ExecutarPartidasDaFase(Guid idCampeonato);
        Task<ICollection<ProjecaoDeFase>> PostFasesAoCampeonato(Guid idCampeonato);
    }
}
