

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
