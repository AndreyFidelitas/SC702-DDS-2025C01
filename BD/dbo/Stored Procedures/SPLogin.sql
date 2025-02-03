
CREATE PROCEDURE [dbo].[SPLogin]
(
    @UsuarioUserName NVARCHAR(100), -- Nombre de usuario
    @Password NVARCHAR(100),       -- Contraseña
    @Mensaje NVARCHAR(255) OUTPUT  -- Mensaje de salida
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el usuario existe y está activo
    IF EXISTS (SELECT 1 
               FROM Usuarios 
               WHERE UsuarioUserName = @UsuarioUserName 
                 AND Password = @Password
                 AND UsuarioEstado = 1)
    BEGIN
        -- Devolver la información del usuario
        SELECT 
            u.UsuarioCode         AS [Usuario ID],
            u.UsuarioName         AS [Nombre],
            u.UsuarioApellidos    AS [Apellidos],
            u.UsuarioUserName     AS [Nombre de Usuario],
            r.RoleCode            AS [Código Rol],
            r.RoleName            AS [Nombre Rol]
        FROM 
            Usuarios u
        INNER JOIN 
            Roles r ON u.RoleID = r.RolesId
        WHERE 
            u.UsuarioUserName = @UsuarioUserName
            AND u.Password = @Password;

        SET @Mensaje = 'Inicio de sesión exitoso.';
    END
    ELSE
    BEGIN
        -- Si no se encuentra el usuario o las credenciales son inválidas
        SET @Mensaje = 'Nombre de usuario o contraseña incorrectos, o el usuario no está activo.';
    END
END