using MeuCampeonato.Domain.Projecoes.Fase;
using MeuCampeonato.Infrastructure.CrossCutting.Resolvedores;
using MeuCampeonato.Infrastructure.Data.Interfaces;
using MeuCampeonato.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCampeonato.Services.FaseService
{
    public class FaseService : IFaseService
    {
        private readonly IFaseRepository _faseRepository;
        private readonly ITimeService _timeService;
        private readonly IJogoService _jogoService;

        public FaseService(IFaseRepository faseRepository,
            ITimeService timeService,
            IJogoService jogoService)
        {
            _faseRepository = faseRepository;
            _timeService = timeService;
            _jogoService = jogoService;
        }

        public async Task<ProjecaoDeFase> GetJogosDaFaseEmAndamento(Guid idCampeonato)
        {
            var times = await _timeService.GetTimesDoCampeonato(idCampeonato);

            var fase = await _faseRepository.GetFaseEmAndamento(idCampeonato);

            var jogos = await _jogoService.PostEscalaDeJogosDaFase(times, fase);

            return await _faseRepository.GetJogosDaFase(Guid.Parse(fase.IdFase));
        }

        public async Task<ProjecaoDeFase> ExecutarPartidasDaFase(Guid idCampeonato)
        {
            var fase = await _faseRepository.GetFaseEmAndamento(idCampeonato);

            var jogosFase = await _faseRepository.GetJogosDaFase(Guid.Parse(fase.IdFase));

            if (jogosFase.Jogos == null || !jogosFase.Jogos.Any())
                throw new Exception("Nenhum jogo para essa fase. Por favor, utilize a rota GET /Fases/JogosDaFaseAtual/{idCampeonato} para gerar os jogos.");

            var jogos = ResolvedorDeJogos.DefinirPlacares(jogosFase.Jogos);
            
            await _timeService.PutTimeNoCampeonato(jogos, idCampeonato);
            await _faseRepository.PutAvancarFaseDoCampeonato(idCampeonato);
            await _jogoService.PutJogos(jogos);

            return await _faseRepository.GetPartidasRealizadasNaFase(Guid.Parse(fase.IdFase));
        }

        public async Task<ICollection<ProjecaoDeFase>> PostFasesAoCampeonato(Guid idCampeonato)
        {
            return await _faseRepository.PostFasesAoCampeonato(idCampeonato);
        }
        
    }
}
