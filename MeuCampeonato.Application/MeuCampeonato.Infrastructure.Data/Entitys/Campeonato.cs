using System;
using System.Collections.Generic;

namespace MeuCampeonato.Infrastructure.Data.Entitys
{
    public partial class Campeonato
    {
        public Campeonato()
        {
            CampeonatoTimes = new HashSet<CampeonatoTime>();
            Fases = new HashSet<Fase>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public string Situacao { get; set; } = null!;

        public virtual ICollection<CampeonatoTime> CampeonatoTimes { get; set; }
        public virtual ICollection<Fase> Fases { get; set; }
    }
}
