using System;
using System.Collections.Generic;

namespace MeuCampeonato.Infrastructure.Data.Entitys
{
    public partial class CampeonatoTime
    {
        public Guid IdCampeonato { get; set; }
        public Guid IdTime { get; set; }
        public int Pontuacao { get; set; }
        public int? Colocacao { get; set; }
        public int JogosGanhos { get; set; }
        public int JogosPerdidos { get; set; }
        public DateTime DataHoraInscricao { get; set; }

        public virtual Campeonato IdCampeonatoNavigation { get; set; } = null!;
        public virtual Time IdTimeNavigation { get; set; } = null!;
    }
}
