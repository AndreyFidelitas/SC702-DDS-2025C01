
CREATE PROCEDURE [dbo].[SPMantenimientoInventariosAsignacion]
(
    @InventAsign INT = NULL,       -- Identificador del registro (se usa en actualización y eliminación)
    @TransacID INT,                -- FK de TransacCamion_Cilindros
    @IdRuta INT,                   -- FK de Rutas
    @InventarioID INT,             -- FK de InventariosEncabezado
    @InventStatus BIT,             -- Estado del registro (1 = Activo, 0 = Inactivo)
    @accion VARCHAR(50) OUTPUT     -- Acción a realizar: '1' = Insertar, '2' = Actualizar, '3' = Eliminar (soft delete)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@accion = '1') -- Insertar nuevo registro
    BEGIN
        INSERT INTO InventariosAsignacion
        (
            TransacID,
            IdRuta,
            FechaCreacion,
            InventStatus,
            InventarioID
        )
        VALUES
        (
            @TransacID,
            @IdRuta,
            GETDATE(),
            @InventStatus,
            @InventarioID
        );

        DECLARE @NewInventAsign INT;
        SET @NewInventAsign = SCOPE_IDENTITY();

        SET @accion = 'Se insertó el registro con InventAsign: ' + CAST(@NewInventAsign AS VARCHAR(10));
        PRINT @accion;
    END
    ELSE IF (@accion = '2') -- Actualizar registro existente
    BEGIN
        IF EXISTS (SELECT 1 FROM InventariosAsignacion WHERE InventAsign = @InventAsign)
        BEGIN
            UPDATE InventariosAsignacion
            SET 
                TransacID = @TransacID,
                IdRuta = @IdRuta,
                InventarioID = @InventarioID,
                InventStatus = @InventStatus,
                FechaUpdate = GETDATE()
            WHERE InventAsign = @InventAsign;

            SET @accion = 'Se actualizó el registro con InventAsign: ' + CAST(@InventAsign AS VARCHAR(10));
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el registro con InventAsign: ' + CAST(@InventAsign AS VARCHAR(10));
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar registro (soft delete)
    BEGIN
        IF EXISTS (SELECT 1 FROM InventariosAsignacion WHERE InventAsign = @InventAsign)
        BEGIN
            UPDATE InventariosAsignacion
            SET 
                InventStatus = 0,
                FechaDelete = GETDATE()
            WHERE InventAsign = @InventAsign;

            SET @accion = 'Se eliminó (soft delete) el registro con InventAsign: ' + CAST(@InventAsign AS VARCHAR(10));
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el registro con InventAsign: ' + CAST(@InventAsign AS VARCHAR(10));
            PRINT @accion;
        END
    END
END