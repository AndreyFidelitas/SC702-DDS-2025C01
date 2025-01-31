CREATE TABLE [dbo].[InventarioDetalle] (
    [InventarioDetalle]    INT      IDENTITY (1, 1) NOT NULL,
    [InventarioID]         INT      NOT NULL,
    [TipoCilindroID]       INT      NOT NULL,
    [InventariosDCreacion] DATETIME NULL,
    [InventariosUpdate]    DATETIME NULL,
    [InventarioDelete]     DATETIME NULL,
    PRIMARY KEY CLUSTERED ([InventarioDetalle] ASC),
    CONSTRAINT [FK_InventarioDetalle_InventariosEncabezado] FOREIGN KEY ([InventarioID]) REFERENCES [dbo].[InventariosEncabezado] ([InventarioID]),
    CONSTRAINT [FK_InventarioDetalle_TipoCilindro] FOREIGN KEY ([TipoCilindroID]) REFERENCES [dbo].[TipoCilindro] ([TipoCilindroID])
);

