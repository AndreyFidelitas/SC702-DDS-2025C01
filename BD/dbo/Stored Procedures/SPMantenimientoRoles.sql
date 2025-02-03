
CREATE PROCEDURE [dbo].[SPMantenimientoRoles]
(
    @RoleId INT = NULL,             -- ID del Rol (para actualizar o eliminar)
    @RoleCode VARCHAR(5),           -- Código del Rol
    @RoleName VARCHAR(100),         -- Nombre del Rol
    @RoleStatus BIT,                -- Estado del Rol (1 = Activo, 0 = Inactivo)
    @accion VARCHAR(50) OUTPUT      -- Acción a realizar (1 = Insertar, 2 = Actualizar, 3 = Eliminar)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@accion = '1') -- Insertar nuevo rol
    BEGIN
        IF EXISTS (SELECT 1 FROM Roles WHERE RoleCode = @RoleCode OR RoleName = @RoleName)
        BEGIN
            SET @accion = 'El rol con código "' + @RoleCode + '" o nombre "' + @RoleName + '" ya existe.';
            PRINT @accion;
        END
        ELSE
        BEGIN
            INSERT INTO Roles
            (
                RoleCode,
                RoleName,
                RoleStatus
            )
            VALUES
            (
                @RoleCode,
                @RoleName,
                @RoleStatus
            );

            SET @accion = 'Se creó el rol con código: ' + @RoleCode;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '2') -- Actualizar rol existente
    BEGIN
        IF EXISTS (SELECT 1 FROM Roles WHERE RolesId = @RoleId)
        BEGIN
            UPDATE Roles
            SET 
                RoleCode = @RoleCode,
                RoleName = @RoleName,
                RoleStatus = @RoleStatus
            WHERE 
                RolesId = @RoleId;

            SET @accion = 'Se actualizó el rol con ID: ' + CAST(@RoleId AS VARCHAR);
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el rol con ID: ' + CAST(@RoleId AS VARCHAR);
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar rol (lógico)
    BEGIN
        IF EXISTS (SELECT 1 FROM Roles WHERE RolesId = @RoleId)
        BEGIN
            -- Verificar si el rol está asociado a algún usuario
            IF EXISTS (SELECT 1 FROM Usuarios WHERE RoleID = @RoleId)
            BEGIN
                SET @accion = 'No se puede eliminar el rol con ID "' + CAST(@RoleId AS VARCHAR) + '" porque está asociado a uno o más usuarios.';
                PRINT @accion;
            END
            ELSE
            BEGIN
                UPDATE Roles
                SET 
                    RoleStatus = 0
                WHERE 
                    RolesId = @RoleId;

                SET @accion = 'Se eliminó el rol con ID: ' + CAST(@RoleId AS VARCHAR);
                PRINT @accion;
            END
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el rol con ID: ' + CAST(@RoleId AS VARCHAR);
            PRINT @accion;
        END
    END
END