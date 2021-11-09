CREATE PROCEDURE [dbo].[RolesLista]
AS
	BEGIN
	SET NOCOUNT ON


	SELECT
	RolesId,
	 NombreRol
	FROM Roles
	
	END