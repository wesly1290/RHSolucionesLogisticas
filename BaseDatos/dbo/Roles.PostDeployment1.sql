/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [RHSolucionesLogisticas]
GO
DECLARE @result as int; 
DECLARE @resultRole as int;
DECLARE @resultUser as int;
IF EXISTS (SELECT * FROM [dbo].[Usuarios] WHERE [Usuario] = 'Admin') 
BEGIN
   set @resultUser = (SELECT UsuariosId FROM [dbo].[Usuarios] WHERE [Usuario] = 'Admin')
END
ELSE
BEGIN
    
    INSERT [dbo].[Usuarios] ([Usuario], [Nombre], [RolesId], [Contrasena], [Estado]) VALUES ( N'Admin', N'Admin', 1, 0x8CB2237D0679CA88DB6464EAC60DA96345513964, 1)
    --12345
    set @resultUser = @@IDENTITY

END


IF EXISTS (SELECT * FROM [dbo].[Roles] WHERE [NombreRol] = 'Admin') 
BEGIN

   SET @resultRole =(SELECT RolesId FROM [dbo].[Roles] WHERE [NombreRol] = 'Admin')

END
ELSE
BEGIN
    
   INSERT [dbo].[Roles] ([NombreRol], [Descripcion], [Estado]) VALUES (N'Admin', N'Administrador', 1)
   set @resultRole = @@IDENTITY

END


DELETE FROM [dbo].[Permisos] WHERE [RolesId] = @resultRole

INSERT [dbo].[Permisos] ( [RolesId], [PaginasId]) VALUES (@resultRole, 1)
GO
INSERT [dbo].[Permisos] ( [RolesId], [PaginasId]) VALUES (@resultRole, 2)
GO
INSERT [dbo].[Permisos] ( [RolesId], [PaginasId]) VALUES (@resultRole, 3)
GO
INSERT [dbo].[Permisos] ( [RolesId], [PaginasId]) VALUES (@resultRole, 4)
GO
INSERT [dbo].[Permisos] ( [RolesId], [PaginasId]) VALUES (@resultRole, 5)
GO
INSERT [dbo].[Permisos] ( [RolesId], [PaginasId]) VALUES (@resultRole, 6)
GO
INSERT [dbo].[Permisos] ( [RolesId], [PaginasId]) VALUES (@resultRole, 7)