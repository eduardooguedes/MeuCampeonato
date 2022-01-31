using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Domain.Projecoes.Jogo
{
    public class ProjecaoDeJogo
    {
        public string Id { get; set; }
        public string IdFase { get; set; }
        public string IdTime1 { get; set; }
        public string IdTime2 { get; set; }
        public int GolsTime1 { get; set; }
        public int GolsTime2 { get; set; }
    }
}
