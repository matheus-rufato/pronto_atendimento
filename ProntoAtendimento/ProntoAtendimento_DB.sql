create database prontoAtendimento5
go
use prontoAtendimento5
go

--Pessoas (Id, endereco, cpf, nome,telefone, status)
create table pessoas
(
	Id			int			not null	primary key identity,
	nome		varchar(50)	not null,
	cpf			varchar(14)	not null	unique,
	endereco	varchar(50)	not null,
	telefone	varchar(14)	not null,
	status		int			not null,
	check (status in (1,2,3))
)
go



--Pacientes (#Pessoa_id, convenio)

create table pacientes
( 
	paciente_id int			not null primary key references pessoas,
	convenio	varchar(15)
)
go

select * from v_pacientes
--Enfermeiros (#Pessoa_id, senha, login)


select * from v_atendentes
111222333-4543
create table atendentes
(
	atendente_id	int			not null primary key references pessoas,
	login			varchar(14)	not null unique,
	senha			varchar(14)	not null
)
go
--Medicos (#Pessoa_id, senha, login, crm)

create table medicos
(		
	medico_id	int			not null primary key references pessoas,
	crm			varchar(6)	not null unique,
	login		varchar(14) not null unique,
	senha		varchar(14) not null
)
go
--Consultas (Id, data, valor, #Paciente_id, #Colaborador_id)

select * from v_medicos

create table consultas 
(
	nr				int				not null primary key identity,
	paciente_id		int				not null,
	medico_id		int				not null,
	atendente_id	int				not null,
	data			datetime		not null,
	valor			money			not null,
	status			int				not null	default 1,
	diagnostico		varchar(max)		null,
	foreign key		(paciente_id)	references pacientes(paciente_id),
	foreign key		(medico_id)		references medicos(medico_id),
	foreign key		(atendente_id)	references atendentes(atendente_id),
	check			(status in (1,2,3))
)
go

--Procedimentos (Id, valor, tipo, nome)

create table procedimentos
(
	Id		int			not null primary key identity,
	nome	varchar(50) not null,
	tipo	int			not null,
	valor	money		not null,
	check (tipo between 1 and 3)
)
go
--Proc_Utiliza (#Consulta_id, #Procedimento_id, valor,observacao)

create table proc_utilizas
(
	consulta_nr		int				not null references consultas,
	procedimento_id int				not null references procedimentos,
	valor			money			not null,
	observacao		varchar(max)		null,
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


exec CadConsulta 8,5,1,'48','3'
select * from v_consultas
select * from v_medicos


create procedure CadConsulta
(
	@paciente int, @medico int, @atendente int, @valor money, @status int , @diagnostico varchar(max) = null
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

exec CadProdUtil 

SELECT* FROM v_consultas v, consultas c where c.nr = v.nr and c.medico_id = 4 and paciente_id = 8

select * from v_consultas
select * from consultas
select * from medicos

drop procedure CadValConsulta
create procedure CadValConsulta (@consulta int)
as
begin
	declare @valorTotal money
	set @valorTotal = (select sum(valor) from proc_utilizas where consulta_nr = @consulta)

	update consultas set valor = valor + @valorTotal  where nr = @consulta 
end
go

exec CadValConsulta 27


select * from v_consultas

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
	@Id int, @nome varchar(50), @cpf varchar(14), @endereco varchar(50), @telefone varchar(14), @status int, 
	@crm varchar(14),@login varchar(14), @senha varchar(14)
)
as
begin
	update pessoas set nome = @nome,cpf = @cpf, endereco = @endereco, telefone = @telefone, status = @status where Id = @Id
	update medicos set crm = @crm,login = @login, senha = @senha where medico_id = @Id
end
go


create procedure AltAtendente
(
	@Id int, @nome varchar(50), @cpf varchar(14), @endereco varchar(50), @telefone varchar(14), @status int, 
	@login varchar(14), @senha varchar(14)
)
as
begin
	update pessoas set nome = @nome, cpf = @cpf, endereco = @endereco, telefone = @telefone, status = @status where Id = @Id
	update atendentes set login = @login, senha = @senha where atendente_id = @Id
end
go




create procedure AltPaciente
(
	@Id int, @nome varchar(50), @cpf varchar(14), @endereco varchar(50), @telefone varchar(14), @status int, 
	@convenio varchar(15)
)
as
begin
	update pessoas set nome = @nome, cpf = @cpf, endereco = @endereco, telefone = @telefone, status = @status where Id = @Id
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

select* from v_medicos
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
	select pes.Id, pes.nome, pes.cpf, pes.endereco, pes.telefone, med.crm, med.login, med.senha,
		case status
			when 1 then 'Ativo'
			when 2 then 'Inativo'
			else 'Admin'
		end Situa��o
	from medicos med, pessoas pes 
	where pes.Id = med.medico_id
go

select * from v_atendentes
select * from v_consultas
create view v_atendentes
as
	select pes.Id, pes.nome, pes.cpf, pes.endereco, pes.telefone, ate.login, ate.senha,
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


drop view v_consultas

select * from v_medicos
drop view v_consultas

select * from v_consultas
select * from procedimentos

drop view v_consultas 
create view v_consultas
as
	select con.nr, med.nome [Nome M�dico], med.crm, pac.nome [Nome Paciente], pac.cpf, pac.convenio, con.data, isnull(con.diagnostico,' ') as diagnostico,
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



-------------------------------------SELECTS E FUN��ES ----------------------------------------------
--drop procedure CadProdUtil
select * from v_atendentes
select * from pessoas
select * from medicos
select * from atendentes
select * from pacientes
select * from procedimentos
select * from consultas
select * from v_proc_utilizas where Nr = 3
go

exec CadAtendente 'admin', '0000', 'Rua 0, numero 0', '17 90000-0000', 'admin@admin','admin'
exec CadAtendente 'Jo�o da Silva', '101010', 'S�o Pedro, 2034', '17 99999-8888', 'joao@silva','123456'
exec CadAtendente 'Maria Moura', '202020', 'Santo Antonio, 2478', '17 9999-7777', 'maria@moura','123456'
exec CadAtendente 'Fernando Silva', '303030', 'S�o Jos�, 1791', '17 9888-9999', 'fernando@silva','123456'
exec CadMedico'Jos� da Silva', '404040', 'S�o Paulo, 2417', '17 9988-8888', '892550', 'jose@silva','123456'
exec CadMedico'Paulo de Souza', '505050', 'S�o Miguel, 2178', '17 9777-8888', '895001', 'paulo@souza','123456'
exec CadMedico'Geraldo Tavares', '606060', 'S�o Jo�o, 1048', '17 99999-7890', '891589', 'geraldo@tavares','123456'
exec CadMedico'Joao das Couves', '619060', 'S�o Jo�o, 1048', '17 912155888', '890289', 'couves@joao','123456'
go


exec AltAtendente  1,'admin','00000000000-00', 'Administrador', '00 00000-0000',1,'admin@admin', '123456'
exec AltAtendente 2, 'Maria Moura', '12321232547612', 'Santo Antonio, 2478', '17 998520623', 2, 'maria@moura','789101'
go
exec AltAtendente 1


select * from consultas
exec CadConsulta 
exec CadProcedimento 'Medica��o', 1, 50
exec CadProcedimento 'Curativo', 1, 70
exec CadProcedimento 'Raio-x', 2, 140
exec CadProcedimento 'Sutura', 1, 80
exec CadProcedimento 'Hidrata��o', 1, 50
exec CadProcedimento 'Exame de sangue', 2, 100
go

exec CadPaciente 'Vilma Roberta', '707070', 'Padre Ernesto, 2014', '17 99000-1234', '20105924281'
exec CadPaciente 'Fabio Jo�o', '808080', 'S�o Benedito, 218', '17 9123-4567', '14566788153'
exec CadPaciente 'Patricia Luisa', '909090', 'S�o Jorge, 6875', '17 98765-4321', '67816671981'
go

exec CadConsulta 7, 4, 1, 150, 1
exec CadConsulta 9, 5, 1, 150, 1
go
select * from proc_utilizas
exec AltConsulta 1, 3, 'Alergia'
exec CadProdUtil 1, 1, 'Ocorreu tudo bem'
exec CadValConsulta 1
exec AltConsulta 3, 1
exec CadProdUtil 2, 6 
exec AltConsulta 2, 2, 'O paciente est� com dengue'
exec CadProdUtil 2, 1
exec CadValConsulta 2
go

select * from v_pacientes
select * from v_medicos
select * from v_atendentes where Id = 3
select * from v_consultas
select * from v_procedimentos
select * from v_proc_utilizas
go

select * from v_consultas where Situa��o = 'Encerrada'
select * from v_proc_utilizas where Nr = 2

--select * from v_consultas inner join v_proc_utilizas on v_consultas.nr = v_proc_utilizas.Nr

-- sp_select * from procedimentos
select * from pacientes
select * from pessoas

delete from pacientes where paciente_id=26
delete from pessoas where Id=26

select * from consultas
select * from proc_utilizas

delete from proc_utilizas where consulta_nr=1
delete from consultas where paciente_id=7 

select * from v_medicos
select * from v_atendentes

select * from v_consultas where Situa��o != 'Encerrada'

select v_med.Id, v_med.nome, v_med.telefone, med.login from medicos med, v_medicos v_med 
where med.login = 'carla@123' and med.senha = '151617' and v_med.Id = med.medico_id 

select * from medicos
--sp_help consultas