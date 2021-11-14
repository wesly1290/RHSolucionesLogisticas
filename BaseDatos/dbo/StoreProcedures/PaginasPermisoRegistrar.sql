CREATE PROCEDURE [dbo].[PaginasPermisoRegistrar]
	@RolesId int,
	@PaginasId int,
    @Check BIT
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	IF (@Check=1)
	BEGIN
		IF (SELECT COUNT(1) FROM [dbo].[Permisos] WHERE RolesId=@RolesId AND PaginasId=@PaginasId)=0
		BEGIN
		INSERT INTO [dbo].[Permisos]
           ([RolesId]
           ,[PaginasId])
		VALUES
		(
		
			@RolesId,
			@PaginasId
		)
		END

	END
	ELSE
	BEGIN
		IF (SELECT COUNT(1) FROM [dbo].[Permisos] WHERE RolesId=@RolesId AND PaginasId=@PaginasId)>0
		BEGIN
			DELETE [dbo].[Permisos] WHERE RolesId=@RolesId AND PaginasId=@PaginasId
		END
	END
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