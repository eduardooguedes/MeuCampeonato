using System;
using System.Collections.Generic;

namespace MeuCampeonato.Infrastructure.Data.Entitys
{
    public partial class Time
    {
        public Time()
        {
            CampeonatoTimes = new HashSet<CampeonatoTime>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public int JogosGanhos { get; set; }
        public int JogosPerdidos { get; set; }
        public int GolsFeitos { get; set; }
        public int GolsTomados { get; set; }
        public DateTime DataHoraCriado { get; set; }

        public virtual ICollection<CampeonatoTime> CampeonatoTimes { get; set; }
    }
}
