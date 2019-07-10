USE [master];
GO

CREATE DATABASE [WebServiceIntro];
GO

USE [WebServiceIntro];
GO

CREATE TABLE [Empleado] (
	[ID] int identity,
	[NOMBRE] nvarchar(50),
	[APELLIDO] nvarchar(50),
	[EMAIL] nvarchar(50),
	[TELEFONO] nvarchar(50),
	PRIMARY KEY ([ID])	
);
GO

USE [WebServiceIntro];
GO

INSERT INTO [Empleado] ([NOMBRE], [APELLIDO], [EMAIL], [TELEFONO]) VALUES ('German', 'Alvarez', 'g.alvarez@hardata.com', '1164641457');
GO

INSERT INTO [Empleado] ([NOMBRE], [APELLIDO], [EMAIL], [TELEFONO]) VALUES ('Pablo', 'Teruel', 'p.teruel@hardata.com', '1165198535');
GO

INSERT INTO [Empleado] ([NOMBRE], [APELLIDO], [EMAIL], [TELEFONO]) VALUES ('Martin', 'da Veiga', 'm.daveiga@hardata.com', '1140817475');
GO

INSERT INTO [Empleado] ([NOMBRE], [APELLIDO], [EMAIL], [TELEFONO]) VALUES ('Ariel', 'Martino', 'a.martino@hardata.com', '1159299930');
GO

INSERT INTO [Empleado] ([NOMBRE], [APELLIDO], [EMAIL], [TELEFONO]) VALUES ('Gustavo', 'Pesci', 'g.pesci@hardata.com', '1141756164');
GO