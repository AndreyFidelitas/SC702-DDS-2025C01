-- =============================================
-- Author:		Andrey Sanchez Zuñiga
-- Create date: 2025-02-17 20:52:45.700
-- Description:	Store procedure para tener la 
-- lista de clientes.
-- =============================================
CREATE PROCEDURE SPListaClientes
AS
BEGIN
	SELECT 
		 ClientesCode										   [Codigo Cliente]		,
		 RazonSocial										   [Razón Social]		,
		 Empresa											   [Empresa]			,
		 ClientesRol										   [Rol Cliente]		,
		 ISNULL(CONVERT(VARCHAR, c.ClientesCreacion, 13), '-') [Fecha Creacion]		,
		 ISNULL(CONVERT(VARCHAR, c.ClientesUpdate, 13), '-')   [Fecha Actualizacion],
		 ISNULL(CONVERT(VARCHAR, c.ClientesDelete, 13), '-')   [Fecha Eliminado]	,
		 Case 
			when c.ClientesStatus=1 then 'Activo'
			else 'Inactivo'	
		 end				[Estado]		
	  FROM
		Clientes c with(nolock)
END