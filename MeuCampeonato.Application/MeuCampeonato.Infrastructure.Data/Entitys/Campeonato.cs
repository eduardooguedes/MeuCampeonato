using System;
using System.Collections.Generic;

namespace MeuCampeonato.Infrastructure.Data.Entitys
{
    public partial class Campeonato
    {
        public Campeonato()
        {
            Fases = new HashSet<Fase>();
        }

        public Guid Id { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public string? Situacao { get; set; }

        public virtual ICollection<Fase> Fases { get; set; }
    }
}
