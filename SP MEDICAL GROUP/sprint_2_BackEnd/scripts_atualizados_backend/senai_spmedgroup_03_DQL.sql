USE SPMEDGROUP;
GO

-- LISTA TODAS AS CLINICAS
SELECT * FROM clinica;

-- LISTA TODAS AS CONSULTAS
SELECT * FROM consulta;

--LISTA TODAS AS ESPECIALIDADES
SELECT * FROM especialidade;

-- LISTA TODOS OS MEDICOS
SELECT * FROM medico;

-- LISTA TODOS OS PACIENTES
SELECT * FROM paciente;

-- LISTA TODAS AS SITUAÇÕES
SELECT * FROM situacao;

--LISTA TODOS OS TIPOS DE USUARIO
SELECT * FROM tipoUsuario;

-- LISTA TODOS OS USUARIOS
SELECT * FROM usuario;

SELECT * FROM imagemUsuario;


-- 5. O médico poderá ver os agendamentos (consultas) associados a ele;

SELECT medico.nomeCompleto Médico, especialidade.nome Especialidade, 
convert(varchar(30),consulta.dataHorario,113) 'Data e Horário da Consulta', 
paciente.nomeCompleto 'Nome do Paciente', consulta.resumo 'Descrição do atendimento', 
clinica.nomeFantasia 'Nome da Clinica' 
FROM consulta
INNER JOIN medico
ON consulta.idMedico = medico.idMedico
INNER JOIN situacao
ON consulta.idSituacao = situacao.IdSituacao
INNER JOIN paciente
ON consulta.idPaciente = paciente.idPaciente
INNER JOIN clinica
ON clinica.idClinica = medico.idClinica
INNER JOIN especialidade
ON especialidade.idEspecialidade = medico.idEspecialidade
WHERE medico.idMedico = 2; -- SELETOR DO MEDICO


-- 7. O paciente poderá visualizar suas próprias consultas;

SELECT paciente.nomeCompleto 'Nome do Paciente', 
convert(varchar(30),consulta.dataHorario,113) 'Data e Horário da Consulta', 
medico.nomeCompleto Médico, especialidade.nome Especialidade, 
consulta.resumo 'Descrição do atendimento', clinica.nomeFantasia 'Nome da Clinica' 
FROM consulta
INNER JOIN medico
ON consulta.idMedico = medico.idMedico
INNER JOIN situacao
ON consulta.idSituacao = situacao.IdSituacao
INNER JOIN paciente
ON consulta.idPaciente = paciente.idPaciente
INNER JOIN clinica
ON clinica.idClinica = medico.idClinica
INNER JOIN especialidade
ON especialidade.idEspecialidade = medico.idEspecialidade
WHERE paciente.idPaciente = 3; -- SELETOR DE PACIENTE


-- RETORNA A QUANTIDADE TOTAL DE USUARIOS CADASTRADOS
SELECT COUNT(usuario.idUsuario) AS 'QTDE de Usuários' FROM usuario;


-- CONVERTE A DATA DE NASCIMENTO DO PACIENTE PARA O FORMATO DD/MÊS/AAAA
SELECT paciente.nomeCompleto AS 'Nome Completo', convert(varchar(30),paciente.dataNascimento,113) AS 'Data de nascimento' FROM paciente
WHERE paciente.idPaciente = 7; -- SELETOR DE PACIENTE


-- CALCULA A IDADE DO PACIENTE UTILIZANDO SUA DATA DE NASCIMENTO
SELECT paciente.nomeCompleto AS 'Nome Completo', DATEDIFF(YEAR, dataNascimento, GETDATE()) AS 'Idade do paciente' FROM paciente
WHERE paciente.idPaciente = 7; -- SELETOR DE PACIENTE



-- Função para retornar a quantidade de médicos de uma determinada especialidade

CREATE FUNCTION medicos( @especialidade VARCHAR(20) )
RETURNS TABLE 
AS RETURN
(
	SELECT @especialidade AS Especialidade, COUNT(idEspecialidade) AS [Qtde de Medicos]
	FROM dbo.especialidade
	WHERE nome LIKE '%' + @especialidade + '%'
)

SELECT * FROM medicos('Pediatria')


-- Função para que retorne a idade do usuário a partir de uma determinada stored procedure

CREATE PROCEDURE calculoIdade( @nomePaciente VARCHAR(20) )
AS
BEGIN
	--DECLARE @IDADE TINYINT
	--SELECT @IDADE = DATEDIFF( YEAR, dataNascimento, GETDATE() ) AS Idade FROM paciente
	SELECT DATEDIFF( YEAR, dataNascimento, GETDATE() ) AS Idade FROM paciente
	WHERE paciente.nomeCompleto = @nomePaciente
END;

EXEC calculoIdade 'Ligia Maria da Silva'


--SELECT nomeCompleto FROM paciente
--DROP PROCEDURE dbo.calculoIdade

