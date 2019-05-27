USE master
IF EXISTS(select * from sys.databases where name='aircraft_system_control')
BEGIN
	ALTER DATABASE aircraft_system_control SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE aircraft_system_control 
END

GO

CREATE DATABASE aircraft_system_control;

GO

USE aircraft_system_control;

CREATE TABLE regions (
id int identity(1,1) primary key,
[description] varchar(50)
)

GO

CREATE TABLE airports (
id int identity(1,1) primary key,
[name] varchar(50),
region_id int,
CONSTRAINT fk_region_id FOREIGN KEY (region_id) REFERENCES regions(id) 
)

GO

CREATE TABLE pilot_licenses (
id int identity(1,1) primary key,
title varchar(150)
)

GO

CREATE TABLE pilots (
id int primary key,
[name] varchar(50),
license_id int,
gender char,
birth_date date, 
CONSTRAINT fk_license_id FOREIGN KEY (license_id) REFERENCES pilot_licenses(id)
)

GO

CREATE TABLE aircraft_brands(
id int identity(1,1) primary key,
[name] varchar(50),
)

GO

CREATE TABLE aircrafts (
id int primary key,
[name] varchar(200),
brand_id int,
manufacture_date date,
capacity int,
[image] varchar(255)
CONSTRAINT fk_brand_id FOREIGN KEY (brand_id) REFERENCES aircraft_brands(id)
)

GO

CREATE TABLE flights (
id int primary key,
aircraft_id int,
depart_from_id int,
arrive_at_id int,
duration int,
in_route bit,
pilot_id int,
co_pilot_id int,
depart_date datetime,
arrive_date datetime,
CONSTRAINT fk_aircraft_id FOREIGN KEY (aircraft_id) REFERENCES aircrafts(id),
CONSTRAINT fk_depart_from_id FOREIGN KEY (depart_from_id) REFERENCES airports(id),
CONSTRAINT fk_arrive_at_id FOREIGN KEY (arrive_at_id) REFERENCES airports(id),
CONSTRAINT fk_pilot_id FOREIGN KEY (pilot_id) REFERENCES pilots(id),
CONSTRAINT fk_co_pilot_id FOREIGN KEY (co_pilot_id) REFERENCES pilots(id),
)

GO

CREATE TABLE  air_routes (
id int identity(1,1) primary key,
name varchar(50),
flights_limit int
)

GO

CREATE TABLE air_routes_flights(
id int primary key,
flight_id int,
air_route_id int,
CONSTRAINT fk_flight_id FOREIGN KEY (flight_id) REFERENCES flights(id),
CONSTRAINT fk_air_route_id FOREIGN KEY (air_route_id) REFERENCES air_routes(id)
)

GO

CREATE PROCEDURE sp_create_aircraft(
@id int,
@brand_id int, 
@image varchar(255),
@name varchar(200), 
@capacity int,
@manufacture_date date
) AS 
BEGIN 
	INSERT INTO aircrafts (id, brand_id, [name], manufacture_date, capacity, [image]) 
	VALUES (@id, @brand_id, @name, @manufacture_date, @capacity, @image) 
END

GO
CREATE PROCEDURE sp_update_flight(
@id int,
@aircraft_id int,
@depart_from_id int,
@arrive_at_id int,
@duration int,
@pilot_id int,
@co_pilot_id int,
@depart_date datetime,
@arrive_date datetime,
@in_route int
)AS 
BEGIN
	UPDATE flights SET
		aircraft_id = @aircraft_id,
		depart_from_id = @depart_from_id,
		arrive_at_id = @arrive_at_id,
		duration = @duration,
		pilot_id = @pilot_id,
		co_pilot_id = @co_pilot_id,
		depart_date = @depart_date,
		arrive_date = @arrive_date,
		in_route = @in_route
	WHERE id = @id
END
GO

CREATE PROCEDURE sp_create_flight(
@id int,
@aircraft_id int,
@depart_from_id int,
@arrive_at_id int,
@duration int,
@pilot_id int,
@co_pilot_id int,
@depart_date datetime,
@arrive_date datetime,
@in_route int
) AS 
BEGIN 
	INSERT INTO flights (
		id,
		aircraft_id,
		depart_from_id,
		arrive_at_id,
		duration,
		pilot_id,
		co_pilot_id,
		depart_date,
		arrive_date,
		in_route
	) 
	VALUES (
		@id,
		@aircraft_id,
		@depart_from_id,
		@arrive_at_id,
		@duration,
		@pilot_id,
		@co_pilot_id,
		@depart_date,
		@arrive_date,
		@in_route
	) 
END

GO

