CREATE procedure ListaVentas
as
begin
SELECT 
      [Planta]			as 'Planta'
      ,[Ruta]			as 'Ruta'
      ,[Cliente]		as 'Clientes'
      ,[Subcliente]     as 'Producto'
      ,[Producto]		as 'Cantidad'
      ,CONCAT('₡', FORMAT([Litros], 'N2', 'es-CR')) AS Precio
      ,'Fact #' + CAST([Total] AS VARCHAR) AS [Venta ID]
  FROM [dbo].[Ventas]
end