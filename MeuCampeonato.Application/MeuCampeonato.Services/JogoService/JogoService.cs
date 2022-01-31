using MeuCampeonato.Domain.Projecoes.Fase;
using MeuCampeonato.Domain.Projecoes.Jogo;
using MeuCampeonato.Domain.Projecoes.Time;
using MeuCampeonato.Infrastructure.CrossCutting.Resolvedores;
using MeuCampeonato.Infrastructure.Data.Interfaces;
using MeuCampeonato.Services.Interfaces;

namespace MeuCampeonato.Services.JogoService
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;
        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<ICollection<ProjecaoDeJogo>> PostEscalaDeJogosDaFase(ICollection<ProjecaoDeSituacaoDeTimeNoCampeonato> times, ProjecaoDeFase fase)
        {
            var timesJogando = (from time in times
                                where time.Situacao == "Jogando"
                                select time.IdTime).ToList();

            if (timesJogando.Count != (fase.QtdeJogos*2))
                throw new Exception($"A quantidade de times jogando é maior do que o esperado para essa fase. Qtde times: {timesJogando.Count}. Qtde jogos: {fase.QtdeJogos}");

            var jogosChaveados = ResolvedorDeJogos.ChavearJogosSorteados(timesJogando, fase.QtdeJogos);

            foreach (var jogo in jogosChaveados)
            {
                jogo.IdFase = fase.IdFase;
            }

            return await _jogoRepository.PostEscalaDeJogosDaFase(jogosChaveados);
        }

        public async Task PutJogos(ICollection<ProjecaoDeJogo> jogos)
        {
            await _jogoRepository.PutJogos(jogos);
        }
    }
}
