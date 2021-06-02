create database prontoAtendimento
go
use prontoAtendimento
go

--Pessoas (Id, endereco, cpf, nome,telefone, status)
create table pessoas
(
	Id               int         not null  primary key identity,
	nome			 varchar(50) not null,  
	cpf              varchar(14) not null  unique,
	endereco         varchar(50) not null,
	telefone         varchar(14) not null,
	status           int         not null,
	check (status in (1,2,3))
)
go



--Pacientes (#Pessoa_id, convenio)

create table pacientes
( 
	paciente_id     int          not null  primary key references pessoas,
	convenio        varchar(15)
)
go

--Enfermeiros (#Pessoa_id, senha, login)

create table atendentes
(
	atendente_id      int           not null primary key references pessoas,
	login			  varchar(14)	not null unique,
	senha             varchar(14)	not null
)
go
--Medicos (#Pessoa_id, senha, login, crm)

create table medicos
(		
	medico_id         int          not null  primary key references pessoas,
	crm               varchar(6)  not null  unique,
    login             varchar(14) not null  unique,
	senha             varchar(14) not null
)
go
--Consultas (Id, data, valor, #Paciente_id, #Colaborador_id)

create table consultas
(
	nr                int				not null primary key identity,
	paciente_id		  int				not null,
	medico_id		  int				not null,
	atendente_id	  int				not null,
	data              datetime			not null,
	valor             money				not null,
	status            int				not null,
	diagnostico       varchar(max)			null,
	foreign key       (paciente_id)   references pacientes(paciente_id),
    foreign key       (medico_id)     references medicos(medico_id),
	foreign key       (atendente_id)  references atendentes(atendente_id),
	check	          (status in (1,2,3))
)
go

--Procedimentos (Id, valor, tipo, nome)

create table procedimentos
(		
	Id                int          not null primary key identity,
	nome              varchar (50) not null,
	tipo              int          not null,
	valor             money		   not null,
	check (tipo between 1 and 3)
)
go
--Proc_Utiliza (#Consulta_id, #Procedimento_id, valor,observacao)

create table proc_utilizas
(
 	consulta_nr   	 int		  not null  references consultas,
	procedimento_id  int		  not null  references procedimentos,
	valor            money		  not null,
	observacao       varchar (max)	  null,
	primary key(consulta_nr, procedimento_id)       	
)
go

create procedure CadMedico
(
	@nome varchar(50), @cpf varchar(14), @endereco varchar(50), @telefone varchar(14), 
	@crm varchar(6), @login varchar(14), @senha varchar(14)
)
as
begin
	insert into pessoas values (@nome, @cpf, @endereco, @telefone, 1)
	insert into medicos values (@@IDENTITY, @crm, @login, @senha)
end
go

create procedure CadAtendente
(
	@nome varchar(50), @cpf varchar(14), @endereco varchar(50), @telefone varchar(14), 
    @login varchar(14), @senha varchar(14)
)
as
begin
	insert into pessoas values (@nome, @cpf, @endereco, @telefone, 1)
	insert into atendentes values (@@IDENTITY, @login, @senha)
end
go

create procedure CadPaciente
(
	@nome varchar(50), @cpf varchar(14), @endereco varchar(50), @telefone varchar(14), 
	@convenio varchar(15)
)
as
begin
	insert into pessoas values (@nome, @cpf, @endereco, @telefone, 1)
	insert into pacientes values (@@IDENTITY, @convenio)
end
go

create procedure CadProcedimento
(
	@nome varchar(50), @tipo int, @valor money
)
as
begin
	insert into procedimentos values (@nome, @tipo, @valor)
end
go

create procedure CadConsulta
(
	@paciente int, @medico int, @atendente int, @valor money, @status int, @diagnostico varchar(max) = null
)
as
begin
	insert into consultas (paciente_id, medico_id, atendente_id, data, valor, status, diagnostico) 
		values (@paciente, @medico, @atendente, CONVERT (datetime, GETDATE()), @valor, @status, @diagnostico)

end
go

create procedure CadProdUtil
(
	@consulta int, @procedimento int, @obs varchar(max) = null
)
as
begin
	declare @valor money
	set @valor = (select valor from procedimentos
				  where Id = @procedimento)
	insert into proc_utilizas values (@consulta, @procedimento, @valor, @obs)
end
go

create procedure CadValConsulta (@consulta int)
as
begin
	declare @valorTotal money
	set @valorTotal = (select sum(valor) from proc_utilizas where consulta_nr = @consulta)

	update consultas set valor = valor + @valorTotal where nr = @consulta 
end
go

create procedure AltProcedimento
(
	@Id int, @nome varchar(50), @tipo int, @valor money	
)
as
begin
	update procedimentos set nome = @nome, tipo = @tipo, valor = @valor where Id = @Id
end
go

create procedure AltMedico
(
	@Id int, @nome varchar(50), @endereco varchar(50), @telefone varchar(14), @status int, 
	@login varchar(14), @senha varchar(14)
)
as
begin
	update pessoas set nome = @nome, endereco = @endereco, telefone = @telefone, status = @status where Id = @Id
	update medicos set login = @login, senha = @senha where medico_id = @Id
end
go

create procedure AltAtendente
(
	@Id int, @nome varchar(50), @endereco varchar(50), @telefone varchar(14), @status int, 
	@login varchar(14), @senha varchar(14)
)
as
begin
	update pessoas set nome = @nome, endereco = @endereco, telefone = @telefone, status = @status where Id = @Id
	update atendentes set login = @login, senha = @senha where atendente_id = @Id
end
go

create procedure AltPaciente
(
	@Id int, @nome varchar(50), @endereco varchar(50), @telefone varchar(14), @status int, 
	@convenio varchar(15)
)
as
begin
	update pessoas set nome = @nome, endereco = @endereco, telefone = @telefone, status = @status where Id = @Id
	update pacientes set convenio = @convenio where paciente_id = @Id
end
go

Create procedure AltConsulta
(
	@nr int, @status int , @diagnostico varchar(max) = null
)
as
begin
	update consultas set status = @status, diagnostico = @diagnostico where nr = @nr  
end
go

create view v_pacientes
as
	select pes.Id, pes.nome, pes.cpf, pes.endereco, pes.telefone, pac.convenio,
		case status
			when 1 then 'Ativo'
			when 2 then 'Inativo'
			else 'Admin'
		end Situa��o
	from pacientes pac, pessoas pes 
	where pes.Id = pac.paciente_id
go

create view v_medicos
as
	select pes.Id, pes.nome, pes.cpf, pes.endereco, pes.telefone, med.crm,
		case status
			when 1 then 'Ativo'
			when 2 then 'Inativo'
			else 'Admin'
		end Situa��o
	from medicos med, pessoas pes 
	where pes.Id = med.medico_id
go

create view v_atendentes
as
	select pes.Id, pes.nome, pes.cpf, pes.endereco, pes.telefone,
		case status
			when 1 then 'Ativo'
			when 2 then 'Inativo'
			else 'Admin'
		end Situa��o
	from atendentes ate, pessoas pes 
	where pes.Id = ate.atendente_id
go

create view v_procedimentos
as
	select pro.Id, pro.nome, pro.valor,
		case pro.tipo
			when 1 then 'ambulatorial'
			when 2 then 'laboratorial'
			else		'translado'
		end	Tipo
	from procedimentos pro
go

create view v_consultas
as
	select con.nr, med.nome [Nome M�dico], med.crm, pac.nome [Nome Paciente], pac.cpf, pac.convenio, con.data, con.diagnostico, 
		con.valor [Valor Total],
		case con.status
			when 1 then 'Ativa'
			when 2 then 'Encerrada'
			else		'Aberta'
		end Situa��o
	from consultas con, v_medicos med, v_pacientes pac
	where con.medico_id = med.Id and con.paciente_id = pac.Id
go

create view v_proc_utilizas
as
	select prou.consulta_nr Nr, pro.nome, pro.Tipo, pro.valor
	from proc_utilizas prou, v_procedimentos pro
	where pro.Id = prou.procedimento_id
go

--drop procedure CadProdUtil

select * from pessoas
select * from medicos
select * from atendentes
select * from pacientes
select * from procedimentos
select * from consultas
select * from proc_utilizas
go

exec CadAtendente 'Jo�o da Silva', '101010', 'S�o Pedro, 2034', '17 991425364', 'joao@silva','123456'
exec CadAtendente 'Maria Moura', '202020', 'Santo Antonio, 2478', '17 998520623', 'maria@moura','789101'
exec CadAtendente 'Fernando', '303030', 'S�o Jos�, 1791', '17 992364220', 'fernando@123','121314'
exec CadMedico'Carla', '404040', 'S�o Paulo, 2417', '17 991364768', '892550', 'carla@123','151617'
exec CadMedico'Paulo', '505050', 'S�o Miguel, 2178', '17 996715668', '895001', 'paulo@123','181920'
exec CadMedico'Lucas', '606060', 'S�o Jo�o, 1048', '17 998155888', '891589', 'lucas@123','212223'
go

exec AltAtendente 2, 'Maria Moura', 'Santo Antonio, 2478', '17 998520623', 3, 'maria@moura','789101'
go

exec CadProcedimento 'Medica��o', 1, 50
exec CadProcedimento 'Curativo', 1, 70
exec CadProcedimento 'Raio-x', 2, 140
exec CadProcedimento 'Sutura', 1, 80
exec CadProcedimento 'Hidrata��o', 1, 50
exec CadProcedimento 'Exame de sangue', 2, 100
go

exec CadPaciente 'Vilma', '707070', 'Padre Ernesto, 2014', '17 991230774', '20105924281'
exec CadPaciente 'Fabio', '808080', 'S�o Benedito, 218', '17 991747886', '14566788153'
exec CadPaciente 'Patricia', '909090', 'S�o Jorge, 6875', '17 998166741', '67816671981'
go

exec CadConsulta 7, 4, 1, 150, 1
exec CadConsulta 9, 5, 1, 150, 1
go

exec AltConsulta 1, 2, 'Alergia'
exec CadProdUtil 1, 1, 'Ocorreu tudo bem'
exec CadValConsulta 1
exec AltConsulta 2, 3
exec CadProdUtil 2, 6 
exec AltConsulta 2, 2, 'O paciente est� com dengue'
exec CadProdUtil 2, 1
exec CadValConsulta 2
go

select * from v_pacientes
select * from v_medicos
select * from v_atendentes
select * from v_consultas
select * from v_procedimentos
select * from v_proc_utilizas
go

select * from v_consultas where Situa��o = 'Encerrada'
select * from v_proc_utilizas where Nr = 2

--select * from v_consultas inner join v_proc_utilizas on v_consultas.nr = v_proc_utilizas.Nr

-- sp_help consultas