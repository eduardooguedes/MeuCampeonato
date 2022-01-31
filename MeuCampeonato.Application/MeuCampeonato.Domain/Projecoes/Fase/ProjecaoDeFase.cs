using MeuCampeonato.Domain.Projecoes.Jogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Domain.Projecoes.Fase
{
    public class ProjecaoDeFase
    {
        public string IdFase { get; set; }
        public string Nome { get; set; } = null!;
        public int QtdeJogos { get; set; }
        public string Situacao { get; set; }
        public DateTime? DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public List<ProjecaoDeJogo> Jogos { get; set; }
    }
}
