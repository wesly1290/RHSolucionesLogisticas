CREATE PROCEDURE dbo.RolesActualizar
	@RolesId INT,
	@NombreRol VARCHAR(250),
	@Descripcion varchar(250),
    @Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		
		UPDATE dbo.Roles
		   SET NombreRol = @NombreRol
			  ,Descripcion = @Descripcion
			  ,Estado = @Estado
		 WHERE RolesId = @RolesId


		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH
END