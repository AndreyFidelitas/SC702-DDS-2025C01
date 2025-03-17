--EXEC SPMantenimientoInventariosEncabezado null,1, 2000, 1, '1'; (Lima Cartago)
--EXEC SPMantenimientoInventariosEncabezado null,2, 3000, 1, '1'; (Coyol Alauela)
--EXEC SPMantenimientoInventariosEncabezado null,3, 2000, 1, '1'; (Limon Limon)
--EXEC SPMantenimientoInventariosEncabezado null,4, 1500, 1, '1'; (Bagaces Guanacaste)
--EXEC SPMantenimientoInventariosEncabezado null,5, 2000, 1, '1'; (Guapiles Limon)
--EXEC SPMantenimientoInventariosEncabezado null,6, 1000, 1, '1'; (Florencia Alajuela)

CREATE PROCEDURE [dbo].[SPMantenimientoInventariosEncabezado]
(
    @InventariosCode VARCHAR(5) = NULL,  -- Código del inventario (se genera al insertar)
    @ZonasID INT = NULL,                 -- ID de la zona asociada
    @CantidadTotal INT,                  -- Cantidad total del inventario
    @InventariosStatus BIT,              -- Estado del inventario (1 = Activo, 0 = Inactivo)
    @accion VARCHAR(50) OUTPUT           -- Acción a realizar: '1' = Insertar, '2' = Actualizar, '3' = Eliminar
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@accion = '1') -- Insertar nuevo inventario
    BEGIN
        DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
        SET @codmax = (SELECT MAX(InventariosCode) FROM InventariosEncabezado);
        SET @codmax = ISNULL(@codmax, 'I0000');
        SET @codnuevo = 'I' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR), 4);

        INSERT INTO InventariosEncabezado
        (
            InventariosCode,
            ZonasID,
            CantidadTotal,
            InventariosCreacion,
            InventariosStatus
        )
        VALUES
        (
            @codnuevo,
            @ZonasID,
            @CantidadTotal,
            GETDATE(),
            @InventariosStatus
        );

        SET @accion = 'Se generó el código del inventario: ' + @codnuevo;
        PRINT @accion;
    END
    ELSE IF (@accion = '2') -- Actualizar inventario existente
    BEGIN
        IF EXISTS (SELECT 1 FROM InventariosEncabezado WHERE InventariosCode = @InventariosCode)
        BEGIN
            UPDATE IE
            SET 
                ZonasID = @ZonasID,
                CantidadTotal = @CantidadTotal,
                InventariosStatus = @InventariosStatus,
                InventariosUpdate = GETDATE()
            FROM InventariosEncabezado IE
            WHERE InventariosCode = @InventariosCode;

            SET @accion = 'Se modificó el inventario: ' + @InventariosCode;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el inventario: ' + @InventariosCode;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar (soft delete) inventario
    BEGIN
        IF EXISTS (SELECT 1 FROM InventariosEncabezado WHERE InventariosCode = @InventariosCode)
        BEGIN
            UPDATE IE
            SET 
                InventariosStatus = 0,
                InventariosDelete = GETDATE()
            FROM InventariosEncabezado IE
            WHERE InventariosCode = @InventariosCode;

            SET @accion = 'Se eliminó el inventario: ' + @InventariosCode;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el inventario: ' + @InventariosCode;
            PRINT @accion;
        END
    END
END