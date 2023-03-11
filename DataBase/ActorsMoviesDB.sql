----------------------------- CREATE DB -----------------------------------------
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ActorMoviesSRC')
BEGIN
  CREATE DATABASE ActorMoviesSRC;
END;
GO


USE ActorMoviesSRC


--------- Deleting  tables ----------------------------
IF  object_id('dbo.Actors') is not null
BEGIN
	drop table dbo.Actors;
END

IF  object_id('dbo.ImgPaths') is not null
BEGIN
	drop table dbo.ImgPaths;
END

IF  object_id('dbo.Movies') is not null
BEGIN
	drop table dbo.Movies;
end

--------- Creating  tables ----------------------------
IF  object_id('dbo.Movies') is null
BEGIN
	CREATE TABLE dbo.Movies (
		MovieId int PRIMARY KEY,
		Title varchar(255) NOT NULL,
		MovieDescription varchar(500),
	);
END

IF  object_id('dbo.Actors') is null
BEGIN
	CREATE TABLE dbo.Actors (
		ActorId int IDENTITY(1,1) PRIMARY KEY,
		FirstName varchar(255)NOT NULL,
		LastName varchar(255) NOT NULL,
		bornDate date,
		MovieId int FOREIGN KEY REFERENCES Movies(MovieId) not null
	);
END

IF  object_id('dbo.ImgPaths') is null
BEGIN
	CREATE TABLE dbo.ImgPaths (
		ImgPathId int IDENTITY(1,1) PRIMARY KEY,
		ImgPath varchar(500)NOT NULL,
		MovieId int FOREIGN KEY REFERENCES Movies(MovieId) not null
	);
END

--------- Seeding tables ----------------------------

INSERT INTO dbo.Movies VALUES
(1,'Title Movie1','descriptions for Movie1'),
(2,'Title Movie2','descriptions for Movie2'),
(3,'Title Movie3','descriptions for Movie3'),
(4,'Title Movie4','descriptions for Movie4');



INSERT INTO dbo.Actors VALUES 
('Name1','LastName1','1990-06-08',1),
('Name2','LastName2','1995-09-08',2),
('Name3','LastName3','1980-06-08',2),
('Name4','LastName4','1973-09-08',3),
('Name5','LastName5','2000-09-08',3),
('Name6','LastName6','2004-09-08',4),
('Name7','LastName7','2005-01-08',4),
('Name8','LastName8','2002-01-08',4);




INSERT INTO dbo.ImgPaths VALUES
('\Images\Img1.jpg',1),
('\Images\Img2.jpg',2),
('\Images\Img3.jpg',2),
('\Images\Img4.jpg',2),
('\Images\Img5.jpg',2),
('\Images\Img6.jpg',2),
('\Images\Img7.jpg',2),
('\Images\Img8.jpg',2),
('\Images\Img9.jpg',2),
('\Images\Img10.jpg',2),
('\Images\Img11.jpg',2),
('\Images\Img12.jpg',2),
('\Images\Img13.jpg',2),
('\Images\Img14.jpg',2),
('\Images\Img15.jpg',2);


select * from dbo.Actors;
select * from dbo.Movies;
select * from dbo.ImgPaths;