CREATE PROCEDURE sp_search_aircraft(
	@id int = NULL,
	@model_id int = NULL, 
	@type_id int = NULL, 
	@manufacture_date varchar = NULL, 
	@available bit = NULL
) AS 
BEGIN 
	DECLARE @where varchar, @query varchar
	IF(@model_id != -1) 
		SET @where = CONCAT('model_id = ', @model_id, ' ')
	IF(@type_id != -1)
		SET @where = CONCAT(@where, 'type_id = ', @type_id, ' ')
	IF(@available != -1)
		SET @where = CONCAT(@where, 'available = ', CAST(@available AS CHAR))
	IF(@manufacture_date != NULL)
		SET @where = CONCAT(@where, 'manufacture_date = ' + @manufacture_date)
	SET @query = CONCAT('SELECT * FROM aircrafts WHERE ', @where)
	EXEC(@query) 
END 

GO

CREATE PROCEDURE sp_search_flight (
@id int = NULL,  
@aircraft_id int = NULL,
@arrive_date datetime = NULL,
@arrive_at_id int = NULL,
@depart_date datetime = NULL,
@depart_from_id int = NULL,
@pilot_id varchar = NULL,
@co_pilot_id varchar = NULL,
@duration int = NULL,
@in_route int = NULL
) AS 
BEGIN 
	DECLARE @where varchar, @query varchar
	IF(@id != NULL) 
		SET @where = CONCAT(' ', 'id = ', @id , ' ') 
	IF(@aircraft_id != -1) 
		SET @where = CONCAT(' ', 'aircraft_id = ', @aircraft_id , ' ') 
	IF(@depart_from_id != -1)  
		SET @where = CONCAT('depart_from_id = ', @depart_from_id , ' ') 
	IF(@arrive_at_id != -1)  
		SET @where = CONCAT('arrive_at_id = ', @arrive_at_id , ' ') 
	IF(@duration != -1)  
		SET @where = CONCAT('duration = ', @duration , ' ') 
	IF(@pilot_id != NULL)  
		SET @where = CONCAT('pilots.id = ', @pilot_id , ' ') 
	IF(@co_pilot_id != NULL)  
		SET @where = CONCAT('pilots.id = ', @co_pilot_id , ' ') 
	IF(@depart_date != NULL)  
		SET @where = CONCAT('depart_date = ', @depart_date , ' ') 
	IF(@arrive_date != NULL)  
		SET @where = CONCAT('arrive_date = ', @arrive_date , ' ') 
	IF(@in_route != -1)  
		SET @where = CONCAT('in_route = ', @in_route ) 
	SET @query = CONCAT('
	SELECT * FROM flights 
	INNER JOIN pilots 
	ON flights.pilot_id = pilots.id',
	@where
	)
	EXEC(@query) 
END 

GO

CREATE PROCEDURE sp_create_pilot (
@id int,
@name varchar(50),
@license_id int,
@gender char(1),
@birth_date date
) AS 
BEGIN 
 INSERT INTO pilots (
	id,
	[name],
	license_id,
	gender,
	birth_date
 ) VALUES (
	@id,
	@name,
	@license_id,
	@gender,
	@birth_date
 )
END 

GO

CREATE PROCEDURE sp_update_pilot (
@id int,
@name varchar(50),
@license_id int,
@gender char(1),
@birth_date date
) AS 
BEGIN 
 UPDATE pilots SET
	[name] = @name,
	license_id =@license_id,
	gender = @gender,
	birth_date = @birth_date
WHERE id = @id
END 

GO

CREATE PROCEDURE sp_search_pilot (
@name varchar(50) = NULL,
@id int = NULL,
@license_id int = NULL,
@gender char(1) = NULL,
@birth_date varchar = NULL
) AS 
BEGIN 
	DECLARE @where varchar, @query varchar 
	IF(@id != NULL) 
		SET @where = CONCAT(' ', 'id = ', @id , ' ') 
	IF(@name != NULL) 
		SET @where = CONCAT(' ', 'name = ', @name , ' ') 
	IF(@license_id != -1)  
		SET @where = CONCAT('license_id = ', @license_id , ' ') 
	IF(@gender != 'N')  
		SET @where = CONCAT('gender = ', @gender , ' ') 
	IF(@birth_date != NULL)  
		SET @where = CONCAT('birth_date = ', @birth_date , ' ') 
	SET @query = CONCAT('
	SELECT * FROM pilots
	INNER JOIN licenses 
	ON pilots.license_id = licenses.id',
	@where
	)
	EXEC(@query) 
END

GO

CREATE PROCEDURE sp_delete_flights_by_id(@id int) AS 
BEGIN 
	DELETE FROM flights where id = @id 
END

GO

CREATE PROCEDURE sp_delete_pilots_by_id(@id int) AS 
BEGIN 
	DELETE FROM pilots where id = @id 
END

GO

CREATE PROCEDURE sp_delete_aircrafts_by_id(@id int) AS 
BEGIN 
	DELETE FROM aircrafts where id = @id 
