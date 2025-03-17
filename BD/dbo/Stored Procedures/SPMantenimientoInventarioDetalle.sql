--EXEC SPMantenimientoInventarioDetalle null,1, 1, 500, '1';
--EXEC SPMantenimientoInventarioDetalle null,1, 2, 600, '1';
--EXEC SPMantenimientoInventarioDetalle null,1, 3, 400, '1';
--EXEC SPMantenimientoInventarioDetalle null,1, 4, 300, '1';
--EXEC SPMantenimientoInventarioDetalle null,1, 5, 200, '1';

--EXEC SPMantenimientoInventarioDetalle null,2, 1, 700, '1';
--EXEC SPMantenimientoInventarioDetalle null,2, 2, 800, '1';
--EXEC SPMantenimientoInventarioDetalle null,2, 3, 600, '1';
--EXEC SPMantenimientoInventarioDetalle null,2, 4, 500, '1';
--EXEC SPMantenimientoInventarioDetalle null,2, 5, 400, '1';

--EXEC SPMantenimientoInventarioDetalle null,3, 1, 550, '1';
--EXEC SPMantenimientoInventarioDetalle null,3, 2, 650, '1';
--EXEC SPMantenimientoInventarioDetalle null,3, 3, 450, '1';
--EXEC SPMantenimientoInventarioDetalle null,3, 4, 300, '1';
--EXEC SPMantenimientoInventarioDetalle null,3, 5, 50, '1';

--EXEC SPMantenimientoInventarioDetalle null,4, 1, 400, '1';
--EXEC SPMantenimientoInventarioDetalle null,4, 2, 500, '1';
--EXEC SPMantenimientoInventarioDetalle null,4, 3, 350, '1';
--EXEC SPMantenimientoInventarioDetalle null,4, 4, 200, '1';
--EXEC SPMantenimientoInventarioDetalle null,4, 5, 50, '1';

--EXEC SPMantenimientoInventarioDetalle null,5, 1, 650, '1';
--EXEC SPMantenimientoInventarioDetalle null,5, 2, 450, '1';
--EXEC SPMantenimientoInventarioDetalle null,5, 3, 350, '1';
--EXEC SPMantenimientoInventarioDetalle null,5, 4, 300, '1';
--EXEC SPMantenimientoInventarioDetalle null,5, 5, 250, '1';

--EXEC SPMantenimientoInventarioDetalle null,6, 1, 300, '1';
--EXEC SPMantenimientoInventarioDetalle null,6, 2, 400, '1';
--EXEC SPMantenimientoInventarioDetalle null,6, 3, 200, '1';
--EXEC SPMantenimientoInventarioDetalle null,6, 4, 75, '1';
--EXEC SPMantenimientoInventarioDetalle null,6, 5, 25, '1';


--SELECT * FROM InventarioDetalle

CREATE PROCEDURE [dbo].[SPMantenimientoInventarioDetalle]
(
    @InventarioDetalleCode VARCHAR(5) = NULL,  -- Código del detalle (se genera al insertar)
    @InventarioID INT,                         -- ID del inventario (Encabezado)
    @TipoCilindroID INT,                       -- ID del tipo de cilindro
    @Cantidad INT,                             -- Cantidad
    @accion VARCHAR(50) OUTPUT                 -- Acción a realizar: '1' = Insertar, '2' = Actualizar, '3' = Eliminar
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@accion = '1') -- Insertar nuevo detalle de inventario
    BEGIN
        DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
        SET @codmax = (SELECT MAX(InventarioDetalleCode) FROM InventarioDetalle);
        SET @codmax = ISNULL(@codmax, 'D0000');
        SET @codnuevo = 'D' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR), 4);

        INSERT INTO InventarioDetalle
        (
            InventarioDetalleCode,
            InventarioID,
            TipoCilindroID,
            Cantidad
        )
        VALUES
        (
            @codnuevo,
            @InventarioID,
            @TipoCilindroID,
            @Cantidad
        );

        SET @accion = 'Se generó el código del inventario detalle: ' + @codnuevo;
        PRINT @accion;
    END
    ELSE IF (@accion = '2') -- Actualizar detalle existente
    BEGIN
        IF EXISTS (SELECT 1 FROM InventarioDetalle WHERE InventarioDetalleCode = @InventarioDetalleCode)
        BEGIN
            UPDATE InventarioDetalle
            SET 
                InventarioID = @InventarioID,
                TipoCilindroID = @TipoCilindroID,
                Cantidad = @Cantidad
            WHERE InventarioDetalleCode = @InventarioDetalleCode;

            SET @accion = 'Se modificó el inventario detalle: ' + @InventarioDetalleCode;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el inventario detalle: ' + @InventarioDetalleCode;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar detalle (eliminación física)
    BEGIN
        IF EXISTS (SELECT 1 FROM InventarioDetalle WHERE InventarioDetalleCode = @InventarioDetalleCode)
        BEGIN
            DELETE FROM InventarioDetalle
            WHERE InventarioDetalleCode = @InventarioDetalleCode;

            SET @accion = 'Se eliminó el inventario detalle: ' + @InventarioDetalleCode;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el inventario detalle: ' + @InventarioDetalleCode;
            PRINT @accion;
        END
    END
END