-- =============================================
-- Author:		Andrey Sanchez Zuniga
-- =============================================
CREATE PROCEDURE SPListaRoles
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
      RoleCode		[Codigo Rol],
      RoleName		[Rol]		,
    case 
	when RoleStatus=1 then 'Activo'
	else 'Inactivo'	
	end				[Estado]
  FROM
	[dbo].[Roles] with(nolock)
END