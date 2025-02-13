

CREATE PROCEDURE [dbo].[SPListaCamiones]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.CamionCode										[Camión ID],
        c.CamionName										[Marca]				,
		c.CamionPlaca										[Placa]				,
		c.CamionPesaje										[Pesaje Camion]		,
        ISNULL(CONVERT(VARCHAR, c.CamionCreacion, 13), '-') [Fecha Creación]	,
        ISNULL(CONVERT(VARCHAR, c.CamionDelete, 13), '-')   [Fecha Eliminado]	,
        ISNULL(CONVERT(VARCHAR, c.CamionUpdate, 13), '-')   [Fecha Modificado]	,
        CASE 
            WHEN c.CamionStatus = 1 THEN 'Activo'
            ELSE 'Inactivo'
        END													[Estado]			,
		CASE 
            WHEN c.CamionActivty = 1 THEN 'En Operación'
			when c.CamionActivty = 0 THEN 'Mantenimiento'
            ELSE '-'										
        END													[Estado Camion]
    FROM 
        Camiones c WITH (NOLOCK);
END