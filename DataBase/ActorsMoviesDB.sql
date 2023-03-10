----------------------------- CREATE DB -----------------------------------------
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ActorMoviesSRC')
BEGIN
  CREATE DATABASE ActorMoviesSRC;
END;
GO


USE ActorMoviesSRC


--------- deleting - Creating tables ----------------------------

IF  object_id('dbo.Movies') is not null
BEGIN
	drop table dbo.Movies;
end
IF  object_id('dbo.Actors') is not null
BEGIN
	drop table dbo.Actors;
END

IF  object_id('dbo.Actors') is null
BEGIN
	CREATE TABLE dbo.Actors (
		ActorId int IDENTITY(1,1) PRIMARY KEY,
		LastName varchar(255) NOT NULL,
		FirstName varchar(255)NOT NULL,
	);
END


IF  object_id('dbo.Movies') is null
BEGIN
	CREATE TABLE dbo.Movies (
		MovieId int IDENTITY(1,1) PRIMARY KEY,
		MovieTitle varchar(255) NOT NULL,
		MovieDate date,
		ActorId int FOREIGN KEY REFERENCES Actors(ActorId) not null
	);
END
 

--------- Seeding tables ----------------------------

INSERT INTO dbo.Actors VALUES 
('Name1','LastName1'),
('Name2','LastName2'),
('Name3','LastName3')



INSERT INTO dbo.Movies VALUES
('Title Movie1_1','2020-01-01',1),
('Title Movie1_2','2020-06-01',1),
('Title Movie2_1','2021-01-01',2),
('Title Movie2_2','2021-06-01',2),
('Title Movie3_1','2022-01-01',3)

select * from dbo.Actors;
select * from dbo.Movies;