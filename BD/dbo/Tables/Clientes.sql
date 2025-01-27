CREATE TABLE [dbo].[Clientes] (
    [ClientesID]       INT           IDENTITY (1, 1) NOT NULL,
    [ClientesCode]     VARCHAR (5)   NULL,
    [RazonSocial]      VARCHAR (100) NULL,
    [Empresa]          VARCHAR (100) NULL,
    [ClientesRol]      VARCHAR (100) NULL,
    [ClientesCreacion] DATETIME      NULL,
    [ClientesUpdate]   DATETIME      NULL,
    [ClientesDelete]   DATETIME      NULL,
    [ClientesStatus]   BIT           NULL,
    PRIMARY KEY CLUSTERED ([ClientesID] ASC)
);



