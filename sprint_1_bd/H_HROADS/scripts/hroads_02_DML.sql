USE SENAI_HROADS_TARDE;
GO

INSERT INTO CLASSE (nomeClasse, ptsVida, ptsMana)
VALUES ('Barbaro', 100, 80),('Monge', 70, 100),('Arcanista', 75, 60),
('Necromante', 60, 90), ('Feiticeiro', 65, 85),('Cruzado', 90, 70),('Caçadora de Demônios', 85, 90);
GO

INSERT INTO TIPO_HABILIDADE (nomeTipoHabilidade)
VALUES ('Ataque'), ('Defesa'), ('Cura'), ('Magia')
GO

INSERT INTO HABILIDADE (idTipoHabilidade, nomeHabilidade)
VALUES (1, 'Lança Mortal'), (2, 'Escudo Supremo'), (3, 'Recuperar Vida')
GO

INSERT INTO PERSONAGEM (idClasse, nomePersonagem, dataCriacao, dataAtualizacao)
VALUES (4, 'DeuBug', '05/02/2021','10/08/2021'), (5, 'BitBug','01/01/2020','10/08/2021'), 
(6, 'Fer8','03/05/2020','10/08/2021'),(7, 'BDD','29/07/2021','10/08/2021')
GO

INSERT INTO CLASSE_HABILIDADE (idHabilidade, idClasse)
VALUES (1,4),(2,4),(2,5),(3,5),(NULL,6),(NULL,7),(3,8),(2,9),(1,10)
GO

INSERT INTO PLAYER(idPersonagem, nomePlayer)
VALUES (1, 'Samuel'), (2, 'Erick'), (3, 'Erick'), (4, 'Samuel')
GO

UPDATE PERSONAGEM
SET nomePersonagem = 'Fer7'
WHERE PERSONAGEM.idPersonagem = 3;
GO

UPDATE CLASSE
SET nomeClasse = 'Necromancer'
WHERE CLASSE.idClasse = 7;
GO


