USE master
IF EXISTS(select * from sys.databases where name='BD_DijoSI')
DROP DATABASE BD_DijoSI

CREATE DATABASE BD_DijoSI
GO

USE BD_DijoSI
GO

SET DATEFORMAT dmy;
GO  

CREATE TABLE tb_usuario
(
	idUsuario		VARCHAR(12) NOT NULL,
	dniUsuario		CHAR(8) NOT NULL,
	nomUsuario		VARCHAR(100) NOT NULL,
	apePatUsuario	VARCHAR(100) NOT NULL,
	apeMatUsuario	VARCHAR(100) NOT NULL,
	telfUsuario		CHAR(30) NOT NULL,
	dirUsuario		VARCHAR(200) NOT NULL,
	emailUsuario	VARCHAR(100) NOT NULL,
	loginUsuario	VARCHAR(100) NOT NULL,
	passUsuario		VARCHAR(50) NOT NULL,
	verificaEmail   BIT NOT NULL,
	Codigo			UNIQUEIDENTIFIER NOT NULL,
	Reiniciarcontra VARCHAR(100) 
	PRIMARY KEY(idUsuario)
)
GO
	
CREATE TABLE tb_distrito
(
	idDistrito  VARCHAR(12) PRIMARY KEY,
	nomDistrito VARCHAR(100) 
)
GO

INSERT INTO tb_distrito VALUES('DIS01','Magdalena')
INSERT INTO tb_distrito VALUES('DIS02','Miraflores')
INSERT INTO tb_distrito VALUES('DIS03','San Miguel')
INSERT INTO tb_distrito VALUES('DIS04','San Isidro')
GO

CREATE TABLE tb_local
(
	idLocal    VARCHAR(12) PRIMARY KEY,
	nomLocal   VARCHAR(100)NOT NULL,
	dirLocal   VARCHAR(100) NOT NULL,
	telfLocal  VARCHAR(30) NOT NULL,
	foto       VARCHAR(3999) NOT NULL,
	cantLocal  INT,
	idDistrito VARCHAR(12) REFERENCES tb_distrito
)
GO

CREATE TABLE tb_admin
(
	idAdmin     VARCHAR(12),
	emailAdmin	VARCHAR(100) NOT NULL,
	loginAdmin	VARCHAR(100) NOT NULL,
	passAdmin	VARCHAR(50) NOT NULL,
)
GO

CREATE TABLE tb_fotografo
(
	idFotografo    VARCHAR(12) PRIMARY KEY,
	nomFotografo   VARCHAR(100) NOT NULL,
	dirFotografo   VARCHAR(250) NOT NULL,
	foto           VARCHAR(3999) NOT NULL,
	telfFotografo  CHAR(30) NOT NULL
)
GO

CREATE TABLE tb_categoria
(
	idCategoria  VARCHAR(12) PRIMARY KEY,
	nomCategoria VARCHAR(100) 
)
GO

INSERT INTO tb_categoria VALUES('CAT01','Mexicana')
INSERT INTO tb_categoria VALUES('CAT02','Peruana')
INSERT INTO tb_categoria VALUES('CAT03','Italiana')
INSERT INTO tb_categoria VALUES('CAT04','Oriental')
GO

CREATE TABLE tb_buffet
(
	idBuffet       VARCHAR(12) PRIMARY KEY,
	nomprovBuffet  VARCHAR(500),
	nomBuffet      VARCHAR(100) NOT NULL,
	desBuffet      VARCHAR(500) NOT NULL,
	preBuffet      DECIMAL NOT NULL,
	foto           VARCHAR(3999) NOT NULL,
	idCategoria    VARCHAR(12) REFERENCES tb_categoria
)
GO

CREATE TABLE tb_tipoRegalo
(
	idTipo  VARCHAR(12) PRIMARY KEY NOT NULL,
	desTipo VARCHAR(60) NOT NULL
)
GO

INSERT INTO tb_tipoRegalo VALUES('TR001','Utencilios de Cocina')
INSERT INTO tb_tipoRegalo VALUES('TR002','Linea Blanca')
INSERT INTO tb_tipoRegalo VALUES('TR003','Electrodomesticos')
INSERT INTO tb_tipoRegalo VALUES('TR004','Tecnologia')
GO

