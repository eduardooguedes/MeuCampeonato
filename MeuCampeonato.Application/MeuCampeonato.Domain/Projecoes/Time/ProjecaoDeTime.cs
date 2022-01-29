using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Domain.Projecoes.Time
{
    public class ProjecaoDeTime
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int JogosGanhos { get; set; }
        public int JogosPerdidos { get; set; }
        public int GolsFeitos { get; set; }
        public int GolsTomados { get; set; }
    }
}
