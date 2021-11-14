CREATE PROCEDURE [dbo].[PaginasObtener]
AS
BEGIN
SET NOCOUNT ON
    SELECT [PaginasId]
          ,[NombrePagina]
          ,[DescPagina]
    FROM [dbo].[Paginas]

END