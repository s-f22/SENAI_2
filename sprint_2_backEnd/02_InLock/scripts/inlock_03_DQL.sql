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

SELECT email FROM USUARIOS
WHERE email = 'admin@admin.com' AND senha = 'admin';

SELECT nomeJogo FROM JOGOS
WHERE idJogo = 2;

SELECT nomeEstudio FROM ESTUDIOS
WHERE idEstudio = 1;