CREATE TABLE tb_regalo
(
	idRegalo	 VARCHAR(12),
	nombreRegalo VARCHAR(60),
	foto         VARCHAR(3999),
	idTipo		 VARCHAR(12) REFERENCES tb_tipoRegalo
)
GO

CREATE TABLE tb_invitados
(
	idInvitado		VARCHAR(12) NOT NULL,
	nomInvitado		VARCHAR(100) NOT NULL,
	apePatInvitado	VARCHAR(100) NOT NULL,
	apeMatInvitado	VARCHAR(100) NOT NULL,
	emailInvitado	VARCHAR(100) NOT NULL,
	idUsuario       VARCHAR(12) NOT NULL REFERENCES tb_usuario
)
GO

CREATE TABLE tb_reserva
(
	idReserva      VARCHAR(12) PRIMARY KEY,
	idLocal        VARCHAR(12) NOT NULL,
	idBuffet       VARCHAR(12) NOT NULL,
	idFotografo    VARCHAR(12) NULL,
	estado         BIT,
	fechaSolicitud DATE,
)
GO

CREATE TABLE tb_detalleReserva
(
	idReserva VARCHAR(12),
	idUsuario VARCHAR(12) REFERENCES tb_usuario NOT NULL
)
GO

CREATE TABLE tb_horario
(
	idLocal VARCHAR(12) REFERENCES tb_local,
	iniHorario DATE,
	mainHorario DATE,
	finHorario DATE
)
GO

CREATE TABLE tb_Agenda_Fotografo
(
	idFotografo VARCHAR(12) REFERENCES tb_fotografo NOT NULL,
	diaReservado DATE NOT NULL
)
GO

CREATE TABLE tb_carritoRegalo
(
	idRegalo  INT PRIMARY KEY,
	idUsuario VARCHAR(12) REFERENCES tb_usuario
)
GO

--PROCEDIMIENTOS ALMACENADOS
--DISTRITOS
CREATE PROC usp_ListarDistritos
AS
	SELECT idDistrito, 
		   nomDistrito 
	  FROM tb_distrito 
GO

--CATEGORIAS
CREATE PROC usp_ListarCategorias
AS
	SELECT idCategoria,
		   nomCategoria
	  FROM tb_categoria
GO

--TIPO DE REGALOS
CREATE PROC usp_ListarTipoRegalos
AS
	SELECT idTipo,
		   desTipo
      FROM tb_tipoRegalo
GO

--USUARIOS
CREATE PROC usp_ListarUsuarios
AS
	SELECT idUsuario,	
		   nomUsuario,
	       apePatUsuario,	 
		   apeMatUsuario,
		   dniUsuario,		 
		   telfUsuario,	
		   dirUsuario,	
		   emailUsuario,
		   loginUsuario,
		   Codigo
	  FROM tb_usuario
GO

CREATE PROC usp_Login
@login VARCHAR(200),
@pass  VARCHAR(200)
AS
	SELECT idUsuario,
		   nomUsuario,
		   loginUsuario,
		   passUsuario,
		   verificaEmail
	  FROM tb_usuario
	 WHERE loginUsuario = @login
	   AND passUsuario = @pass
GO

CREATE PROC usp_RegistrarUsuarios	
@dniUsuario		  CHAR(8),
@nomUsuario		  VARCHAR(100),
@apePatUsuario	  VARCHAR(100), 
@apeMatUsuario	  VARCHAR(100), 
@telfUsuario	  CHAR(30), 
@dirUsuario		  VARCHAR(200),
@emailUsuario	  VARCHAR(100), 
@loginUsuario	  VARCHAR(100),
@passUsuario	  VARCHAR(50),
@verificaEmail    BIT ,
@Codigo			  UNIQUEIDENTIFIER 
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idUsuario) FROM tb_usuario
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'U001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idUsuario),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idUsuario),3)+1),3) 
				FROM tb_usuario
			END
	INSERT INTO tb_usuario VALUES(@id, @dniUsuario, @nomUsuario, @apePatUsuario, @apeMatUsuario, @telfUsuario, @dirUsuario, @emailUsuario, @loginUsuario, @passUsuario, @verificaEmail, @Codigo,null)
	END
