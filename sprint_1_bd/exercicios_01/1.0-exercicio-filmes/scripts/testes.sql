SELECT idFilme [ID do Filme], ISNULL(CONVERT(VARCHAR(20), FILME.idGenero), 'NÃO CADASTRADO') AS 'ID do Gênero', 
tituloFilme 'Título do Filme', ISNULL(nomeGenero, 'NÃO CADASTRADO') 'Gênero do Filme' FROM FILME LEFT JOIN GENERO ON GENERO.idGenero = FILME.idGenero;


SELECT idFilme [ID do Filme], FILME.idGenero AS 'ID do Gênero', tituloFilme 'Título do Filme', ISNULL(nomeGenero, 'NÃO CADASTRADO') 'Gênero do Filme' FROM FILME INNER JOIN GENERO ON GENERO.idGenero = FILME.idGenero;