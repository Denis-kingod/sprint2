USE inLock_games;
GO

INSERT INTO tiposDeUsuarios(titulo)
VALUES					('Administrador')
					   ,('Cliente');
GO

INSERT INTO Usuarios(email, senha, idTipoUsuario)
VALUES				('admin@admin.com','admin',1)
				   ,('cliente@cliente.com','cliente',2);
GO

INSERT INTO Estudios(nomeEstudio)
VALUES				('Blizzard')
				   ,('Rockstar Studios')
				   ,('Square Enix');
GO

INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, Valor, idEstudio)
VALUES			 ('Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�','2012-05-15','99.00',1);
				
GO

SELECT * FROM TiposDeUsuarios;
SELECT * FROM Usuarios;
SELECT * FROM Estudios;
SELECT * FROM Jogos;