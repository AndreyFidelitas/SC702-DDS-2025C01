
CREATE PROCEDURE [dbo].[SPMantenimientoTransacCamion_Cilindros]
(
    @TransacID INT = NULL,         -- Identificador del registro; se usa en actualización o eliminación
    @FechaIngreso DATETIME = NULL,   -- Fecha de ingreso
    @FechaSalida DATETIME = NULL,    -- Fecha de salida
    @CamionID INT,                   -- ID del camión (FK a Camiones)
    @LimiteCamion INT,               -- Límite asignado al camión
    @UsuarioID INT,                  -- ID del usuario (FK a Usuarios)
    @InventarioID INT = NULL,        -- ID del inventario (FK a InventariosEncabezado)
    @TransacStatus BIT,              -- Estado de la transacción
    @accion VARCHAR(50) OUTPUT       -- Acción a realizar: '1' = Insertar, '2' = Actualizar, '3' = Eliminar (soft delete)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@accion = '1') -- Insertar nuevo registro
    BEGIN
        INSERT INTO TransacCamion_Cilindros
        (
            FechaIngreso,
            FechaSalida,
            CamionID,
            LimiteCamion,
            UsuarioID,
            InventarioID,
            TransacStatus,
            FechaCreacion
        )
        VALUES
        (
            @FechaIngreso,
            @FechaSalida,
            @CamionID,
            @LimiteCamion,
            @UsuarioID,
            @InventarioID,
            @TransacStatus,
            GETDATE()
        );

        DECLARE @NewTransacID INT;
        SET @NewTransacID = SCOPE_IDENTITY();

        SET @accion = 'Se insertó el registro con TransacID: ' + CAST(@NewTransacID AS VARCHAR(10));
        PRINT @accion;
    END
    ELSE IF (@accion = '2') -- Actualizar registro existente
    BEGIN
        IF EXISTS (SELECT 1 FROM TransacCamion_Cilindros WHERE TransacID = @TransacID)
        BEGIN
            UPDATE TransacCamion_Cilindros
            SET 
                FechaIngreso = @FechaIngreso,
                FechaSalida = @FechaSalida,
                CamionID = @CamionID,
                LimiteCamion = @LimiteCamion,
                UsuarioID = @UsuarioID,
                InventarioID = @InventarioID,
                TransacStatus = @TransacStatus,
                FechaUpdate = GETDATE()
            WHERE TransacID = @TransacID;

            SET @accion = 'Se actualizó el registro con TransacID: ' + CAST(@TransacID AS VARCHAR(10));
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el registro con TransacID: ' + CAST(@TransacID AS VARCHAR(10));
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar registro (soft delete)
    BEGIN
        IF EXISTS (SELECT 1 FROM TransacCamion_Cilindros WHERE TransacID = @TransacID)
        BEGIN
            UPDATE TransacCamion_Cilindros
            SET 
                TransacStatus = 0,
                FechaDelete = GETDATE()
            WHERE TransacID = @TransacID;

            SET @accion = 'Se eliminó (soft delete) el registro con TransacID: ' + CAST(@TransacID AS VARCHAR(10));
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el registro con TransacID: ' + CAST(@TransacID AS VARCHAR(10));
            PRINT @accion;
        END
    END
END