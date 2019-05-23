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
title varchar(15)
)

GO

CREATE TABLE pilots (
id int identity(1,1) primary key,
[name] varchar(50),
license_id int,
gender char,
birth_date date, 
CONSTRAINT fk_license_id FOREIGN KEY (license_id) REFERENCES pilot_licenses(id)
)

GO

CREATE TABLE aircraft_models (
id int identity(1,1) primary key,
[name] varchar(50),
capacity int,
dimensions varchar(50),
[image] varchar(255)
)

GO

CREATE TABLE aircraft_types (
id int identity(1,1) primary key,
[name] varchar(50),
)

GO

CREATE TABLE aircrafts (
id int identity(1,1) primary key,
model_id int,
[type_id] int,
manufacture_date date,
available bit,
CONSTRAINT fk_model_id FOREIGN KEY (model_id) REFERENCES aircraft_models(id),
CONSTRAINT fk_type_id FOREIGN KEY ([type_id]) REFERENCES aircraft_types(id)
)

GO

CREATE TABLE flights (
id int identity(1,1) primary key,
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
id int identity(1,1) primary key,
flight_id int,
air_route_id int,
CONSTRAINT fk_flight_id FOREIGN KEY (flight_id) REFERENCES flights(id),
CONSTRAINT fk_air_route_id FOREIGN KEY (air_route_id) REFERENCES air_routes(id)
)

GO

-- Store Procedures

CREATE PROCEDURE sp_create_aircraft(
@model_name varchar(50), 
@model_image varchar(255),
@type_name varchar(50), 
@model_capacity int,
@model_dimensions varchar(50)
) AS 
BEGIN 
	DECLARE @model_id int, @type_id int 
	INSERT INTO aircraft_models ([name], capacity, dimensions, [image]) VALUES (@model_name, @model_capacity, @model_dimensions, @model_image) 
	SET @model_id = @@IDENTITY 
	INSERT INTO aircraft_types ([name]) VALUES (@type_name) 
	SET @type_id = @@IDENTITY 
	INSERT INTO aircrafts (model_id, [type_id]) VALUES (@model_id, @type_id) 
END

GO

CREATE PROCEDURE sp_create_flight(
@aircraft_id int,
@depart_from_id int,
@arrive_at_id int,
@duration int,
@pilot_id int,
@co_pilot_id int,
@depart_date varchar,
@arrive_date varchar
) AS 
BEGIN 
	INSERT INTO flights (
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
		@aircraft_id,
		@depart_from_id,
		@arrive_at_id,
		@duration,
		@pilot_id,
		@co_pilot_id,
		@depart_date,
		@arrive_date,
		0
	) 
END

GO

CREATE PROCEDURE sp_search_aircraft(
	@model_id int, 
	@type_id int, 
	@manufacture_date varchar, 
	@available bit
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
@aircraft_model_id int,
@aircraft_type_id int,
@depart_from_id int,
@arrive_at_id int,
@duration int,
@pilot_name varchar,
@co_pilot_name varchar,
@depart_date varchar,
@arrive_date varchar,
@in_route int
) AS 
BEGIN 
	DECLARE @where varchar, @query varchar 
	IF(@aircraft_model_id != -1) 
		SET @where = CONCAT(' ', 'model_id = ', @aircraft_model_id , ' ') 
	IF(@aircraft_type_id != -1) 
		SET @where = CONCAT('type_id = ', @aircraft_type_id , ' ') 
	IF(@depart_from_id != -1)  
		SET @where = CONCAT('depart_from_id = ', @depart_from_id , ' ') 
	IF(@arrive_at_id != -1)  
		SET @where = CONCAT('arrive_at_id = ', @arrive_at_id , ' ') 
	IF(@duration != -1)  
		SET @where = CONCAT('duration = ', @duration , ' ') 
	IF(@pilot_name != NULL)  
		SET @where = CONCAT('pilots.name = ', @pilot_name , ' ') 
	IF(@co_pilot_name != NULL)  
		SET @where = CONCAT('pilots.name = ', @co_pilot_name , ' ') 
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
@name varchar(50),
@license_id int,
@gender bit,
@birth_date varchar
) AS 
BEGIN 
 INSERT INTO pilots (
	name,
	license_id,
	gender,
	birth_date
 ) VALUES (
	@name,
	@license_id,
	@gender,
	@birth_date
 )
END 

GO

CREATE PROCEDURE sp_search_pilot (
@name varchar(50),
@license_id int,
@gender bit,
@birth_date varchar
) AS 
BEGIN 
	DECLARE @where varchar, @query varchar 
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

CREATE PROCEDURE sp_delete_flights_by_id(@flight_id int) AS 
BEGIN 
	DELETE FROM flights where id = @flight_id 
END

GO

CREATE PROCEDURE sp_delete_pilots_by_id(@pilot_id int) AS 
BEGIN 
	DELETE FROM pilots where id = @pilot_id 
END

GO

CREATE PROCEDURE sp_delete_aircrafts_by_id(@aircraft_id int) AS 
BEGIN 
	DELETE FROM aircrafts where id = @aircraft_id 
END

GO

-- Triggers
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