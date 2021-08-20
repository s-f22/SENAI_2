USE PCLINICS;
GO

SELECT * FROM ATENDIMENTO
SELECT * FROM CLINICA
SELECT * FROM DONO
SELECT * FROM PET
SELECT * FROM RACA
SELECT * FROM TIPO_PET
SELECT * FROM VETERINARIO


INSERT INTO CLINICA(nomeClinica)
VALUES ('Pet Show'),('Viva Pet'),('Animal Show');
GO

INSERT INTO TIPO_PET(descricaoTipo)
VALUES ('Cachorro'),('Gato'),('Peixe');
GO

INSERT INTO DONO(nomeDono)
VALUES ('Fabio'),('Luciana'),('Debora');
GO

INSERT INTO VETERINARIO(idClinica,nomeVeterinario)
VALUES (1,'João'),(3,'Fernanda'),(2,'Mauro');
GO

INSERT INTO RACA(idTipoPet, nomeRaca)
VALUES (1,'Pastor Alemão'),(1,'Vira-latas'),(2,'Siamês'),(3,'Linguado');
GO

INSERT INTO PET(idDono,idRaca,nomePet)
VALUES (2,3,'Xaninho'),(1,2,'Totó'),(2,1,'Rex'),(3,4,'Xuxa');
GO

INSERT INTO ATENDIMENTO(idVeterinario,idPet,dataAtendimento)
VALUES (3,3,'20211223 11:43:10 AM'),(2,2,'20211215 18:41:10 PM'),(4,1,'20210320 09:49:10 AM'),(4,4,'20210922 13:33:10 PM');
GO




ALTER TABLE CLINICA
DROP COLUMN nomeEmpresa;
GO

ALTER TABLE CLINICA
ADD nomeClinica VARCHAR(20) NOT NULL;
GO

ALTER TABLE ATENDIMENTO
ADD descricaoAtendimento VARCHAR(50);
GO

UPDATE ATENDIMENTO
SET descricaoAtendimento = 'Consulta de rotina'
WHERE idAtendimento = 2;

UPDATE ATENDIMENTO
SET descricaoAtendimento = 'Quebrou pata dianteira esquerda'
WHERE idAtendimento = 3;

UPDATE ATENDIMENTO
SET descricaoAtendimento = 'Aplicação de vacina'
WHERE idAtendimento = 4;

UPDATE ATENDIMENTO
SET descricaoAtendimento = 'Não está se alimentando'
WHERE idAtendimento = 5;


SELECT * FROM ATENDIMENTO;



UPDATE ATENDIMENTO
SET descricaoAtendimento = 'Consulta de Rotina', dataAtendimento = '05/12/2020'
WHERE idAtendimento = 5;

UPDATE ATENDIMENTO
SET descricaoAtendimento = 'Quebrou pata dianteira', dataAtendimento = '15/07/2021'
WHERE idAtendimento = 6;

UPDATE ATENDIMENTO
SET descricaoAtendimento = 'Aplicação de vacina', dataAtendimento = '01/08/2021'
WHERE idAtendimento = 7;

UPDATE ATENDIMENTO
SET descricaoAtendimento = 'Não está se alimentando', dataAtendimento = '01/08/2021'
WHERE idAtendimento = 8;
