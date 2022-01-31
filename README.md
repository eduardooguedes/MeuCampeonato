# MeuCampeonato

"José Gustavo, apaixonado por futebol e tecnologia, deseja ter uma
aplicação que simule os campeonatos de futebol do seu bairro, chamada Meu
Campeonato." - Trade Technology.

Segue passos, rotas e script para implementação do projeto:
<h3>
 Passos:
 </h3>
  <li> Implementação do Diagrama de Entidade e Relacionamento (em meu caderno por enquanto) </li>
  <li> Implementação do script de criação do banco de dados</li>
  <li> Elaboração escrita das rotas e seus objetos de retorno (controllers)</li>
  <li> Implementação base da api (arquitetura, separação de camadas, implementação das rotas)</li>
  <li> Importação das entidades do banco para o código via Entity Core (code first from database)</li>
  
  <li> Implementação dos domínios (classes/objetos de retorno/projeções)</li>
  <li> Implementação dos serviços (regras de negócio)</li>
  <li> Implementação dos repositórios (consumo do banco de dados)</li>
  <li> Implementação da documentação em Swagger</li>
 
 
 
 <h3>
 Rotas:
 </h3>
 * POST {{baseurl}}/Times/CadastrarTimes
   Rota utilizada para cadastrar times na aplicação. 
   Não há um limite de times para ser cadastrados. 
   Retorna como resposta uma lista de times com id, nome e data/hora de criação.
   Para cadastrar é necessário apenas nome do time.
   Json exemplo:
     {
        "Id": "",
        "Nome": "Palmeiras"
    },
    {
        "Id": "",
        "Nome": "Corinthians"
    }
 
 * POST {{baseUrl}}/Campeonato/IniciarCampeonato
    Rota que inicia um campeonato a partir de uma lista de times.
    Somente é possivel iniciar um campeonato com uma lista de 8 times.
    Json exemplo:
       [
        {
            "Id": "071c39b0-935c-4579-9d6c-f0bd94dbb229"
        },
        {
            "Id": "66292710-586e-4dd6-baef-45daebf52dd4"
        },
        {
            "Id": "9f90dcd6-428b-43d1-8677-2d98c03a1723"
        },
        {
            "Id": "f17bb88a-6b20-47b1-a1b2-3efcfac5857a"
        },
        {
            "Id": "06e699aa-ef40-4c27-bbf6-1ec797509822"
        },
        {
            "Id": "18e9ad20-0bee-4879-aa2e-49de0f11a186"
        },
        {
            "Id": "e3811160-3eaf-4cc6-a1ad-1cb7125da92a"
        },
        {
            "Id": "448e101b-4729-4f35-bc6f-b232fb2b6416"
        }
       ]

 * GET {{baseUrl}}/Fases/JogosDaFaseAtual/{idCampeonato}
    Gera os jogos aleatoriamente para a fase em andamento.
    Os jogos serão executados no próximo GET.
    Json retorno exemplo:
       
       
 * GET {{baseUrl}}/ExecutarPartidasDaFaseAtual/{idCampeonato}
   Executa as partidas da fase em andamento a partir dos jogos sorteados no GET anterior.
   Também avança para a próxima fase.
   Executar o GET anterior para gerar os proximos jogos.
   Json retorno exemplo:
   
 
 
 * GET {{baseUrl}}/Campeonato/{idCampeonato}
    Retorna situacao do campeonato a partir do seu id.
    Json retorno exemplo:
       
 * GET Campeonatos - Campeonatos/{dataInicio}
    Retorna todos os campeonatos já cadastrados. 
    É possivel filtrar por data/hora de inicio dos campeonatos. 
    Nesse caso, apenas campeonatos criados a partir dessa data/hora serão retornados.
    Json retorno exemplo:
   
   
 
 <h3>
 Script de criação do banco de dados:
 </h3>
CREATE TABLE CAMPEONATO
(
	ID uniqueidentifier PRIMARY KEY,
	NOME VARCHAR(30) NOT NULL,
	DATA_HORA_INICIO DATETIME NOT NULL,
	DATA_HORA_FIM DATETIME NULL,
	SITUACAO VARCHAR(30) NOT NULL,	
)


CREATE TABLE TIME
(
	ID uniqueidentifier PRIMARY KEY,
	NOME VARCHAR(30) NOT NULL,
	JOGOS_GANHOS INT NOT NULL,
	JOGOS_PERDIDOS INT NOT NULL,
	GOLS_FEITOS INT NOT NULL,
	GOLS_TOMADOS INT NOT NULL,
	DATA_HORA_CRIADO DATETIME NOT NULL
)


CREATE TABLE CAMPEONATO_TIME
(
	ID_CAMPEONATO uniqueidentifier NOT NULL,
	ID_TIME uniqueidentifier NOT NULL,
	PONTUACAO INT NOT NULL,
	COLOCACAO INT NULL,
	JOGOS_GANHOS INT NOT NULL,
	JOGOS_PERDIDOS INT NOT NULL
	GOLS_FEITOS INT NOT NULL,
	GOLS_TOMADOS INT NOT NULL,
	DATA_HORA_INSCRICAO DATETIME NOT NULL,
	SITUACAO VARCHAR(20) NOT NULL,

	CONSTRAINT PK_ID_TIME_CAMPEONATO primary key (id_campeonato, id_time),
	CONSTRAINT FK_CAMPEONATO_TIME FOREIGN KEY (ID_CAMPEONATO) REFERENCES CAMPEONATO (ID),
	CONSTRAINT FK_TIME_CAMPEONATO FOREIGN KEY (ID_TIME) REFERENCES TIME (ID)
)


CREATE TABLE FASE
(
	ID uniqueidentifier PRIMARY KEY,
	ID_CAMPEONATO uniqueidentifier NOT NULL,
	NOME VARCHAR(17) NOT NULL,
	SITUACAO VARCHAR(30) NOT NULL,
	QTDE_JOGOS INT NOT NULL,
	DATA_HORA_INICIO DATETIME NULL,
	DATA_HORA_FIM DATETIME NULL,
	
	CONSTRAINT FK_CAMPEONATO_FASE FOREIGN KEY (ID_CAMPEONATO) REFERENCES CAMPEONATO (ID)
)


CREATE TABLE JOGOS_FASE
(
	ID uniqueidentifier PRIMARY KEY,
	ID_FASE uniqueidentifier,
	ID_TIME_1 uniqueidentifier NOT NULL,
	ID_TIME_2 uniqueidentifier NOT NULL,
	GOLS_TIME_1 INT NOT NULL,
	GOLS_TIME_2 INT NOT NULL,

	CONSTRAINT FK_FASE_JOGOS FOREIGN KEY (ID_FASE) REFERENCES FASE (ID)
)
