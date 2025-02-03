

--exec SPMantenimientoRoles '','Transportista2',1,'1'
--select * from Roles



CREATE PROCEDURE [dbo].[SPMantenimientoRoles]
(
    @RoleCode VARCHAR(5),           -- Código del Rol
    @RoleName VARCHAR(100),         -- Nombre del Rol
    @RoleStatus BIT,                -- Estado del Rol (1 = Activo, 0 = Inactivo)
    @accion VARCHAR(50) OUTPUT      -- Acción a realizar (1 = Insertar, 2 = Actualizar, 3 = Eliminar)
)
AS
BEGIN
    SET NOCOUNT ON;

	declare @RoleID as int;

    IF (@accion = '1') -- Insertar nuevo rol
    BEGIN
        IF EXISTS (SELECT 1 FROM Roles WHERE RoleCode = @RoleCode OR RoleName = @RoleName)
        BEGIN
            SET @accion = 'El rol con código "' + @RoleCode + '" o nombre "' + @RoleName + '" ya existe.';
            PRINT @accion;
        END
        ELSE
        BEGIN
			
			declare @codnuevo varchar(5), @codmax varchar(5)
			set @codmax = (select max(RoleCode) from Roles)
			set @codmax = isnull(@codmax,'R0000')
			set @codnuevo = 'R'+RIGHT(RIGHT(@codmax,4)+10001,4)


            INSERT INTO Roles
            (
                RoleCode,
                RoleName,
                RoleStatus
            )
            VALUES
            (
               @codnuevo,
                @RoleName,
                @RoleStatus
            );

            SET @accion = 'Se creó el rol con código: ' +@codnuevo;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '2') -- Actualizar rol existente
    BEGIN
        IF EXISTS (SELECT 1 FROM Roles WHERE RoleCode = @RoleCode)
        BEGIN
            UPDATE Roles
            SET 
                RoleName = @RoleName,
                RoleStatus = @RoleStatus
            WHERE 
                RoleCode = @RoleCode;

            SET @accion = 'Se actualizó el rol con ID: ' + CAST(@RoleCode AS VARCHAR);
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el rol con ID: ' + CAST(@RoleCode AS VARCHAR);
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar rol (lógico)
    BEGIN
        IF EXISTS (SELECT 1 FROM Roles WHERE @RoleCode = @RoleCode)
        BEGIN
   --         -- Verificar si el rol está asociado a algún usuario
   --         IF EXISTS (SELECT 1 FROM Usuarios WHERE RoleID = @RoleId)
				
			--	--set @RoleID = select
			--	--				from Roles							
			--BEGIN
   --             SET @accion = 'No se puede eliminar el rol con ID "' + CAST(@RoleId AS VARCHAR) + '" porque está asociado a uno o más usuarios.';
   --             PRINT @accion;
   --         END
   --         ELSE
   --         BEGIN
                UPDATE Roles
                SET 
                    RoleStatus = 0
                WHERE 
                    RoleCode = @RoleCode;

                SET @accion = 'Se eliminó el rol con ID: ' + CAST(@RoleCode AS VARCHAR);
                PRINT @accion;
   --         END
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el rol con ID: ' + CAST(@RoleCode AS VARCHAR);
            PRINT @accion;
        END
    END
END