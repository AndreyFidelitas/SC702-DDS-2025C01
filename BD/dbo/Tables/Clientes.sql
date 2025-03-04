CREATE TABLE [dbo].[Clientes] (
    [ClientesID]       INT           IDENTITY (1, 1) NOT NULL,
    [ClientesCode]     VARCHAR (5)   NULL,
    [Cedula]           INT           NULL,
    [RazonSocial]      VARCHAR (100) NULL,
    [Empresa]          VARCHAR (100) NULL,
    [ClientesRol]      VARCHAR (100) NULL,
    [ClientesCreacion] DATETIME      NULL,
    [ClientesUpdate]   DATETIME      NULL,
    [ClientesDelete]   DATETIME      NULL,
    [ClientesStatus]   BIT           NULL,
    CONSTRAINT [PK__Clientes__E601B8EE0E586EB1] PRIMARY KEY CLUSTERED ([ClientesID] ASC)
);

