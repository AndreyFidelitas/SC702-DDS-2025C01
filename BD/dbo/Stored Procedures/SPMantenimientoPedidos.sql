
CREATE PROCEDURE [dbo].[SPMantenimientoPedidos]
(
    @PedidoCode VARCHAR(5) = NULL,   -- Código del pedido (se genera al insertar)
    @ClienteID INT,                  -- ID del cliente
    @CamionID INT,                   -- ID del camión
    @ZonaID INT,                     -- ID de la zona
    @Fecha DATETIME,                 -- Fecha del pedido
    @Destino VARCHAR(255),           -- Destino del pedido
    @Cantidad INT,                   -- Cantidad solicitada
    @UsuarioID INT,                  -- ID del usuario que realiza la acción
    @PedidosStatus INT,              -- Estado del pedido (1 = Activo, 0 = Inactivo)
    @accion VARCHAR(50) OUTPUT       -- Acción a realizar ('1' = Insertar, '2' = Actualizar, '3' = Eliminar)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@accion = '1') -- Insertar nuevo pedido
    BEGIN
        DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
        SET @codmax = (SELECT MAX(PedidoCode) FROM Pedidos);
        SET @codmax = ISNULL(@codmax, 'P0000');
        SET @codnuevo = 'P' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR), 4);

        INSERT INTO Pedidos
        (
            PedidoCode,
            ClienteID,
            CamionID,
            ZonaID,
            Fecha,
            Destino,
            Cantidad,
            PedidosCreacion,
            UsuarioID,
            PedidosStatus
        )
        VALUES
        (
            @codnuevo,
            @ClienteID,
            @CamionID,
            @ZonaID,
            @Fecha,
            @Destino,
            @Cantidad,
            GETDATE(),
            @UsuarioID,
            @PedidosStatus
        );

        SET @accion = 'Se generó el código del pedido: ' + @codnuevo;
        PRINT @accion;
    END
    ELSE IF (@accion = '2') -- Actualizar pedido existente
    BEGIN
        IF EXISTS (SELECT 1 FROM Pedidos WHERE PedidoCode = @PedidoCode)
        BEGIN
            UPDATE p
            SET 
                p.ClienteID = @ClienteID,
                p.CamionID = @CamionID,
                p.ZonaID = @ZonaID,
                p.Fecha = @Fecha,
                p.Destino = @Destino,
                p.Cantidad = @Cantidad,
                p.UsuarioID = @UsuarioID,
                p.PedidosStatus = @PedidosStatus,
                p.PedidosUpdate = GETDATE()
            FROM Pedidos p
            WHERE p.PedidoCode = @PedidoCode;

            SET @accion = 'Se modificó el pedido: ' + @PedidoCode;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el pedido: ' + @PedidoCode;
            PRINT @accion;
        END
    END
    ELSE IF (@accion = '3') -- Eliminar pedido (marcar como inactivo)
    BEGIN
        IF EXISTS (SELECT 1 FROM Pedidos WHERE PedidoCode = @PedidoCode)
        BEGIN
            UPDATE p
            SET 
                p.PedidosStatus = 0,
                p.PedidosDelete = GETDATE()
            FROM Pedidos p
            WHERE p.PedidoCode = @PedidoCode;

            SET @accion = 'Se eliminó el pedido: ' + @PedidoCode;
            PRINT @accion;
        END
        ELSE
        BEGIN
            SET @accion = 'No se encontró el pedido: ' + @PedidoCode;
            PRINT @accion;
        END
    END
END