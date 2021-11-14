CREATE PROCEDURE [dbo].[UsuariosObtener]
	@UsuariosId INT = NULL
	
AS
	BEGIN 

	SET NOCOUNT ON 
	
	SELECT 
		 A.UsuariosId
		,A.Usuario
		,A.Nombre
		,A.Estado
		,B.RolesId
		,B.NombreRol

	FROM dbo.Usuarios A
	 LEFT JOIN dbo.Roles B
         ON A.RolesId = B.RolesId
	WHERE (@UsuariosId IS NULL OR UsuariosId = @UsuariosId)


	END 