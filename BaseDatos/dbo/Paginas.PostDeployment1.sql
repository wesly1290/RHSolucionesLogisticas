/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------*/

USE [RHSolucionesLogisticas]
GO
IF EXISTS (SELECT * FROM [dbo].[Paginas] WHERE [PaginasId] in (1,2,3,4,5,6,7)) 
BEGIN
   SELECT 1 
END
ELSE
BEGIN
    SET IDENTITY_INSERT [dbo].[Paginas] ON 
    
    INSERT [dbo].[Paginas] ([PaginasId], [NombrePagina], [DescPagina]) VALUES (1, N'Customer', N'Clientes')
    
    INSERT [dbo].[Paginas] ([PaginasId], [NombrePagina], [DescPagina]) VALUES (2, N'Users', N'Usuarios')
    
    INSERT [dbo].[Paginas] ([PaginasId], [NombrePagina], [DescPagina]) VALUES (3, N'Invoice', N'Facturas')
    
    INSERT [dbo].[Paginas] ([PaginasId], [NombrePagina], [DescPagina]) VALUES (4, N'RoleMaintenance', N'Mantenimiento Roles')
    
    INSERT [dbo].[Paginas] ([PaginasId], [NombrePagina], [DescPagina]) VALUES (5, N'Reports', N'Reportes')
    
    INSERT [dbo].[Paginas] ([PaginasId], [NombrePagina], [DescPagina]) VALUES (6, N'UserLog', N'Log de usuario')
    
    INSERT [dbo].[Paginas] ([PaginasId], [NombrePagina], [DescPagina]) VALUES (7, N'MovementLog', N'Movimientos log')
    
    SET IDENTITY_INSERT [dbo].[Paginas] OFF

END
