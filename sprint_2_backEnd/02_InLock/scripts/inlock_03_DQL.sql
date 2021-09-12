USE inlock_games_tarde;
GO

SELECT * FROM USUARIOS;

SELECT * FROM ESTUDIOS;

SELECT * FROM JOGOS;

SELECT * FROM TIPOUSUARIO;

SELECT nomeJogo, nomeEstudio FROM JOGOS [j]
INNER JOIN ESTUDIOS [e]
ON j.idEstudio = e.idEstudio;

SELECT nomeEstudio, nomeJogo FROM JOGOS [j]
RIGHT JOIN ESTUDIOS [e]
ON j.idEstudio = e.idEstudio;



-- Scripts para os repositories da API --

SELECT idUsuario, email, senha, idTipoUsuario FROM USUARIOS
WHERE email = 'admin@admin.com' AND senha = 'admin';

SELECT nomeJogo FROM JOGOS
WHERE idJogo = 2;

SELECT nomeEstudio FROM ESTUDIOS
WHERE idEstudio = 1;

SELECT JOGOS.idJogo, JOGOS.nomeJogo, JOGOS.descricao, JOGOS.dataLancamento,JOGOS.idEstudio, JOGOS.valor, ESTUDIOS.idEstudio, ESTUDIOS.nomeEstudio FROM JOGOS
INNER JOIN ESTUDIOS
ON JOGOS.idEstudio = ESTUDIOS.idEstudio


UPDATE JOGOS
SET nomeJogo = 'Diablo 3', descricao = 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', 
dataLancamento = '15/05/2002', idEstudio = 1, valor = 99.99
WHERE idJogo = 1;

SELECT * FROM JOGOS

SELECT idJogo, nomeJogo, descricao, dataLancamento, idEstudio, valor FROM JOGOS
WHERE idJogo = 1
