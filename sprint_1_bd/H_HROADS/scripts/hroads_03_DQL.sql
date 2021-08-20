USE SENAI_HROADS_TARDE;
GO

--6. Selecionar todos os personagens;
SELECT * FROM PERSONAGEM

--7. Selecionar todos as classes;
SELECT * FROM CLASSE

--8. Selecionar somente o nome das classes;
SELECT CLASSE.nomeClasse FROM CLASSE

--9. Selecionar todas as habilidades;
SELECT * FROM HABILIDADE

--10. Realizar a contagem de quantas habilidades estão cadastradas;
SELECT COUNT(idHabilidade) FROM Habilidade

--11. Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
SELECT idHabilidade FROM Habilidade
ORDER BY idHabilidade;

--12. Selecionar todos os tipos de habilidades;
SELECT * FROM TIPO_HABILIDADE;

--13. Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
SELECT nomeHabilidade AS 'Nome da Habilidade', nomeTipoHabilidade AS 'Tipo de Habilidade' FROM HABILIDADE
INNER JOIN TIPO_HABILIDADE
ON HABILIDADE.idTipoHabilidade = TIPO_HABILIDADE.idTipoHabilidade

--14. Selecionar todos os personagens e suas respectivas classes;
SELECT nomePersonagem AS 'Nome do Personagem', nomeClasse AS 'Nome da Classe' FROM PERSONAGEM
INNER JOIN CLASSE
ON PERSONAGEM.idClasse = CLASSE.idClasse;

--15. Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);
SELECT nomePersonagem AS 'Nome do Personagem', nomeClasse AS 'Nome da Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON PERSONAGEM.idClasse = CLASSE.idClasse;

--16. Selecionar todas as classes e suas respectivas habilidades;
SELECT nomeClasse, nomeHabilidade FROM CLASSE
INNER JOIN CLASSE_HABILIDADE
ON CLASSE.idClasse = CLASSE_HABILIDADE.idClasse
LEFT JOIN HABILIDADE
ON CLASSE_HABILIDADE.idHabilidade = HABILIDADE.idHabilidade

--17. Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT nomeHabilidade, nomeClasse FROM HABILIDADE
INNER JOIN CLASSE_HABILIDADE
ON HABILIDADE.idHabilidade = CLASSE_HABILIDADE.idHabilidade
INNER JOIN CLASSE
ON CLASSE_HABILIDADE.idClasse = CLASSE.idClasse

--18. Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT nomeHabilidade, nomeClasse FROM HABILIDADE
LEFT JOIN CLASSE_HABILIDADE
ON HABILIDADE.idHabilidade = CLASSE_HABILIDADE.idHabilidade
RIGHT JOIN CLASSE
ON CLASSE_HABILIDADE.idClasse = CLASSE.idClasse


-- -----------------------------------------------------------------------
SELECT nomePersonagem AS 'NOME DO PERSONAGEM', dataCriacao FROM PERSONAGEM;
SELECT nomePersonagem AS 'NOME DO PERSONAGEM', DATENAME(YEAR, dataCriacao) AS 'ANO DE CRIAÇÃO' FROM PERSONAGEM
SELECT nomePersonagem AS 'NOME DO PERSONAGEM', DATENAME(MONTH, dataCriacao) AS 'MES DE CRIAÇÃO' FROM PERSONAGEM
SELECT nomePersonagem AS 'NOME DO PERSONAGEM', DATENAME(DAY, dataCriacao) AS 'DIA DE CRIAÇÃO' FROM PERSONAGEM