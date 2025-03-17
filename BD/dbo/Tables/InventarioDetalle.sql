CREATE TABLE [dbo].[InventarioDetalle] (
    [InventarioDetalleID]   INT         IDENTITY (1, 1) NOT NULL,
    [InventarioID]          INT         NULL,
    [InventarioDetalleCode] VARCHAR (5) NULL,
    [TipoCilindroID]        INT         NOT NULL,
    [Cantidad]              INT         NOT NULL,
    [InventariosDCreacion]  DATETIME    NULL,
    [InventariosUpdate]     DATETIME    NULL,
    [InventarioDelete]      DATETIME    NULL,
    CONSTRAINT [PK__Inventar__709142AA016989AB] PRIMARY KEY CLUSTERED ([InventarioDetalleID] ASC),
    CONSTRAINT [FK_InventarioDetalle_InventariosEncabezado] FOREIGN KEY ([InventarioID]) REFERENCES [dbo].[InventariosEncabezado] ([InventarioID]),
    CONSTRAINT [FK_InventarioDetalle_TipoCilindro] FOREIGN KEY ([TipoCilindroID]) REFERENCES [dbo].[TipoCilindro] ([TipoCilindroID])
);





