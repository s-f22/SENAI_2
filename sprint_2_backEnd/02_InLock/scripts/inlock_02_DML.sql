USE inlock_games_tarde;
GO

INSERT INTO TIPOUSUARIO(titulo)
VALUES ('Administrador'), ('Cliente');
GO

INSERT INTO USUARIOS(email, senha, idTipoUsuario)
VALUES ('admin@admin.com', 'admin', 1), ('cliente@cliente.com', 'cliente', 2);
GO

INSERT INTO ESTUDIOS(nomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix');
GO

INSERT INTO JOGOS(nomeJogo, descricao, dataLancamento, idEstudio, valor)
VALUES
('Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '15/05/2012', 1, 99.00),
('Red Dead Redemption 2','jogo eletrônico de ação-aventura western', '26/10/2018', 2, 120.00);
GO


INSERT INTO JOGOS(nomeJogo, descricao, dataLancamento, idEstudio, valor)
VALUES ('Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '15/05/2012', 1, 99.00);
GO