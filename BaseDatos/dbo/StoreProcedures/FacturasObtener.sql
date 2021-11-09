CREATE PROCEDURE [dbo].FacturasObtener
@IdFactura INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			A.IdFactura
		,	A.Pedido
		,	A.TipoServicio
		,   A.FechaPedido
		,   A.Monto
		,   A.Impuesto
		,   A.Total
		,   A.Observaciones
		,   A.Estado

		,   A.ClientesId
		,	C.NombreCompleto

		
				

	FROM dbo.Facturas A
	 INNER JOIN dbo.Clientes C
         ON A.ClientesId = C.ClientesId

	WHERE
	     (@IdFactura IS NULL OR A.IdFactura=@IdFactura)

END