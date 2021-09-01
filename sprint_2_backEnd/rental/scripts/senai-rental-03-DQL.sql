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

SELECT valorAluguel AS 'Valor em R$', dataRetirada AS 'Data de Retirada', dataDevolucao as 'Data de Devolução', 
nome AS 'Nome do Cliente', nomeModelo AS 'Modelo' FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
INNER JOIN VEICULO
ON VEICULO.IdVeiculo = ALUGUEL.idVeiculo
INNER JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo


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




