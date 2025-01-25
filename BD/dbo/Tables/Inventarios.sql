CREATE TABLE [dbo].[Inventarios] (
    [InventarioID]        INT         IDENTITY (1, 1) NOT NULL,
    [ZonasID]             INT         NULL,
    [InventariosCode]     VARCHAR (5) NULL,
    [TipoCilindroID]      INT         NULL,
    [Cantidad]            INT         NULL,
    [CilindroCode]        VARCHAR (5) NULL,
    [InventariosCreacion] DATETIME    NULL,
    [InventariosUpdate]   DATETIME    NULL,
    [InventariosDelete]   DATETIME    NULL,
    [InventariosStatus]   BIT         NULL,
    PRIMARY KEY CLUSTERED ([InventarioID] ASC),
    CONSTRAINT [FK_Inventarios_TipoCilindro] FOREIGN KEY ([TipoCilindroID]) REFERENCES [dbo].[TipoCilindro] ([TipoCilindroID]),
    CONSTRAINT [FK_Inventarios_Zonas] FOREIGN KEY ([ZonasID]) REFERENCES [dbo].[Zonas] ([ZonasID])
);

