CREATE PROCEDURE dbo.FacturasInsertar
	
	@ClientesId INT,
	@Pedido VARCHAR (1000) ,
	@TipoServicio VARCHAR (250) ,
	@FechaPedido DATETIME ,
    @Monto DECIMAL(18,2),
	@Impuesto DECIMAL(18,2),
	@Total DECIMAL(18,2),
	@Observaciones VARCHAR(1000),
	@Estado BIT
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	
	BEGIN

		INSERT INTO dbo.Facturas
		(	       
	      ClientesId,
		  Pedido,
		  TipoServicio,
		  FechaPedido,
		  Monto,
		  Impuesto,
		  Total,
		  Observaciones,
		  Estado
		)
		VALUES
		(
		
	      @ClientesId,
		  @Pedido,
		  @TipoServicio,
		  @FechaPedido,
		  @Monto,
		  @Impuesto,
		  @Total,
		  --((@Impuesto/100)*@Monto)+@Monto,
		  @Observaciones,
		  @Estado
		)
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