CREATE PROCEDURE [dbo].[PaginasObtenerRol]
	@RolesId int,
	@Estado bit
AS BEGIN
	SET NOCOUNT ON
	IF (@Estado=0)
	BEGIN
		SELECT [PermisoId]
			  ,rol.[RolesId]
			  ,per.[PaginasId]
			  ,pag.DescPagina
			  ,pag.NombrePagina
		FROM [dbo].[Permisos] per
		INNER JOIN [dbo].[Paginas] pag ON per.PaginasId = pag.PaginasId 
		INNER JOIN [dbo].[Roles] rol ON rol.RolesId = per.RolesId
		WHERE per.RolesId = @RolesId
	END
	ELSE
	BEGIN
		SELECT [PermisoId]
			  ,rol.[RolesId]
			  ,per.[PaginasId]
			  ,pag.DescPagina
			  ,pag.NombrePagina
		FROM [dbo].[Permisos] per
		INNER JOIN [dbo].[Paginas] pag ON per.PaginasId = pag.PaginasId 
		INNER JOIN [dbo].[Roles] rol ON rol.RolesId = per.RolesId
		WHERE per.RolesId = @RolesId
		AND rol.Estado = 1
	END
END