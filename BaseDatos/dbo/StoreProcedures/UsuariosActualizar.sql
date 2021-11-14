CREATE PROCEDURE [dbo].[UsuariosActualizar]
    @UsuariosId INT,
	@Usuario VARCHAR (250),
	@Nombre VARCHAR (500) , 
	@RolesId INT, 
	@Contrasena VARCHAR(250),
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	BEGIN

		IF @Contrasena = NULL BEGIN

			UPDATE dbo.Usuarios SET
	      
				  Usuario =@Usuario,
				  Nombre=@Nombre,
				  RolesId=@RolesId,
				  Estado=@Estado

			WHERE UsuariosId=@UsuariosId

			SELECT 0 AS CodeError, '' AS MsgError

		END
		ELSE BEGIN 
			DECLARE @ContrasenaSHA1 VARBINARY(MAX)=(SELECT HASHBYTES('SHA1',@Contrasena));

			UPDATE dbo.Usuarios SET
	      
				  Usuario =@Usuario,
				  Nombre=@Nombre,
				  RolesId=@RolesId,
				  Contrasena=@ContrasenaSHA1,
				  Estado=@Estado

			WHERE UsuariosId=@UsuariosId

			SELECT 0 AS CodeError, '' AS MsgError
		END	


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