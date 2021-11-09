CREATE TABLE [dbo].[Usuarios]
(
	  UsuariosId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED(UsuariosId)
	, Usuario VARCHAR(250) NULL
	, Nombre varchar(500) null
	, RolesId INT NULL CONSTRAINT FK_Usuarios_Roles FOREIGN KEY(RolesId) REFERENCES dbo.Roles(RolesId)
	, Contrasena VARBINARY(max) NULL
	, Estado BIT NULL
)
