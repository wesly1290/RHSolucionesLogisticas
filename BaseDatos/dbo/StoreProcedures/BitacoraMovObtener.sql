CREATE PROCEDURE [dbo].[BitacoraMovObtener]
AS BEGIN
	SET NOCOUNT ON

	SELECT  [UsuarioMovimientoId]
		  ,MB.[UsuariosId]
		  ,[FechaMovimiento]
		  ,[DescripcionMovimiento]
		  ,U.Usuario
	  FROM [dbo].[MovimientosBitacora] MB
	 INNER JOIN dbo.Usuarios U
         ON MB.UsuariosId = U.UsuariosId

END