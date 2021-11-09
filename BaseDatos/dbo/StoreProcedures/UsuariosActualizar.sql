CREATE PROCEDURE [dbo].[UsuariosActualizar]
    @UsuarioId INT,
	@Usuario VARCHAR (250),
	@Nombre VARCHAR (500) , 
	@RolesId INT, 
	@Contrasena VARBINARY (max),
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	BEGIN
		
	UPDATE dbo.Usuarios SET
	      
		  Usuario =@Usuario,
		  Nombre=@Nombre,
		  RolesId=@RolesId,
		  Contrasena=@Contrasena,
		  Estado=@Estado

	WHERE UsuariosId=@UsuarioId

	SELECT 0 AS CodeError, '' AS MsgError

		END

		COMMIT TRANSACTION TRASA



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END