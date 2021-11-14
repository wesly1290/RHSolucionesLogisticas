CREATE PROCEDURE [dbo].[BitacoraMovInsertar]
	@UsuariosId INT,
	@DescripcionMovimiento NVARCHAR(250)
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		

	INSERT INTO [dbo].[MovimientosBitacora]
			   ([UsuariosId]
			   ,[FechaMovimiento]
			   ,[DescripcionMovimiento])
			VALUES
				(@UsuariosId
				,GETDATE()
				,@DescripcionMovimiento)




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