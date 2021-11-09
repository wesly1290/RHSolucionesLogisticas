﻿CREATE TABLE [dbo].[Roles]
(
	  RolesId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED(RolesId)
	, NombreRol VARCHAR(250) NULL
	, Descripcion VARCHAR (250)
)WITH (DATA_COMPRESSION = PAGE)
GO