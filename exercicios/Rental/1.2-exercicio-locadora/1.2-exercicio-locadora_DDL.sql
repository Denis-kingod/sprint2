CREATE DATABASE LOCADORA;
GO

USE LOCADORA;
GO

CREATE TABLE Empresa(
idEmpresa INT PRIMARY KEY IDENTITY(1,1),
NomeEmpresa VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Marca(
IdMarca INT PRIMARY KEY IDENTITY(1,1),
NomeMarca VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Modelo(
idModelo INT PRIMARY KEY IDENTITY(1,1),
idMarca INT FOREIGN KEY REFERENCES Marca(idMarca)
);
GO

ALTER TABLE Modelo ADD NomeModelo VARCHAR(50);
GO

ALTER TABLE Modelo ADD AnoLancamento DATE;
GO

CREATE TABLE Veiculo(
idVeiculo INT PRIMARY KEY IDENTITY(1,1),
idEmpresa INT FOREIGN KEY REFERENCES Empresa(IdEmpresa),
idModelo INT FOREIGN KEY REFERENCES Modelo(IdModelo),
CorVeiculo VARCHAR(50) NOT NULL UNIQUE
);
GO

SELECT * FROM Veiculo;
GO


CREATE TABLE Cliente(
idCliente INT PRIMARY KEY IDENTITY(1,1),
NomeCliente VARCHAR(50) NOT NULL,
CPF CHAR(13) NOT NULL UNIQUE
);
GO

CREATE TABLE Aluguel(
idAluguel INT PRIMARY KEY IDENTITY(1,1),
idVeiculo INT FOREIGN KEY REFERENCES Veiculo(idVeiculo),
idCliente INT FOREIGN KEY REFERENCES Cliente(idCliente),
Data1 DATE
);
GO