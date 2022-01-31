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
 POST {{baseurl}}/Times/CadastrarTimes
 
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
 
  <h3>POST {{baseUrl}}/Campeonato/IniciarCampeonato</h3>
 
  Rota que inicia um campeonato a partir de uma lista de times.
 
  Somente é possivel iniciar um campeonato a partir de uma lista de 8 times.
 
  Json exemplo:
       [
        {
            "Id": "071c39b0-935c-4579-9d6c-f0bd94dbb229"
        },
        {
            "Id": "66292710-586e-4dd6-baef-45daebf52dd4"
        },
        [..],
        {
            "Id": "e3811160-3eaf-4cc6-a1ad-1cb7125da92a"
        },
        {
            "Id": "448e101b-4729-4f35-bc6f-b232fb2b6416"
        }
       ]
 
 <h3>GET {{baseUrl}}/Fases/JogosDaFaseAtual/{idCampeonato}</h3>

 Gera os jogos aleatoriamente para a fase em andamento.
 
 Os jogos serão executados no próximo GET.
 
 Json retorno exemplo:
 
 {
    "data": {
        "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
        "nome": "Semifinal",
        "qtdeJogos": 2,
        "situacao": "Em andamento",
        "dataHoraInicio": "2022-01-30T23:14:22.717",
        "dataHoraFim": null,
        "jogos": [
            {
                "id": "55cf6a61-8e98-472e-b183-0385e99ab1e9",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "21cb1c00-c423-4c46-b770-031a48444096",
                "idTime2": "2042da11-b131-4566-b651-3ee0b3235648",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "4f64a47f-a195-491f-8693-05abd3edd5d4",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "2042da11-b131-4566-b651-3ee0b3235648",
                "idTime2": "21cb1c00-c423-4c46-b770-031a48444096",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "544794f7-63a0-49a3-a735-305b560660dc",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "idTime2": "21cb1c00-c423-4c46-b770-031a48444096",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "c929a7f2-7a04-4fb0-9741-397f90833194",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "idTime2": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "6aae89e6-92cb-42fe-9292-3b674b1db4de",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "21cb1c00-c423-4c46-b770-031a48444096",
                "idTime2": "2042da11-b131-4566-b651-3ee0b3235648",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "b9c727e5-814e-45a4-b3ce-44fc00dbd042",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "21cb1c00-c423-4c46-b770-031a48444096",
                "idTime2": "2042da11-b131-4566-b651-3ee0b3235648",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "793c23d4-a05f-4a29-817a-4f18ff8a486b",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "idTime2": "2042da11-b131-4566-b651-3ee0b3235648",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "541c4b27-def3-41d9-9f17-5f95921a51a9",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "21cb1c00-c423-4c46-b770-031a48444096",
                "idTime2": "2042da11-b131-4566-b651-3ee0b3235648",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "fe79674e-f07d-4f8c-add2-6063a7655d4a",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "idTime2": "2042da11-b131-4566-b651-3ee0b3235648",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "9c4df723-33c8-4c0d-b56d-64bce64adbd4",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "idTime2": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "304fa805-c313-4657-9fcc-7f7da0e26db9",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "21cb1c00-c423-4c46-b770-031a48444096",
                "idTime2": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "620faa98-0577-4a8f-8655-9c1ff755a98a",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "idTime2": "21cb1c00-c423-4c46-b770-031a48444096",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "0c78866e-6400-4bd1-bb40-9ddca064fd6e",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "idTime2": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "2b61d528-c290-4a30-aa9d-a88e02400d28",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "21cb1c00-c423-4c46-b770-031a48444096",
                "idTime2": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "0839ff17-3962-47bf-9067-aba6a3c02d63",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "idTime2": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "42f774a7-3f8e-44ef-a5e0-aed1fd1fa065",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "idTime2": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "31416040-5fdc-4b3c-81d2-c7eda2019224",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "21cb1c00-c423-4c46-b770-031a48444096",
                "idTime2": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "96c3c4a2-d4c9-48a1-889a-db115f036bce",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "2042da11-b131-4566-b651-3ee0b3235648",
                "idTime2": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "6d2d1b86-b0cb-437b-8c39-e0f071d09d0e",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "idTime2": "2042da11-b131-4566-b651-3ee0b3235648",
                "golsTime1": 0,
                "golsTime2": 0
            },
            {
                "id": "8f5de003-e690-4e28-bdef-fd66cf06d1e8",
                "idFase": "bb98793e-af35-4410-8ab5-34f471443067",
                "idTime1": "2042da11-b131-4566-b651-3ee0b3235648",
                "idTime2": "152fed6a-f780-4a56-96ec-586f103a04f5",
                "golsTime1": 0,
                "golsTime2": 0
            }
        ]
    }
}
       
       
 <h3>GET {{baseUrl}}/ExecutarPartidasDaFaseAtual/{idCampeonato}</h3>
 
 Executa as partidas da fase em andamento a partir dos jogos sorteados no GET anterior.
 
 Também avança para a próxima fase.
 
 Executar o GET anterior para gerar os proximos jogos.
 
 Json retorno exemplo:

