USE T_RENTAL_Samuel
GO

--DQL
SELECT * FROM ALUGUEL;
SELECT * FROM CLIENTE;
SELECT * FROM EMPRESA;
SELECT * FROM MARCA;
SELECT * FROM MODELO;
SELECT * FROM VEICULO;


-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro

SELECT idAluguel, valorAluguel AS 'Valor em R$', dataRetirada AS 'Data de Retirada', dataDevolucao as 'Data de Devolução', 
nome AS 'Nome do Cliente', sobrenome AS 'Sobrenome', nomeModelo AS 'Modelo', nomeEmpresa AS 'Empresa' FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
INNER JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.idVeiculo
INNER JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo
INNER JOIN EMPRESA
ON EMPRESA.idEmpresa = VEICULO.idEmpresa


-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT CLIENTE.idCliente, nome, nomeModelo, dataRetirada, dataDevolucao, valorAluguel FROM CLIENTE
INNER JOIN ALUGUEL
ON CLIENTE.idCliente = ALUGUEL.idCliente
INNER JOIN VEICULO
ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
INNER JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
WHERE CLIENTE.idCliente = 2


SELECT idCliente, nome, sobrenome, cnh FROM CLIENTE;




UPDATE ALUGUEL
SET idCliente = 3
WHERE idAluguel = 5;




SELECT ALUGUEL.idAluguel, ALUGUEL.idVeiculo, ALUGUEL.idCliente, ALUGUEL.dataRetirada, ALUGUEL.dataDevolucao, 
ALUGUEL.valorAluguel, VEICULO.idVeiculo, VEICULO.idModelo, VEICULO.idEmpresa, VEICULO.corVeiculo, 
CLIENTE.idCliente, CLIENTE.nome, CLIENTE.sobrenome, CLIENTE.cnh,
EMPRESA.idEmpresa, EMPRESA.nomeEmpresa, MODELO.idModelo, MODELO.idMarca, MODELO.nomeModelo,
MARCA.idMarca, MARCA.nomeMarca
FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
INNER JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.idVeiculo
INNER JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo
INNER JOIN EMPRESA
ON EMPRESA.idEmpresa = VEICULO.idEmpresa
INNER JOIN MARCA
ON MODELO.idMarca = MARCA.idMarca


SELECT * FROM ALUGUEL
select * from VEICULO
select * from CLIENTE

SELECT ALUGUEL.idAluguel, ALUGUEL.dataRetirada, ALUGUEL.dataDevolucao, 
ALUGUEL.valorAluguel, VEICULO.corVeiculo, 
CLIENTE.nome, CLIENTE.sobrenome, CLIENTE.cnh,
EMPRESA.nomeEmpresa, MODELO.nomeModelo,
MARCA.nomeMarca
FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
INNER JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.idVeiculo
INNER JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo
INNER JOIN EMPRESA
ON EMPRESA.idEmpresa = VEICULO.idEmpresa
INNER JOIN MARCA
ON MODELO.idMarca = MARCA.idMarca