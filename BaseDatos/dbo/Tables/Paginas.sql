CREATE TABLE [dbo].[Paginas]
(
	[PaginasId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NombrePagina] [varchar](50) NOT NULL,
	[DescPagina] [nvarchar](50) NOT NULL,
)
