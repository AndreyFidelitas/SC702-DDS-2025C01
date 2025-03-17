Create PROCEDURE [dbo].[SPCargaRoles]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
      RolesId		[Codigo Rol],
      RoleName		[Rol]		
  FROM
	[dbo].[Roles] with(nolock)
END