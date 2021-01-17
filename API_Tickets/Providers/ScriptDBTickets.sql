CREATE DATABASE Tickets
GO
USE Tickets
GO
CREATE TABLE tickets(
	Usuario VARCHAR(MAX),
	FechaCreacion DATETIME,
	FechaActualizacion DATETIME,
	Status VARCHAR(10),
	IdTicket INT PRIMARY KEY IDENTITY(1,1)
)