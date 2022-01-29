using MeuCampeonato.Domain.Projecoes.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Domain.Projecoes.Campeonato
{
    public class ProjecaoDeCampeonato
    {
        public string Id { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public string? Situacao { get; set; }
        public List<ProjecaoDeSituacaoDeTimeNoCampeonato> Times { get; set; }
    }
}
