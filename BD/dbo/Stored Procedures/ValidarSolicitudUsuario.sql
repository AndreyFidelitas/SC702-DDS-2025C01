
CREATE PROCEDURE [dbo].[ValidarSolicitudUsuario]
    @Cedula INT = NULL  -- Parámetro opcional para buscar un usuario específico
AS
BEGIN
    SELECT 
        u.SolicitudCode											AS [Usuario ID]			,
        u.Cedula												AS [Cedula]				,
        u.Name													AS [Nombre]				,
        u.Apellidos												AS [Apellidos]			,
        ISNULL(us.UsuarioName+''+us.UsuarioApellidos,'-')		as [Usuario Aprobado]	,
        ISNULL(CONVERT(VARCHAR, u.SolcitudAceptada, 13), '-')	AS [Fecha Aceptado]		,
        ISNULL(CONVERT(VARCHAR, u.SolcitudRechaza, 13), '-')	AS [Fecha Rechazado]	,
        CASE 
            WHEN u.SolcitudEstado = 1 THEN 'Activo'
            ELSE 'Inactivo'
        END                                                 AS [Estado]
    FROM 
        UsuariosSolcitud u WITH (NOLOCK)
		left join Usuarios us on 
		u.UsuarioID = us.UsuarioID
    WHERE 
        --(@UsuarioUserName IS NULL OR u.UsuarioUserName = @UsuarioUserName)  -- Filtro por UsuarioCode (opcional)
        (@Cedula IS NULL OR u.Cedula = @Cedula);						-- Filtro por Cédula (opcional)
END;