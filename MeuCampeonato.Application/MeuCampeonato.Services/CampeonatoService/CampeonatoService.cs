using MeuCampeonato.Domain.Projecoes.Campeonato;
using MeuCampeonato.Services.Interfaces;
using MeuCampeonato.Infrastructure.Data.Interfaces;

namespace MeuCampeonato.Services.CampeonatoService
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly ICampeonatoRepository _campeonatoRepository;
        private readonly IFaseService _faseService;
        private readonly IJogoService _jogoService;
        public CampeonatoService(
            ICampeonatoRepository campeonatoRepository,
            IFaseService faseService,
            IJogoService jogoService)
        {
            _campeonatoRepository = campeonatoRepository;
            _faseService = faseService;
            _jogoService = jogoService;
        }

        public async Task<ProjecaoDeCampeonato> PostIniciarCampeonato(List<string> timesParticipantes)
        {
            var campeonato = await _campeonatoRepository.PostIniciarCampeonato(timesParticipantes);

            var fases = await _faseService.PostFasesAoCampeonato(Guid.Parse(campeonato.IdCampeonato));

            var quartasDeFinal = fases.Where(f => f.QtdeJogos == 4).FirstOrDefault();

            //var jogos = await _jogoService.PostEscalaDeJogosDaFase(campeonato.TimesNoCampeonato, quartasDeFinal);

            return new ProjecaoDeCampeonato()
            {
                 IdCampeonato = campeonato.IdCampeonato,
                 DataHoraInicio = campeonato.DataHoraInicio,
                 Situacao = campeonato.Situacao,
                 TimesNoCampeonato = campeonato.TimesNoCampeonato,
            };
        }

        public async Task<ProjecaoDeCampeonato> GetSituacaoCampeonato(string idCampeonato)
        {
            return await _campeonatoRepository.GetSituacaoCampeonato(Guid.Parse(idCampeonato));
        }

        public async Task<List<ProjecaoDeCampeonato>> GetCampeonatos(DateTime? dataInicio = null)
        {
            return await _campeonatoRepository.GetCampeonatos(dataInicio);
        }
    }
}
    