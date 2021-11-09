CREATE PROCEDURE [dbo].[UsuariosObtener]
	@UsuariosId INT = NULL
	
AS
	BEGIN 

	SET NOCOUNT ON 
	
	SELECT 
		 A.UsuariosId
		,A.Usuario
		,A.Nombre
		,A.Contrasena
		,A.Estado
		,B.RolesId

	FROM dbo.Usuarios A
	 INNER JOIN dbo.Roles B
         ON A.RolesId = B.RolesId
	WHERE (@UsuariosId IS NULL OR UsuariosId = @UsuariosId)


	END 