GO

CREATE PROC usp_ActivarUsuarios
@verificaEmail    BIT ,
@id               VARCHAR(12)
AS
	UPDATE tb_usuario
	   SET verificaEmail = @verificaEmail
	 WHERE idUsuario = @id
GO

CREATE PROC usp_EliminarUsuarios 
@id VARCHAR(12)
AS
	DELETE FROM tb_usuario WHERE idUsuario = @id
GO

--SERVICIOS
--1 BUFFETS
CREATE PROC usp_ListarBuffets
AS
	SELECT idBuffet,
		   nomprovBuffet, 
		   nomBuffet ,
		   desBuffet ,
		   preBuffet ,
		   foto,
		   c.idCategoria,
		   c.nomCategoria   
     FROM tb_buffet buff 
     JOIN tb_categoria c
	   ON buff.idCategoria = c.idCategoria
GO

CREATE PROC usp_RegistrarBuffets
@nomprovBuffet VARCHAR(100),
@nomBuffet     VARCHAR(100),
@desBuffet     VARCHAR(100),
@preBuffet     DECIMAL,
@idCategoria   VARCHAR(12),
@foto          VARCHAR(3999)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idBuffet) FROM tb_buffet
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'B001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idBuffet),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idBuffet),3)+1),3) 
				FROM tb_buffet
			END
	INSERT INTO tb_buffet VALUES(@id, @nomprovBuffet, @nomBuffet, @desBuffet, @preBuffet,@foto, @idCategoria)
	END
GO

CREATE PROC usp_ActualizarBuffets
@idBuffet      VARCHAR(12),
@preBuffet     DECIMAL
AS
	UPDATE tb_buffet 
	   SET preBuffet = @preBuffet   
	 WHERE idBuffet  = @idBuffet  
GO

CREATE PROC usp_EliminarBuffets
@idBuffet VARCHAR(12)
AS
	DELETE FROM tb_buffet WHERE idBuffet = @idBuffet
GO

--2 LOCALES
CREATE PROC usp_ListarLocales
AS
	SELECT idLocal, 
		   nomLocal, 
		   dirLocal, 
		   telfLocal,
		   cantLocal,
		   foto,
		   d.idDistrito,
		   d.nomDistrito
      FROM tb_local l 
	  JOIN tb_distrito d 
	    ON l.idDistrito = d.idDistrito
GO

CREATE PROC usp_RegistrarLocales
@nom   VARCHAR(100),
@dir   VARCHAR(100),
@fono  VARCHAR(30),
@cant  INT,
@iddis VARCHAR(12),
@foto  VARCHAR(3999)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idLocal) FROM tb_local
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'L001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idLocal),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idLocal),3)+1),3) 
				FROM tb_local
			END
	INSERT INTO tb_local VALUES(@id, @nom, @dir, @fono, @foto, @cant, @iddis)
	END
GO

CREATE PROC usp_ActualizarLocales
@id    VARCHAR(12),
@nom   VARCHAR(100),
@dir   VARCHAR(100),
@fONo  VARCHAR(30),
@cant   INT,
@iddis VARCHAR(12),
@foto  VARCHAR(3999)
AS
	UPDATE tb_local 
	   SET nomLocal   = @nom, 
	       dirLocal   = @dir, 
		   telfLocal  = @fONo,
		   cantLocal  = @cant,
		   idDistrito = @iddis,
		   foto       = @foto
     WHERE idLocal    = @id
GO

CREATE PROC usp_EliminarLocales
@id VARCHAR(12)
AS
	DELETE FROM tb_local WHERE idLocal = @id
GO

--3 REGALOS
CREATE PROC usp_ListarRegalos
AS
	SELECT idRegalo,
		   r.nombreRegalo,
		   foto,
		   tr.idTipo,
		   tr.desTipo
	  FROM tb_regalo r
	  JOIN tb_tipoRegalo tr
	    ON r.idTipo = tr.idTipo
