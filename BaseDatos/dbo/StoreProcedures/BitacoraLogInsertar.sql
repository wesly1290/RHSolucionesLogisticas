CREATE PROCEDURE [dbo].[BitacoraLogInsertar]
	@UsuariosId INT,
	@IngresoSalida NVARCHAR(10)
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		

	INSERT INTO [dbo].[BitacoraIngresos]
				([UsuariosId]
				,[FechaIngreso]
				,[IngresoSalida])
			VALUES
				(@UsuariosId
				,GETDATE()
				,@IngresoSalida)




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