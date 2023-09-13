create database EnxamePhobosDB;
use EnxamePhobosDB;

--TipoUSuario
CREATE TABLE TipoUsuario
(
    [IdTipoUsuario] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [DescricaoTipoUsuario] NVARCHAR(150) NOT NULL 

);

INSERT INTO TipoUsuario VALUES ('Administrador'),('Outros');
SELECT * FROM TipoUsuario;

--Usuario
CREATE TABLE Usuario (
    [IdUsuario] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NomeUsuario] NVARCHAR (150) NOT NULL,
    [SenhaUsuario] NVARCHAR (6) UNIQUE NOT NULL,
    [EmailUsuario] NVARCHAR (150) NOT NULL,
    [DataNascUsuario] DATE NOT NULL,
    [UsuarioTp]INT NOT NULL,
	
   FOREIGN KEY (UsuarioTp) REFERENCES TipoUsuario(IdTipoUsuario)
);

INSERT INTO Usuario ([NomeUsuario],[SenhaUsuario],[EmailUsuario],[DataNascUsuario],[UsuarioTp]) VALUES 
('Uil','123456','uil@email.com','1980-02-29',1),
('robsu','123457','robsu@email.com','1989-06-18',2);

SELECT * FROM Usuario;
SELECT [NomeUsuario],[SenhaUsuario],[EmailUsuario],[DataNascUsuario],[DescricaoTipoUsuario] FROM Usuario INNER JOIN 
TipoUsuario ON [UsuarioTp] = IdTipoUsuario;

UPDATE Usuario SET [NomeUsuario] = @nome,[SenhaUsuario]=@senha,[EmailUsuario]=@email,
[DataNascUsuario] = @data,[UsuarioTp] = @usuarioTp WHERE IdUsuario = @id;

SELECT * FROM Usuario WHERE NomeUsuario='Uil' AND SenhaUsuario='123456';

SELECT * FROM Usuario WHERE IdUsuario = 1;

SELECT * FROM TipoUsuario;

SELECT * FROM Usuario WHERE NomeUsuario='UIL' AND SenhaUsuario='123456';


use EnxamePhobosDB;
select * from usuario;

create table Genero(
IdGenero int identity (1,1) primary key,
DescricaoGenero varchar(150) not null
);
insert into Genero(DescricaoGenero)values('Animação'),('Aventura'),
('Drama'),('Porno'),('Terror');



create table Classificacao(
IdClassificacao int identity (1,1) primary key,
DescricaoClassificacao varchar(150) not null
);
insert into Classificacao(DescricaoClassificacao)values('Livre'),('+14'),
('+18');


create table Filme(
IdFilme int identity (1,1) primary key,
TituloFilme varchar(150) not null,
ProdutoraFilme varchar(150) not null,
UrlImgFilme varchar(max) not null,
GeneroFilme_Id int,
ClassificacaoFilme_Id int,

Foreign key (GeneroFilme_Id) references Genero(IdGenero),
Foreign key (ClassificacaoFilme_Id) references 
Classificacao(IdClassificacao)

);

insert into Filme(TituloFilme,ProdutoraFilme,UrlImgFilme,GeneroFilme_Id,ClassificacaoFilme_Id)
values('A volta dos que não foram','Mondo Bizarro','../img/volta.jpg',1,1),
('Porcos do espaço','Uorner','../img/porcos.jpg',1,1),
('Teens absolute','Reberti Richardi','../img/teens.jpg',2,2),
('Altas tretas','Iemai','../img/altas.jpg',2,2),
('Filhos do desespero','Brasil Filmes','../img/filhos.jpg',3,2),
('Leprozário','Calango Azul','../img/leprozario.jpg',3,2),
('A vizinha','Americaninhas','../img/vizinha.jpg',4,3),
('Piranhas do caribe','Americaninhas','../img/piranhas.jpg',4,3),
('Exorcismo dos caras','Gore productions','../img/exorcismo.jpg',5,3),
('Pc do mal','Gore productions','../img/pc.jpg',5,3);

select * from filme;

DELETE FROM Filme WHERE IdFilme = 10;

SELECT IdFilme, TituloFilme, ProdutoraFilme, UrlImgFilme, DescricaoGenero, DescricaoClassificacao 
FROM Filme INNER JOIN Genero ON GeneroFilme_Id = IdGenero INNER JOIN Classificacao 
ON ClassificacaoFilme_Id = IdClassificacao WHERE IdFilme =6;

SELECT * FROM Genero;