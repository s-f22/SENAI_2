USE SPMEDGROUP;
GO

-- 1. O administrador poder� cadastrar qualquer tipo de usu�rio (administrador, paciente ou m�dico);
-- TIPO USUARIO
INSERT INTO tipoUsuario (titulo)
VALUES ('Administrador'),('Medico'),('Paciente');
GO

-- ESPECIALIDADE
INSERT INTO especialidade (nome)
VALUES ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),
('Cirurgia Cardiovascular'),('Cirurgia da M�o'),('Cirurgia do Aparelho Digestivo'),
('Cirurgia Geral'),('Cirurgia Pedi�trica'),('Cirurgia Pl�stica'),
('Cirurgia Tor�cica'),('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),
('Urologia'),('Pediatria'),('Psiquiatria');
GO

-- 4. O administrador dever� informar os dados da cl�nica (como endere�o, hor�rio de funcionamento, CNPJ, nome fantasia e raz�o social);
-- CLINICA
INSERT INTO clinica(nomeFantasia, cnpj, razaoSocial, endereco, telefone, horarioFuncionamento)
VALUES ('Clinica Possarle','86.400.902/0001-30','SP Medical Group','Av. Bar�o Limeira, 532, S�o Paulo, SP','11 1234-5678', 'Das 7:00 �s 19:00');
GO

-- 3. O administrador poder� cancelar o agendamento;
-- SITUACAO
INSERT INTO situacao (titulo)
VALUES ('Realizada'),('Agendada'),('Cancelada');
GO

-- USUARIO
INSERT INTO usuario(idTipoUsuario, nome, email, senha)
VALUES (3, 'Ligia', 'ligia@gmail.com', '12345678'),(3, 'Alexandre', 'alexandre@gmail.com', '34594675'),(3, 'Fernando', 'fernando@gmail.com', '23431874'),
(3, 'Henrique', 'henrique@gmail.com', '76557910'),(3, 'Jo�o', 'joao@hotmail.com', '01202486'),(3, 'Bruno', 'bruno@gmail.com', '62797645'),
(3, 'Mariana', 'mariana@outlook.com', '12858455'),(2, 'Dr. Ricardo L.', 'ricardo.lemos@spmedicalgroup.com.br', '44331870'),(2, 'Dr. Roberto P.', 'roberto.possarle@spmedicalgroup.com.br', '69824971'),
(2, 'Dra. Helena S.', 'helena.souza@spmedicalgroup.com.br', '41254970'),(1, 'Edvaldo', 'edvaldo.silva@spmedicalgroup.com.br', '47098654');
GO

-- PACIENTE
INSERT INTO paciente(idUsuario, nomeCompleto, dataNascimento, rg, cpf, endereco, telefone)
VALUES (1, 'Ligia Maria da Silva', '13/10/83', '43522543-5', '94839859000', 'Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000', '11 3456-7654'),
(2, 'Alexandre Duarte', '23/07/01', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200', '11 98765-6543'),
(3, 'Fernando Ferreira', '10/10/78', '54636525-3', '16839338002', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200', '11 97208-4453'),
(4, 'Henrique da Nobrega', '13/10/85', '54366362-5', '14332654765', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', '11 3456-6543'),
(5, 'Jo�o Martins', '27/08/75', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380', '11 7656-6377'),
(6, 'Bruno Xavier', '21/03/72', '54566266-7', '79799299004', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001', '11 95436-8769'),
(7, 'Mariana Castilho', '05/03/18', '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140', NULL);
GO

-- MEDICO
INSERT INTO medico(idEspecialidade, idClinica, idUsuario, nomeCompleto, crm)
VALUES (2, 1, 8, 'Ricardo Lemos', '54356-SP'),(17, 1, 9, 'Roberto Possarle', '53452-SP'),
(16, 1, 10, 'Helena Strada', '65463-SP');
GO

-- 2. O administrador poder� agendar uma consulta, onde ser� informado o paciente, 
-- data e hora do agendamento e qual m�dico ir� atender a consulta (o m�dico possuir� sua determinada especialidade);

-- 6. O m�dico poder� incluir a descri��o da consulta que estar� vinculada ao paciente (prontu�rio);
-- CONSULTA
INSERT INTO consulta(idMedico, idPaciente, idSituacao, dataHorario, resumo)
VALUES (3, 7, 1, '20/01/20 15:00', 'Consulta de rotina'),(2, 2, 3, '06/01/20 10:00', 'Retorno'),
(2, 3, 1, '07/02/20 11:00', 'Consulta de rotina'),(2, 2, 1, '06/02/18 10:00', 'Encaminhamento para exames'),
(1, 4, 3, '07/02/19 11:00', 'Falta de apetite'),(3, 7, 2, '08/03/20 15:00', 'Consulta de rotina'),
(1, 4, 2, '09/03/20 11:00', 'Encaminhamento para exames');
GO

