create database Alumnos
go
use Alumnos
go
--drop database Alumnos

create table AD_Cursos
(
	IDCurso int identity(1,1) not null,
	NombreCurso varchar(15) null,

	constraint PK_Cursos primary key (IDCurso) 
)

create table AD_Alumnos
(
	ID int identity(1,1) not null,
	NombreAlumno varchar(15) null,
	ApellidosAlumno varchar(20) null,
	Beca decimal(6,2) null,
	IdCurso int null,

	constraint PK_Alumnos primary key (ID),
	constraint FK_Cursos_Alumnos foreign key (IDCurso) references AD_Cursos(IDCurso)
)


go

--insert into AD_Cursos(NombreCurso)
--values('primero FP'),('segundo FP')

--insert into AD_Alumnos(NombreAlumno,ApellidosAlumno,Beca,IdCurso)
--values('Nzhdeh','Yeghiazaryan',2500.0,2),('Armine','Yeghiazaryan',3500.10,2)

--select * from AD_Cursos
--select * from AD_Alumnos