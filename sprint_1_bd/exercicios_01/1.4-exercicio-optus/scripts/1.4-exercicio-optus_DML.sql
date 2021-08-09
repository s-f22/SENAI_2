USE OPTUS_S;
GO

INSERT INTO USUARIO(nomeUsuario, emailUsuario, senhaUsuario)
VALUES ('Marcos','marcos@gmail.com','123'),('Gabriela','gabriela@hotmail.com','456'),('Mateus','mateus@senai.com','789');
GO

INSERT INTO ARTISTA(nomeArtista)
VALUES ('Ronnie James Dio'),('Ingwie Malmsteen'),('Joe Satriani');
GO

INSERT INTO ESTILO(nomeEstilo)
VALUES ('Heavy Metal'),('Instrumental'),('Rock'),('Hrad Rock');
GO

INSERT INTO ALBUM(idArtista, nomeAlbum)
VALUES (1,'Holy Diver'),(3,'Crystal Planet'),(2,'Magnum Opus'),(3,'The Extremist'),(2,'Rising Force'),(1,'Last in Line');
GO

INSERT INTO ALBUM_ESTILO(idAlbum,idEstilo,codAlbumEstilo)
VALUES (1,1,1),(1,4,1),(2,3,2),(2,2,2),(5,1,3),(5,2,3),(3,2,4),(3,3,4),(6,1,5),(6,4,5),(4,2,6),(4,3,6);
GO



UPDATE ALBUM
SET codAlbumEstilo = 1, dataLancamento = '19801205', localizacao = 'USA', tempoMinutos = 45, visibilidade = 1
WHERE idAlbum = 1;

UPDATE ALBUM
SET codAlbumEstilo = 2, dataLancamento = '19950201', localizacao = 'USA', tempoMinutos = 52, visibilidade = 1
WHERE idAlbum = 2;

UPDATE ALBUM
SET codAlbumEstilo = 4, dataLancamento = '19990503', localizacao = 'Suecia', tempoMinutos = 48, visibilidade = 0
WHERE idAlbum = 3;

UPDATE ALBUM
SET codAlbumEstilo = 6, dataLancamento = '19920720', localizacao = 'USA', tempoMinutos = 75, visibilidade = 1
WHERE idAlbum = 4;

UPDATE ALBUM
SET codAlbumEstilo = 3, dataLancamento = '19850203', localizacao = 'Suecia', tempoMinutos = 35, visibilidade = 1
WHERE idAlbum = 5;

UPDATE ALBUM
SET codAlbumEstilo = 5, dataLancamento = '19821130', localizacao = 'USA', tempoMinutos = 41, visibilidade = 0
WHERE idAlbum = 6;











