

CREATE PROCEDURE [dbo].[SPListaUsuarios]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.UsuarioCode                                       [Usuario ID]		,
        u.Cedula											[Cedula]			,
		u.UsuarioName                                       [Nombre]			,
        u.UsuarioApellidos                                  [Apellidos]			,
        u.UsuarioUserName                                   [Nombre de Usuario]	,
        r.RoleName                                          [ID Rol]			,
        ISNULL(CONVERT(VARCHAR, u.UsuarioCreacion, 13),'-') [Fecha Creación]	,
        ISNULL(CONVERT(VARCHAR, u.UsuarioDelete, 13),'-')   [Fecha Eliminado]	,
        ISNULL(CONVERT(VARCHAR, u.UsuarioUpdate, 13),'-')   [Fecha Modificado]	,
        CASE 
            WHEN u.UsuarioEstado = 1 THEN 'Activo'
            ELSE 'Inactivo'
        END                                                 [Estado]
    FROM 
        Usuarios	u WITH (NOLOCK),
		Roles		r with(NOLOCK)
	where 
		u.RoleID = r.RolesId
END