END

GO

CREATE PROCEDURE sp_first_pilot 
AS SELECT TOP 1 * FROM pilots ORDER BY id

GO

CREATE PROCEDURE sp_first_flight 
AS SELECT TOP 1 * FROM flights ORDER BY id

GO

CREATE PROCEDURE sp_first_aircraft
AS SELECT TOP 1 * FROM aircrafts ORDER BY id

GO


CREATE PROCEDURE sp_last_pilot 
AS SELECT TOP 1 * FROM pilots ORDER BY id DESC

GO

CREATE PROCEDURE sp_last_flight
AS SELECT TOP 1 * FROM flights ORDER BY id DESC

GO

CREATE PROCEDURE sp_last_aircraft
AS SELECT TOP 1 * FROM aircrafts ORDER BY id DESC

GO
CREATE PROCEDURE sp_next_pilot_id (@current int = NULL) 
AS
BEGIN
	IF(@current IS NULL) 
		SELECT TOP 1 id FROM pilots ORDER BY id DESC
	ELSE 
		SELECT TOP 1 * FROM pilots WHERE id > @current ORDER BY id 
END 

GO

CREATE PROCEDURE sp_next_flight_id (@current int = NULL) 
AS 
BEGIN 
	IF(@current IS NULL) 
		SELECT TOP 1 id FROM flights ORDER BY id DESC 
	ELSE 
		SELECT TOP 1 * FROM flights WHERE id > @current ORDER BY id 
END 

GO

CREATE PROCEDURE sp_previous_flight_id (@current int = NULL) 
AS SELECT TOP 1 * FROM flights WHERE id < @current ORDER BY id DESC 
GO

CREATE PROCEDURE sp_previous_pilot_id (@current int) 
AS SELECT TOP 1 * FROM pilots WHERE id < @current ORDER BY id DESC
GO

CREATE TRIGGER tg_delete_cascade_pilot_data 
ON [pilots] 
AFTER DELETE AS
BEGIN 
DECLARE @pilot_id int 
SELECT @pilot_id = id FROM DELETED  
DELETE FROM flights WHERE  pilot_id = @pilot_id 
END

GO

CREATE TRIGGER tg_delete_cascade_aircraft_data 
ON [aircrafts] 
AFTER DELETE AS 
BEGIN 
DECLARE @aircraft_id int 
SELECT @aircraft_id = id FROM DELETED 
DELETE FROM flights WHERE  aircraft_id = @aircraft_id 
DELETE FROM aircraft_models WHERE  id = @aircraft_id 
END 
GO 
INSERT INTO pilot_licenses (title) VALUES ('Piloto privado (PP)')
GO
INSERT INTO pilot_licenses (title) VALUES ('Piloto comercial (PC)') 
GO
INSERT INTO pilot_licenses (title) VALUES ('Piloto de tripulação múltipla (PTM)') 
GO
INSERT INTO pilot_licenses (title) VALUES ('Piloto de linha aérea (PLA)') 
GO
INSERT INTO pilots (id, [name], gender, license_id, birth_date) VALUES (1, 'Lucas Boulle', 'M', 1, '1998-08-03') 
GO
INSERT INTO pilots (id, [name], gender, license_id, birth_date) VALUES (2, 'Leonardo Aragão', 'M', 3, '1999-01-03')
GO
INSERT INTO aircraft_brands ([name]) VALUES ('Boeing Business Jets')
GO
INSERT INTO aircrafts (id, brand_id, [name], manufacture_date, capacity, [image]) 
VALUES (1, 1, 'SP124', '2005-04-07', 300000, 'teste')
GO
INSERT INTO regions ([description]) VALUES ('Brasil')
GO
INSERT INTO regions ([description]) VALUES ('Iraque')
GO
INSERT INTO airports([name], region_id) VALUES ('Aeroporto de Guarulhos', 1)
GO
INSERT INTO airports([name], region_id) VALUES ('Aeroporto de Al Najaf', 1)
GO
	INSERT INTO flights (
		id,
		aircraft_id,
		depart_from_id,
		arrive_at_id,
		duration,
		pilot_id,
		co_pilot_id,
		depart_date,
		arrive_date,
		in_route
	) 
	VALUES (
		1,
		1,
		1,
		2,
		10000,
		1,
		2,
		'2005-04-02 12:34:22',
		'2005-04-03 12:12:12',
		0
	)
GO
	INSERT INTO flights (
		id,
		aircraft_id,
		depart_from_id,
		arrive_at_id,
		duration,
		pilot_id,
		co_pilot_id,
		depart_date,
		arrive_date,
		in_route
	) 
	VALUES (
		2,
		1,
		2,
		1,
		10000,
		2,
		1,
		'2005-04-02 12:34:22',
		'2005-04-03 12:12:12',
		0
	) 