GO

CREATE PROC usp_RegistrarRegalos
@desRegalo  VARCHAR(100),
@foto       VARCHAR(3999),
@idtipo     VARCHAR(12)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idRegalo) FROM tb_regalo
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'R001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idRegalo),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idRegalo),3)+1),3) 
				FROM tb_regalo
			END
	INSERT INTO tb_regalo VALUES(@id, @desRegalo, @foto, @idtipo)
	END
GO

--4 FOTOGRAFOS
CREATE PROC usp_ListarFotografos
AS
	SELECT idFotografo,
		   nomFotografo,
		   telfFotografo,
		   dirFotografo,
		   foto
	  FROM tb_fotografo
GO

CREATE PROC usp_RegistrarFotografo
@NomFotografo  VARCHAR(100),
@telfFotografo CHAR(30),
@dirFotografo  VARCHAR(250),
@foto          VARCHAR(3999)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idFotografo) FROM tb_fotografo
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'F001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idFotografo),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idFotografo),3)+1),3) 
				FROM tb_fotografo
			END
	INSERT INTO tb_fotografo VALUES(@id, @NomFotografo, @dirFotografo, @foto, @telfFotografo)
	END
GO

CREATE PROC usp_ActualizarFotografo
@idFotografo   VARCHAR(12),
@telfFotografo CHAR(12),
@dirFotografo  VARCHAR(250),
@foto          VARCHAR(3999)
AS
	UPDATE tb_fotografo
	   SET telfFotografo = @telfFotografo,
	       dirFotografo  = @dirFotografo,
		   foto          = @foto
	 WHERE idFotografo   = @idFotografo
GO

CREATE PROC usp_EliminarFotografo
@idFotografo   VARCHAR(12)
AS
	DELETE FROM tb_fotografo WHERE idFotografo = @idFotografo
GO

--INVITADOS
CREATE PROC usp_ListarInvitados
AS
	SELECT idInvitado,
	       nomInvitado,
		   apePatInvitado,
		   apeMatInvitado,
		   usu.idUsuario,
		   usu.nomUsuario,
		   usu.apePatUsuario,
		   usu.apeMatUsuario
	  FROM tb_invitados invi
	  JOIN tb_usuario usu
	    ON invi.idUsuario = usu.idUsuario
GO

CREATE PROC usp_RegistrarInvitados
@nomInvitado	 VARCHAR(100),
@apePatInvitado  VARCHAR(100),
@apeMatInvitado  VARCHAR(100),
@emailInvitado	 VARCHAR(100),
@idUsuario        VARCHAR(12)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idInvitado) FROM tb_invitados
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'I001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idInvitado),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idInvitado),3)+1),3) 
				FROM tb_invitados
			END
	INSERT INTO tb_invitados VALUES(@id, @nomInvitado, @apePatInvitado, @apeMatInvitado, @emailInvitado, @idUsuario)
	END
GO

CREATE PROC usp_ActualizarInvitados
@idInvitado      VARCHAR(12) ,
@nomInvitado	 VARCHAR(100),
@apePatInvitado  VARCHAR(100),
@apeMatInvitado  VARCHAR(100),
@emailInvitado	 VARCHAR(100)
AS
	UPDATE tb_invitados
	   SET nomInvitado    = @nomInvitado,
	       apePatInvitado = @apePatInvitado,
		   apeMatInvitado = @apeMatInvitado,
		   emailInvitado  = @emailInvitado
     WHERE idInvitado     = @idInvitado
GO

CREATE PROC usp_EliminarInvitados
@idInvitado      VARCHAR(12)
AS
	DELETE FROM tb_invitados WHERE idInvitado = @idInvitado
GO

