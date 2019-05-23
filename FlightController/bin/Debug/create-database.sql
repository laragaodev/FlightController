--IF EXISTS(select * from sys.databases where name='aircraft_system_control')
--BEGIN
--	ALTER DATABASE aircraft_system_control SET SINGLE_USER WITH ROLLBACK IMMEDIATE
--	DROP DATABASE aircraft_system_control 
--END

--GO

CREATE DATABASE aircraft_system_control;