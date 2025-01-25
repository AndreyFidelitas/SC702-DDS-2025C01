CREATE TABLE [dbo].[Pedidos] (
    [PedidoID]        INT           IDENTITY (1, 1) NOT NULL,
    [ClienteID]       INT           NULL,
    [CamionID]        INT           NULL,
    [ZonaID]          INT           NULL,
    [PedidoCode]      VARCHAR (5)   NULL,
    [Fecha]           DATETIME      NULL,
    [Destino]         VARCHAR (255) NULL,
    [Cantidad]        INT           NULL,
    [PedidosCreacion] DATETIME      NULL,
    [PedidosUpdate]   DATETIME      NULL,
    [PedidosDelete]   DATETIME      NULL,
    [UsuarioID]       INT           NOT NULL,
    [PedidosStatus]   INT           NOT NULL,
    CONSTRAINT [PK__Pedidos__09BA1410F4F6A58D] PRIMARY KEY CLUSTERED ([PedidoID] ASC),
    CONSTRAINT [FK_Pedidos_Camiones] FOREIGN KEY ([CamionID]) REFERENCES [dbo].[Camiones] ([CamionID]),
    CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY ([ClienteID]) REFERENCES [dbo].[Clientes] ([ClientesID]),
    CONSTRAINT [FK_Pedidos_Usuarios] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuarios] ([UsuarioID]),
    CONSTRAINT [FK_Pedidos_Zonas] FOREIGN KEY ([ZonaID]) REFERENCES [dbo].[Zonas] ([ZonasID])
);

