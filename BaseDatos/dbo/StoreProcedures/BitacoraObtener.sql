CREATE PROCEDURE [dbo].[BitacoraObtener]
AS BEGIN
	SET NOCOUNT ON

	SELECT  [BitacoraId]
		  ,B.[UsuariosId]
		  ,[FechaIngreso]
		  ,[IngresoSalida]
		  ,U.Usuario
	  FROM [dbo].[BitacoraIngresos] B
	 INNER JOIN dbo.Usuarios U
         ON B.UsuariosId = U.UsuariosId

END