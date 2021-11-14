CREATE PROCEDURE [dbo].[RolesInsertar]
	@NombreRol VARCHAR(250),
	@Descripcion varchar(250),
    @Estado BIT
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		
		INSERT INTO dbo.Roles 
		(	       
	      NombreRol,
		  Descripcion,
		  Estado
		)
		VALUES
		(
		
	      @NombreRol,
		  @Descripcion,
		  @Estado
		)


		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError, @@IDENTITY AS RegisterId


	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError
			,   0 AS RegisterId

			ROLLBACK TRANSACTION TRASA
	END CATCH

END