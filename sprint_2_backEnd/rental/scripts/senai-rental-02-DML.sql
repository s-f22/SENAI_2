USE T_RENTAL_Samuel;
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Localiza'),('Unidas'),('Movida');
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('GM'),('VW'),('FIAT'),('HONDA');
GO

INSERT INTO MODELO (idMarca,nomeModelo)
VALUES (2,'GOL'), (3,'PALIO'),
(1,'CELTA'),(4,'FIT');
GO

INSERT INTO CLIENTE (nome, sobrenome, cnh)
VALUES ('Carlos','Fernandes','0192745368-11'),('Joana','Mendonça Costa','0197488374-82'),
('Silvana','Pereira','9302957482-00'),('Bernardo','Gonçalves','7594837207-12');
GO

INSERT INTO VEICULO (idEmpresa,idModelo,corVeiculo)
VALUES (1,2,'BRANCO'), (2,1,'PRETO'), (1,3,'AZUL'),
(3,4,'PRATA'),(3,2,'VERMELHO');
GO

INSERT INTO ALUGUEL (idVeiculo,idCliente,dataRetirada,dataDevolucao,valorAluguel)
VALUES (2,2,'15/12/2020','16/12/2020',200),(3,2,'17/11/2020','19/11/2020',300),(4,1,'20/12/2020','21/12/2020',250),
(4,1,'05/11/2020','05/11/2020',250),(4,1,'10/10/2020','14/10/2020',950),
(5,4,'21/10/2020','23/10/2020',370),(1,3,'11/10/2020','12/10/2020',450);
GO


INSERT INTO CLIENTE (nome, sobrenome, cnh) VALUES ('Bernardo','Gonçalves','7594837207-12');

SELECT idCliente, nome, sobrenome, cnh FROM CLIENTE WHERE idCliente = 1;
DELETE FROM CLIENTE WHERE idCliente = 1;

UPDATE CLIENTE SET nome = 'Andre', sobrenome = 'Amaral', cnh = '1837592764-34' WHERE idCliente = 1;


/*
--VERIFICAR
SELECT * FROM ALUGUEL



ALTER TABLE CLIENTE
ADD sobrenomeCliente VARCHAR(50)


UPDATE ALUGUEL
SET dataRetirada = '20200809', dataDevolucao = '20200810'
WHERE idAluguel = 7;

*/


