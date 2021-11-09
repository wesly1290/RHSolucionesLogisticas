CREATE TABLE [dbo].[Facturas]
(
	
	   IdFactura INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Factura PRIMARY KEY CLUSTERED(IdFactura)
	 , ClientesId INT NULL CONSTRAINT FK_Factura_Cliente FOREIGN KEY(ClientesId) REFERENCES dbo.Clientes(ClientesId)
	 , Pedido VARCHAR(1000) NULL
	 , TipoServicio VARCHAR(250) NULL
	 , FechaPedido DATETIME NULL
	 , Monto DECIMAL(18,2) NULL
	 , Impuesto DECIMAL(18,2) NULL
	 , Total DECIMAL(18,2) NULL
	 , Observaciones VARCHAR(1000) NULL
	 , Estado BIT
)WITH (DATA_COMPRESSION = PAGE)
GO
