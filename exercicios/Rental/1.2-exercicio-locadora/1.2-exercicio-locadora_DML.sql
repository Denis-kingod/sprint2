USE LOCADORA;
GO

INSERT INTO EMPRESA (NomeEmpresa)
VALUES ('SÓ NAVE DA NASA');
GO

INSERT INTO Cliente (NomeCliente, CPF)
VALUES ('Denis', '09128347561'), ('Jubileuson', '65748392010');
GO

INSERT INTO MARCA (NomeMarca)
VALUES ('FERRARI'),('SKYLINE'),
       ('LAMBORGHINI'),('JAGUAR');
GO

INSERT INTO MODELO (NomeModelo, IdMarca, AnoLancamento)
VALUES ('488', 1, '2021'),('GTR R34', 1,'2021'),
       ('VENENO', 2,'2021'),('FTYPE', 2,'2021');
GO

INSERT INTO Veiculo (IdEmpresa, IdModelo, CorVeiculo)
VALUES (1, 1, 'dourado'), (1,1, 'Preto'), (1, 2, 'bronze'),(1, 2, 'Azul');
GO

SELECT * FROM Veiculo;
GO

INSERT INTO Aluguel (IdVeiculo, IdCliente, Data1)
VALUES (6, 1, '21-08-2021'), (3, 1, '21-08-2021'), (4, 2, '21-08-2021'),(5, 2, '21-08-2021');
GO