-- RESERVA
CREATE PROC usp_RegistrarReserva
@id          VARCHAR(12),
@idLocal	 VARCHAR(12),
@idBuffet    VARCHAR(12),
@selecciona  BIT,
@estado      BIT,
@fecha       DATE
AS
	BEGIN
	DECLARE @idfotografo VARCHAR(12)
	IF(@selecciona = 1)
		BEGIN
			SELECT TOP 1 @idfotografo =  f.idFotografo FROM tb_fotografo f LEFT JOIN tb_Agenda_Fotografo af ON f.idFotografo = af.idFotografo WHERE af.diaReservado <> @fecha
		                                 OR af.diaReservado IS NULL
			INSERT INTO tb_Agenda_Fotografo VALUES (@idFotografo, @fecha)
		END
	ELSE
		BEGIN
			SELECT @idfotografo = NULL
		END
	INSERT INTO tb_reserva (idReserva, idLocal, idBuffet, idFotografo, estado , fechaSolicitud) 
	     VALUES (@id, @idLocal, @idBuffet, @idfotografo, @estado, @fecha)
	END
GO

CREATE PROC usp_DetalleReserva
@id    VARCHAR(12),
@idUsu VARCHAR(12)
AS
	BEGIN
	INSERT INTO tb_detalleReserva (idUsuario, idReserva)
		VALUES (@idUsu,@id)
	END
GO

CREATE PROC usp_RegistrarReservaLocal
@idLocal VARCHAR(12),
@fechaReserva DATE
AS
	BEGIN
	    DECLARE @fechaInicio DATE
		DECLARE @fechaFin DATE
		DECLARE @idFotografo VARCHAR(12)
		SELECT @fechaInicio = dbo.usp_calcular_fecha_inicio(@fechaReserva)
		SELECT @fechaFin = dbo.usp_calcular_fecha_fin(@fechaReserva)
	INSERT INTO tb_horario (idLocal , iniHorario , mainHorario ,finHorario)
		VALUES(@idLocal, @fechaInicio, @fechaReserva ,@fechaFin)
	END
GO

CREATE PROC usp_CancelarReserva
@id          VARCHAR(12)
AS 
	BEGIN
		DELETE
		  FROM tb_reserva 
		 WHERE idReserva = @id
	END
GO

CREATE PROC usp_EliminarDetalle
@id          VARCHAR(12)
AS
	BEGIN
		DELETE
		  FROM tb_detalleReserva
		 WHERE idReserva = @id
	END
GO

CREATE PROC usp_EliminarHorarios
@idLocal VARCHAR(12),
@fecha  DATE
AS
	BEGIN
		DELETE
		  FROM tb_horario
		 WHERE idLocal = @idLocal
		   AND mainHorario = @fecha
	END
GO

CREATE PROC usp_EliminarAgenda
@idFotografo VARCHAR(12),
@fecha DATE
AS
	BEGIN
		DELETE
		  FROM tb_Agenda_Fotografo
		 WHERE idFotografo = @idFotografo
		   AND diaReservado = @fecha
	END
GO

--FUNCIONES
CREATE FUNCTION usp_calcular_fecha_inicio(@fecini DATE)
RETURNS DATE
AS
BEGIN
	RETURN (select DATEADD(DAY,-1, @fecini))
END
GO

CREATE FUNCTION usp_calcular_fecha_fin (@fecfin DATE)
RETURNS DATE
AS
BEGIN
	RETURN (select DATEADD(DAY,+2, @fecfin))
END
GO

CREATE PROC usp_ListarFotografosDisponibles
@fecha DATE
AS
	BEGIN
		SELECT f.idFotografo 
		  FROM tb_fotografo f
	 LEFT JOIN tb_Agenda_Fotografo af 
	    	ON f.idFotografo = af.idFotografo
		WHERE af.diaReservado <> @fecha
		OR af.diaReservado IS NULL
	END
GO

CREATE PROC usp_GenerarCodigo
AS	
	BEGIN
		SELECT LEFT(MAX(idReserva),2)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idReserva),3)+1),3) 'CODIGO' 
				FROM tb_reserva
	END
GO

CREATE PROC usp_ElegirRegalo
@usuario VARCHAR(12),
@regalo  VARCHAR(12)
AS
	BEGIN
		INSERT INTO tb_carritoRegalo(idUsuario,idRegalo)
		     VALUES (@usuario,@regalo)
	END
GO






