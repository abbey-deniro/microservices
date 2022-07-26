CREATE DATABASE CatalogDB
GO

USE CatalogDB
GO

CREATE TABLE Items(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Title varchar(255),
	Description varchar(255),
	UnitPrice float
)
GO
-- SELECT * FROM Items
