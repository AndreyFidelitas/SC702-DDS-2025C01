CREATE TABLE [dbo].[InventariosAsignacion] (
    [InventAsign]   INT      IDENTITY (1, 1) NOT NULL,
    [TransacID]     INT      NOT NULL,
    [IdRuta]        INT      NOT NULL,
    [FechaCreacion] DATETIME NULL,
    [FechaUpdate]   DATETIME NULL,
    [FechaDelete]   DATETIME NULL,
    [InventStatus]  BIT      NULL,
    [InventarioID]  INT      NOT NULL,
    CONSTRAINT [PK__Inventar__02CFEAD4FA971D5E] PRIMARY KEY CLUSTERED ([InventAsign] ASC),
    CONSTRAINT [FK_InventariosAsignacion_InventariosEncabezado] FOREIGN KEY ([InventarioID]) REFERENCES [dbo].[InventariosEncabezado] ([InventarioID]),
    CONSTRAINT [FK_InventariosAsignacion_Rutas] FOREIGN KEY ([IdRuta]) REFERENCES [dbo].[Rutas] ([IdRuta]),
    CONSTRAINT [FK_InventariosAsignacion_TransacCamion_Cilindros] FOREIGN KEY ([TransacID]) REFERENCES [dbo].[TransacCamion_Cilindros] ([TransacID])
);

