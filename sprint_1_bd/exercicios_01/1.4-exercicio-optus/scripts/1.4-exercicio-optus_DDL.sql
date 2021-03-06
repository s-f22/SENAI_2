CREATE DATABASE OPTUS_S;
GO

USE OPTUS_S;
GO


CREATE TABLE USUARIO (
 idUsuario TINYINT PRIMARY KEY IDENTITY(1,1),
 nomeUsuario VARCHAR(20),
 emailUsuario VARCHAR(20),
 senhaUsuario VARCHAR(20)
);
GO

CREATE TABLE ARTISTA (
 idArtista TINYINT PRIMARY KEY IDENTITY(1,1),
 nomeArtista VARCHAR(20)
);
GO

CREATE TABLE ESTILO (
 idEstilo TINYINT PRIMARY KEY IDENTITY(1,1),
 nomeEstilo VARCHAR(20)
);
GO

CREATE TABLE ALBUM (
 idAlbum TINYINT PRIMARY KEY IDENTITY(1,1),
 idArtista TINYINT FOREIGN KEY REFERENCES ARTISTA(idArtista),
 nomeAlbum VARCHAR(20)
);
GO

CREATE TABLE ALBUM_ESTILO (
 idAlbumEstilo TINYINT PRIMARY KEY IDENTITY(1,1),
 idAlbum TINYINT FOREIGN KEY REFERENCES ALBUM(idAlbum),
 idEstilo TINYINT FOREIGN KEY REFERENCES ESTILO(idEstilo),
 codAlbumEstilo SMALLINT
);
GO

DROP TABLE ALBUM_ESTILO;

CREATE TABLE ALBUM_ESTILO (
 idAlbumEstilo TINYINT PRIMARY KEY,
 idAlbum TINYINT FOREIGN KEY REFERENCES ALBUM(idAlbum),
 idEstilo TINYINT FOREIGN KEY REFERENCES ESTILO(idEstilo),
);
GO


ALTER TABLE ARTISTA
DROP COLUMN idArtista

ALTER TABLE ARTISTA
ADD idArtista TINYINT PRIMARY KEY IDENTITY(1,1)

ALTER TABLE ALBUM_ESTILO
DROP COLUMN codAlbumEstilo;


ALTER TABLE ALBUM
ADD codAlbumEstilo SMALLINT;

ALTER TABLE ALBUM
ADD dataLancamento DATE;

ALTER TABLE ALBUM
ADD localizacao VARCHAR(20);

ALTER TABLE ALBUM
ADD tempoMinutos SMALLINT;

ALTER TABLE ALBUM
ADD visibilidade TINYINT;