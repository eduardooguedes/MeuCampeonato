using System;
using System.Collections.Generic;

namespace MeuCampeonato.Infrastructure.Data.Entitys
{
    public partial class Fase
    {
        public Fase()
        {
            JogosFases = new HashSet<JogosFase>();
        }

        public Guid Id { get; set; }
        public Guid IdCampeonato { get; set; }
        public string Nome { get; set; } = null!;
        public int QtdeJogos { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }

        public virtual Campeonato IdCampeonatoNavigation { get; set; } = null!;
        public virtual ICollection<JogosFase> JogosFases { get; set; }
    }
}
