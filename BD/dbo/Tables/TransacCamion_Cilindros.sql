CREATE TABLE [dbo].[TransacCamion_Cilindros] (
    [TransacID]     INT      IDENTITY (1, 1) NOT NULL,
    [FechaIngreso]  DATETIME NULL,
    [FechaSalida]   DATETIME NULL,
    [CamionID]      INT      NOT NULL,
    [LimiteCamion]  INT      NULL,
    [UsuarioID]     INT      NOT NULL,
    [InventarioID]  INT      NULL,
    [FechaCreacion] DATETIME NULL,
    [FechaUpdate]   DATETIME NULL,
    [FechaDelete]   DATETIME NULL,
    [TransacStatus] BIT      NULL,
    PRIMARY KEY CLUSTERED ([TransacID] ASC),
    CONSTRAINT [FK_TransacCamion_Cilindros_Camiones] FOREIGN KEY ([CamionID]) REFERENCES [dbo].[Camiones] ([CamionID]),
    CONSTRAINT [FK_TransacCamion_Cilindros_Inventarios] FOREIGN KEY ([InventarioID]) REFERENCES [dbo].[InventariosEncabezado] ([InventarioID]),
    CONSTRAINT [FK_TransacCamion_Cilindros_Usuarios] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuarios] ([UsuarioID])
);

