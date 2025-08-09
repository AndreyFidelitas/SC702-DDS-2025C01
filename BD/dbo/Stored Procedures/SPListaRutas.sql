CREATE PROCEDURE [dbo].[SPListaRutas]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		RutaCode	[Codigo Ruta]		,
		Ruta		[Ruta]				,
		case 
		when RutaStatus=1 then 'Activo'
		else 'Inactivo'
		end			[Estado]
	FROM 
		Rutas with(nolock)
END
GO
