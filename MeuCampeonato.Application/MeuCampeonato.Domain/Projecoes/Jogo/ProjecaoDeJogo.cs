using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Domain.Projecoes.Jogo
{
    public class ProjecaoDeJogo
    {
        public Guid Id { get; set; }
        public Guid? IdFase { get; set; }
        public Guid IdTime1 { get; set; }
        public Guid IdTime2 { get; set; }
        public int GolsTime1 { get; set; }
        public int GolsTime2 { get; set; }
    }
}
