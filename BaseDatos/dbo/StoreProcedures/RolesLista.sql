CREATE PROCEDURE [dbo].[RolesLista]
	@RolesId INT= null
AS
	BEGIN
	SET NOCOUNT ON


	SELECT
	RolesId,
	 NombreRol,
	 Descripcion,
	 Estado
	FROM Roles
	WHERE  (@RolesId IS NULL OR RolesId=@RolesId)
	
	END