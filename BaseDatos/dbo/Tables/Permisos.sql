CREATE TABLE [dbo].[Permisos]
(
	 PermisoId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Permisos PRIMARY KEY CLUSTERED([PaginasId], [RolesId], [PermisoId])
   , RolesId INT NOT NULL CONSTRAINT FK_Permisos_Roles FOREIGN KEY(RolesId) REFERENCES dbo.Roles(RolesId)
   , [PaginasId] INT NOT NULL CONSTRAINT FK_Permisos_Paginas FOREIGN KEY(PaginasId) REFERENCES dbo.Paginas(PaginasId)
   
)WITH (DATA_COMPRESSION = PAGE)
GO
