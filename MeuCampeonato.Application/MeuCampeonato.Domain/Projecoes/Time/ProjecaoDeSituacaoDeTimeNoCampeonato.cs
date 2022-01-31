using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Domain.Projecoes.Time
{
    public class ProjecaoDeSituacaoDeTimeNoCampeonato
    {
        public string IdTime { get; set; }
        public string Situacao { get; set; }
        public int Pontuacao { get; set; }
        public int? Colocacao { get; set; }
        public int JogosGanhos { get; set; }
        public int JogosPerdidos { get; set; }
        public int GolsFeitos { get; set; }
        public int GolsTomados { get; set; }
        public DateTime DataHoraInscricao { get; set; }
        public string Nome { get; set; }
    }
}
