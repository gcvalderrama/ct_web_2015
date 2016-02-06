use master; 

create database MoviesDB; 
go
use MoviesDB; 

create table  Movies 
(
	Id int primary key identity(1,1),  
	Title nvarchar(512), 
	Description nvarchar(2056),
	Poster varchar(512) null 
)
go 
create table Reviews 
(
	Id int primary key identity(1,1),  
	Comment nvarchar(2056), 
	Score int , 
	MovieId int references  Movies(Id)
)
go 
create procedure usp_movies_count
as 
select count(*)  from movies 
go
create procedure usp_movies_get
as 
select *  from movies 
go
create procedure usp_movies_get_one
@Id int
as 
select *  from movies where Id = @Id


