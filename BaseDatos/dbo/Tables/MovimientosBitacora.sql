CREATE TABLE [dbo].[MovimientosBitacora]
(
	  UsuarioMovimientoId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Movimientos PRIMARY KEY CLUSTERED(UsuarioMovimientoId)
	, UsuariosId INT NULL CONSTRAINT FK_Movimiento_Usuario FOREIGN KEY(UsuariosId) REFERENCES dbo.Usuarios(UsuariosId)
	, FechaMovimiento DATETIME NULL, 
    [DescripcionMovimiento] NVARCHAR(250) NULL
)