{
    "data": {
        "result": {
            "idFase": "63148dd4-bda4-4a85-9b09-c3cca3a94f69",
            "nome": "Quartas de finais",
            "qtdeJogos": 4,
            "situacao": "Finalizada",
            "dataHoraInicio": "2022-01-30T23:10:02.7",
            "dataHoraFim": "2022-01-30T23:14:22.7155587-03:00",
            "jogos": [
                {
                    "id": "993c15a9-7c7a-4669-a09d-41bc797d847b",
                    "idFase": "63148dd4-bda4-4a85-9b09-c3cca3a94f69",
                    "idTime1": "21cb1c00-c423-4c46-b770-031a48444096",
                    "idTime2": "43d95cf6-305d-40fd-9f8d-90e1d682844a",
                    "golsTime1": 1,
                    "golsTime2": 6
                },
                {
                    "id": "bf45ba63-c44a-4ac1-9bca-9ceaad09bbd0",
                    "idFase": "63148dd4-bda4-4a85-9b09-c3cca3a94f69",
                    "idTime1": "152fed6a-f780-4a56-96ec-586f103a04f5",
                    "idTime2": "ef02472c-4e50-4d1b-8549-c6577bdd6260",
                    "golsTime1": 8,
                    "golsTime2": 1
                },
                {
                    "id": "e46606be-32f8-45bc-aeeb-eb2afbee7307",
                    "idFase": "63148dd4-bda4-4a85-9b09-c3cca3a94f69",
                    "idTime1": "1474b8ef-66e5-45ac-8d5e-76f121db39c5",
                    "idTime2": "2042da11-b131-4566-b651-3ee0b3235648",
                    "golsTime1": 3,
                    "golsTime2": 4
                },
                {
                    "id": "b28fd883-b3e1-4ccb-b69c-f338942759c3",
                    "idFase": "63148dd4-bda4-4a85-9b09-c3cca3a94f69",
                    "idTime1": "2800dab2-91c1-4902-a16b-3eb95614fe37",
                    "idTime2": "500cfee4-c700-4d54-85b5-bf4cc6df0240",
                    "golsTime1": 7,
                    "golsTime2": 5
                }
            ]
        },
        "id": 74,
        "exception": null,
        "status": 5,
        "isCanceled": false,
        "isCompleted": true,
        "isCompletedSuccessfully": true,
        "creationOptions": 0,
        "asyncState": null,
        "isFaulted": false
    }
}
 
 <h3>GET {{baseUrl}}/Campeonato/{idCampeonato}</h3>
 
 Retorna situacao do campeonato a partir do seu id.
 
 Json retorno exemplo:
 
 {
    "data": {
        "result": {
            "idCampeonato": "f21d7659-39a3-47f5-8c7a-45fd3bacbed3",
            "nome": "Novo campeonato: f21d7659-3",
            "dataHoraInicio": "2022-01-30T23:09:58.913",
            "dataHoraFim": null,
            "situacao": "Em andamento",
            "timesNoCampeonato": [
                {
                    "idTime": "21CB1C00-C423-4C46-B770-031A48444096",
                    "situacao": "Eliminado",
                    "pontuacao": 0,
                    "colocacao": null,
                    "jogosGanhos": 0,
                    "jogosPerdidos": 0,
                    "golsFeitos": 0,
                    "golsTomados": 0,
                    "dataHoraInscricao": "2022-01-30T23:10:02.56",
                    "nome": "Eduardo Futebol Clube 1"
                },
                {
                    "idTime": "2800DAB2-91C1-4902-A16B-3EB95614FE37",
                    "situacao": "Jogando",
                    "pontuacao": 0,
                    "colocacao": null,
                    "jogosGanhos": 0,
                    "jogosPerdidos": 0,
                    "golsFeitos": 0,
                    "golsTomados": 0,
                    "dataHoraInscricao": "2022-01-30T23:10:02.56",
                    "nome": "Guedes Futebol Clube 4"
                },
                {
                    "idTime": "2042DA11-B131-4566-B651-3EE0B3235648",
                    "situacao": "Jogando",
                    "pontuacao": 0,
                    "colocacao": null,
                    "jogosGanhos": 0,
                    "jogosPerdidos": 0,
                    "golsFeitos": 0,
                    "golsTomados": 0,
                    "dataHoraInscricao": "2022-01-30T23:10:02.56",
                    "nome": "Eduardo Futebol Clube 4"
                },
                {
                    "idTime": "152FED6A-F780-4A56-96EC-586F103A04F5",
                    "situacao": "Jogando",
                    "pontuacao": 0,
                    "colocacao": null,
                    "jogosGanhos": 0,
                    "jogosPerdidos": 0,
                    "golsFeitos": 0,
                    "golsTomados": 0,
                    "dataHoraInscricao": "2022-01-30T23:10:02.56",
                    "nome": "Eduardo Futebol Clube 3"
                },
                {
                    "idTime": "1474B8EF-66E5-45AC-8D5E-76F121DB39C5",
                    "situacao": "Eliminado",
                    "pontuacao": 0,
                    "colocacao": null,
                    "jogosGanhos": 0,
                    "jogosPerdidos": 0,
                    "golsFeitos": 0,
                    "golsTomados": 0,
                    "dataHoraInscricao": "2022-01-30T23:10:02.56",
                    "nome": "Guedes Futebol Clube 2"
                },
                {
                    "idTime": "43D95CF6-305D-40FD-9F8D-90E1D682844A",
                    "situacao": "Jogando",
                    "pontuacao": 0,
                    "colocacao": null,
                    "jogosGanhos": 0,
                    "jogosPerdidos": 0,
                    "golsFeitos": 0,
                    "golsTomados": 0,
                    "dataHoraInscricao": "2022-01-30T23:10:02.56",
                    "nome": "Guedes Futebol Clube 2"
                },
                {
                    "idTime": "500CFEE4-C700-4D54-85B5-BF4CC6DF0240",
                    "situacao": "Eliminado",
                    "pontuacao": 0,
                    "colocacao": null,
                    "jogosGanhos": 0,
                    "jogosPerdidos": 0,
                    "golsFeitos": 0,
                    "golsTomados": 0,
                    "dataHoraInscricao": "2022-01-30T23:10:02.56",
                    "nome": "Guedes Futebol Clube 3"
                },
                {
                    "idTime": "EF02472C-4E50-4D1B-8549-C6577BDD6260",
                    "situacao": "Eliminado",
                    "pontuacao": 0,
                    "colocacao": null,
                    "jogosGanhos": 0,
                    "jogosPerdidos": 0,
                    "golsFeitos": 0,
                    "golsTomados": 0,
                    "dataHoraInscricao": "2022-01-30T23:10:02.56",
                    "nome": "Eduardo Futebol Clube 5"
                }
            ]
        },
        "id": 95,
        "exception": null,
        "status": 5,
        "isCanceled": false,
        "isCompleted": true,
        "isCompletedSuccessfully": true,
        "creationOptions": 0,
        "asyncState": null,
        "isFaulted": false
    }
}


 <h3>GET Campeonatos - Campeonatos/{dataInicio}</h3>
 
 Retorna todos os campeonatos já cadastrados. 
 
 É possivel filtrar por data/hora de inicio dos campeonatos. 
 
 Nesse caso, apenas campeonatos criados a partir dessa data/hora serão retornados.
 
 Json de retorno igual do GET anterior.
   

 
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
