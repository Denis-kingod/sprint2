USE inLock_games;
GO

SELECT U.idUsuario, U.email, U.idTipoUsuario, TU.titulo FROM Usuarios U
INNER JOIN TiposDeUsuarios TU
ON U.idTipoUsuario = TU.idTipoUsuario;
GO

SELECT idEstudio, nomeEstudio FROM ESTUDIOS; 


SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM JOGOS;


SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM JOGOS J
INNER JOIN ESTUDIOS E
ON J.idEstudio = E.idEstudio;
GO


SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor FROM ESTUDIOS E
LEFT JOIN JOGOS J
ON E.idEstudio = J.idEstudio;
GO


SELECT idUsuario, email, U.idTipoUsuario, TU.titulo FROM USUARIOS U
INNER JOIN TiposDeUsuarios TU
ON U.idTipoUsuario = TU.idTipoUsuario
WHERE email = 'denis@denis.com' AND senha = '1234';
GO


SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM JOGOS J
INNER JOIN ESTUDIOS E
ON J.idEstudio = E.idEstudio
WHERE J.idJogo = 1;
GO


SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor FROM ESTUDIOS E
INNER JOIN JOGOS J
ON E.idEstudio = J.idEstudio
WHERE E.idEstudio = 1;
GO