create PROCEDURE [dbo].[SPListaCamiones]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.CamionCode                                      [Camión ID],
        c.CamionName                                      [Nombre Camión],
        ISNULL(CONVERT(VARCHAR, c.CamionCreacion, 13), '-') [Fecha Creación],
        ISNULL(CONVERT(VARCHAR, c.CamionDelete, 13), '-')   [Fecha Eliminado],
        ISNULL(CONVERT(VARCHAR, c.CamionUpdate, 13), '-')   [Fecha Modificado],
        CASE 
            WHEN c.CamionStatus = 1 THEN 'Activo'
            ELSE 'Inactivo'
        END                                               [Estado]
    FROM 
        Camiones c WITH (NOLOCK);
END