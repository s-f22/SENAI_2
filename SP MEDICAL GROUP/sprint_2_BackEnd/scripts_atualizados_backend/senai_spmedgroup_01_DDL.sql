CREATE DATABASE SPMEDGROUP;
GO 

USE SPMEDGROUP;
GO

-- TIPO USUARIO
CREATE TABLE tipoUsuario
(
	idTipoUsuario SMALLINT PRIMARY KEY IDENTITY,
	titulo VARCHAR(50) UNIQUE NOT NULL
);
GO

-- CLINICA
CREATE TABLE clinica
(
	idClinica SMALLINT PRIMARY KEY IDENTITY,
	nomeFantasia VARCHAR(100) NOT NULL,
	cnpj CHAR(20) UNIQUE NOT NULL,
	razaoSocial VARCHAR(100) NOT NULL,
	endereco VARCHAR(200) UNIQUE NOT NULL,
	telefone VARCHAR(20) UNIQUE NOT NULL,
	horarioFuncionamento VARCHAR(50) NOT NULL
);
GO

-- ESPECIALIDADE
CREATE TABLE especialidade
(
	idEspecialidade SMALLINT PRIMARY KEY IDENTITY,
	nome VARCHAR(100) UNIQUE NOT NULL,
);
GO

-- SITUACAO
CREATE TABLE situacao
(
	idSituacao SMALLINT PRIMARY KEY IDENTITY,
	titulo VARCHAR(50) DEFAULT ('Agendada') UNIQUE NOT NULL 
);
GO

-- USUARIO
CREATE TABLE usuario
(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario SMALLINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nome VARCHAR(100) NOT NULL,
	email VARCHAR(255) UNIQUE NOT NULL,
	senha VARCHAR(255) NOT NULL CHECK ( len(senha) >= 8 )
);
GO

-- PACIENTE
CREATE TABLE paciente
(
	idPaciente INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	nomeCompleto VARCHAR(150) NOT NULL,
	dataNascimento DATE NOT NULL,
	rg CHAR(12) NOT NULL,
	cpf CHAR(14) UNIQUE NOT NULL,
	endereco VARCHAR(150) NOT NULL,
	telefone VARCHAR(20) UNIQUE 
);
GO

-- MEDICO
CREATE TABLE medico
(
	idMedico SMALLINT PRIMARY KEY IDENTITY,
	idEspecialidade SMALLINT FOREIGN KEY REFERENCES especialidade(idEspecialidade),
	idClinica SMALLINT FOREIGN KEY REFERENCES clinica(idClinica),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	nomeCompleto VARCHAR(150) NOT NULL,
	crm CHAR(8) NOT NULL
);
GO

-- CONSULTA
CREATE TABLE consulta
(
	idConsulta INT PRIMARY KEY IDENTITY,
	idMedico SMALLINT FOREIGN KEY REFERENCES medico(idMedico),
	idPaciente INT FOREIGN KEY REFERENCES paciente(idPaciente),
	idSituacao SMALLINT FOREIGN KEY REFERENCES situacao(idSituacao),
	dataHorario DATETIME NOT NULL,
	resumo VARCHAR(300)
);
GO

-- IMAGEM DO USUARIO
CREATE TABLE imagemUsuario
(
	idImagem INT PRIMARY KEY IDENTITY(1,1),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario) NOT NULL UNIQUE,
	imgBinario VARBINARY(MAX) NOT NULL, -- TAMANHO MAXIMO POSSIVEL PARA ARMAZENAMENTO DE BINARIOS
	mimeType VARCHAR(30) NOT NULL, -- PARA SALVAR A EXTENS�O DO TIPO DE IMAGEM
	nomeArquivo VARCHAR(250) NOT NULL,
	dataInclusao DATETIME DEFAULT GETDATE() NULL
);
GO