CREATE PROCEDURE ValidarUsuario
    @Cedula INT = NULL,  -- Parámetro opcional para buscar un usuario específico
    @UsuarioUserName varchar(100) = NULL -- Parámetro opcional para buscar por cédula
AS
BEGIN
    SELECT 
        u.UsuarioCode											AS [Usuario ID],
        u.Cedula												AS [Cedula],
        u.UsuarioName											AS [Nombre],
        u.UsuarioApellidos										AS [Apellidos],
        u.UsuarioUserName										AS [Nombre de Usuario],
        r.RoleName												AS [ID Rol],
		u.Password												as [Contraseña],
        ISNULL(CONVERT(VARCHAR, u.UsuarioCreacion, 13), '-')	AS [Fecha Creación],
        ISNULL(CONVERT(VARCHAR, u.UsuarioDelete, 13), '-')		AS [Fecha Eliminado],
        ISNULL(CONVERT(VARCHAR, u.UsuarioUpdate, 13), '-')		AS [Fecha Modificado],
        CASE 
            WHEN u.UsuarioEstado = 1 THEN 'Activo'
            ELSE 'Inactivo'
        END                                                 AS [Estado]
    FROM 
        Usuarios u WITH (NOLOCK)
    INNER JOIN 
        Roles r WITH (NOLOCK) ON u.RoleID = r.RolesId
    WHERE 
        (@UsuarioUserName IS NULL OR u.UsuarioUserName = @UsuarioUserName)  -- Filtro por UsuarioCode (opcional)
        AND (@Cedula IS NULL OR u.Cedula = @Cedula);						-- Filtro por Cédula (opcional)
END;