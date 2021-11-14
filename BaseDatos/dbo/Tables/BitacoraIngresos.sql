CREATE TABLE [dbo].[BitacoraIngresos]
(
	BitacoraId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Bitacora PRIMARY KEY CLUSTERED(BitacoraId)
  , UsuariosId INT NULL CONSTRAINT FK_Bitacora_Usuario FOREIGN KEY(UsuariosId) REFERENCES dbo.Usuarios(UsuariosId)
  , FechaIngreso DATETIME NULL
  , IngresoSalida NVARCHAR(10)
)WITH (DATA_COMPRESSION = PAGE)
GO
