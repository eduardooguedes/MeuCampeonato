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
        /// <summary>
        /// Id GUID do campeonato.
        /// </summary>
        public string IdCampeonato { get; set; }

        /// <summary>
        /// Nome do campeonato.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data e hora do inicio do campeonato.
        /// </summary>
        public DateTime DataHoraInicio { get; set; }

        /// <summary>
        /// Data e hora final do campeonato.
        /// </summary>
        public DateTime? DataHoraFim { get; set; }

        /// <summary>
        /// Situacao do campeonato. [ Em andamento | Finalizado ]
        /// </summary>
        public string? Situacao { get; set; }

        /// <summary>
        /// Informações dos times do campeonato.
        /// </summary>
        public List<ProjecaoDeSituacaoDeTimeNoCampeonato> TimesNoCampeonato { get; set; }
    }
}
