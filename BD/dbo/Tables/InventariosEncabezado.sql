CREATE TABLE [dbo].[InventariosEncabezado] (
    [InventarioID]        INT         IDENTITY (1, 1) NOT NULL,
    [ZonasID]             INT         NULL,
    [InventariosCode]     VARCHAR (5) NULL,
    [CantidadTotal]       INT         NULL,
    [InventariosCreacion] DATETIME    NULL,
    [InventariosUpdate]   DATETIME    NULL,
    [InventariosDelete]   DATETIME    NULL,
    [InventariosStatus]   BIT         NULL,
    PRIMARY KEY CLUSTERED ([InventarioID] ASC),
    CONSTRAINT [FK_InventariosDetalle_Zonas] FOREIGN KEY ([ZonasID]) REFERENCES [dbo].[Zonas] ([ZonasID])
);

