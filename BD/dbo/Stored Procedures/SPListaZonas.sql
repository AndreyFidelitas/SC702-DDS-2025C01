-- =============================================
-- Author:		<Andrey Sanchez Zuñiga>
-- =============================================
CREATE PROCEDURE SPListaZonas
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		z.ZonasCode											[Zona ID]			,
		p.ProvinciaName										[Provincia]			,
		z.ZonasName											[Nombre Zona]		,
		ISNULL(CONVERT(VARCHAR, z.ZonasCreacion, 13), '-')  [Fecha Creacion]	,
		ISNULL(CONVERT(VARCHAR, z.ZonasDelete, 13), '-')    [Fecha Eliminado]	,
		ISNULL(CONVERT(VARCHAR, z.ZonasUpdate, 13), '-')    [Fecha Modificado],
		case 
			when z.ZonasEstado=1 then 'Activo'
			else 'Inactivo'
		end	[Estado]
	 FROM 
		Zonas		z with(nolock),
		Provincia	p with(nolock)
	where
		z.ProvinciaID	= p.ProvinciaID
	
END