SELECT idFilme [ID do Filme], ISNULL(CONVERT(VARCHAR(20), FILME.idGenero), 'N�O CADASTRADO') AS 'ID do G�nero', 
tituloFilme 'T�tulo do Filme', ISNULL(nomeGenero, 'N�O CADASTRADO') 'G�nero do Filme' FROM FILME LEFT JOIN GENERO ON GENERO.idGenero = FILME.idGenero;


SELECT idFilme [ID do Filme], FILME.idGenero AS 'ID do G�nero', tituloFilme 'T�tulo do Filme', ISNULL(nomeGenero, 'N�O CADASTRADO') 'G�nero do Filme' FROM FILME INNER JOIN GENERO ON GENERO.idGenero = FILME.idGenero;