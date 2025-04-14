
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-01-05','2025-01-06',2,32,1,1,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-01-08','2025-01-09',4,66,2,2,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-01-10','2025-01-11',7,200,3,3,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-01-15','2025-01-15',1,25,4,4,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-01-20','2025-01-22',3,45,5,5,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-01-23','2025-01-25',8,51,6,6,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-02-01','2025-02-02',9,38,7,1,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL, '2025-02-05','2025-02-06',5,11,8,2,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL, '2025-02-10','2025-02-10',6,25,9,3,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-02-12','2025-02-14',10,59,10,4,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-02-18','2025-02-19',11,45,1,5,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-02-25','2025-02-26',12,33,2,6,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-03-02','2025-03-03',13,25,3,1,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-03-05','2025-03-07',15,32,4,2,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-03-09','2025-03-10',14,69,5,3,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-03-12','2025-03-12',2,34,5,4,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-03-15','2025-03-16',8,55,6,5,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-03-20','2025-03-22',5,11,7,6,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-03-25','2025-03-25',10,61,8,1,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-03-29','2025-03-30',11,47,9,2,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-04-01','2025-04-02',6,24,8,3,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-04-04','2025-04-05',9,44,1,4,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-04-06','2025-04-06',7,55,2,5,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-04-08','2025-04-09',14,70,3,6,1,'1';
--EXEC SPMantenimientoTransacCamion_Cilindros NULL,'2025-04-11','2025-04-12',3,44,4,1,1,'1';
--select * from TransacCamion_Cilindros

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