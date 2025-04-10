create PROCEDURE [dbo].[SPListaSolicitudUsuarios]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.SolicitudCode											[Solicitud Code]	,
        u.Cedula												[Cedula]			,
		u.Name													[Nombre]			,
        u.Apellidos												[Apellidos]			,
        ISNULL(CONVERT(VARCHAR, u.SolcitudAceptada, 13),'-')	[Fecha Aceptado]	,
        ISNULL(CONVERT(VARCHAR, u.SolcitudRechaza, 13),'-')		[Fecha Rechazado]	,
        CASE 
            WHEN u.SolcitudEstado = 0 THEN 'Rechazado'
            WHEN u.SolcitudEstado = 1 THEN 'Aceptado'      
			ELSE '-'
        END                                                 [Estado]
    FROM 
        UsuariosSolcitud	u WITH (NOLOCK)
END
