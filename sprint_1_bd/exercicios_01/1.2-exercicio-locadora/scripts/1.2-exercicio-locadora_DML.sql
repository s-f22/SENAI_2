USE LOCADORA;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Localiza'),('Unidas');
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('GM'),('VW'),('FIAT');
GO

INSERT INTO MODELO (idMarca,nomeModelo)
VALUES (2,'GOL'), 
(3,'PALIO'),(1,'CELTA');
GO

INSERT INTO CLIENTE (nomeCliente)
VALUES ('FULANO'),('CICLANO'),('BELTRANO');
GO

INSERT INTO VEICULO (idEmpresa,idModelo,corVeiculo)
VALUES (1,2,'BRANCO'), (2,1,'PRETO'), (1,3,'AZUL');
GO

INSERT INTO ALUGUEL (idVeiculo,idCliente,valorAluguel)
VALUES (2,2,200), (3,2,300), (4,1,250);
GO


ALTER TABLE ALUGUEL
ADD dataRetirada DATE;

ALTER TABLE ALUGUEL
ADD dataDevolucao DATE;


UPDATE ALUGUEL
SET dataRetirada = '20200809', dataDevolucao = '20200810'
WHERE idAluguel = 7;

SELECT * FROM ALUGUEL;



