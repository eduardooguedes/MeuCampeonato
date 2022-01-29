using System;
using System.Collections.Generic;

namespace MeuCampeonato.Infrastructure.Data.Entitys
{
    public partial class JogosFase
    {
        public Guid Id { get; set; }
        public Guid? IdFase { get; set; }
        public Guid IdTime1 { get; set; }
        public Guid IdTime2 { get; set; }
        public int GolsTime1 { get; set; }
        public int GolsTime2 { get; set; }

        public virtual Fase? IdFaseNavigation { get; set; }
    }
}
