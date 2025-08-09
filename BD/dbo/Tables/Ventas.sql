CREATE TABLE [dbo].[Ventas] (
    [VentaID]           INT             IDENTITY (1, 1) NOT NULL,
    [PlantaID]          INT             NOT NULL,
    [Planta]            VARCHAR (100)   NULL,
    [RutaID]            INT             NOT NULL,
    [Ruta]              VARCHAR (150)   NULL,
    [Fecha]             DATETIME        NOT NULL,
    [Codigo_Cliente]    INT             NOT NULL,
    [Cliente]           VARCHAR (255)   NULL,
    [Tipo_Cliente]      VARCHAR (100)   NULL,
    [Categoria_Cliente] VARCHAR (100)   NULL,
    [Codigo_Subcliente] INT             NULL,
    [Subcliente]        VARCHAR (150)   NULL,
    [Producto]          VARCHAR (50)    NULL,
    [Categoria]         VARCHAR (50)    NULL,
    [Cantidad]          DECIMAL (10, 2) NULL,
    [Litros]            DECIMAL (10, 2) NULL,
    [Otros_Impuestos]   DECIMAL (10, 2) NULL,
    [Total]             DECIMAL (12, 2) NULL,
    [VendedorID]        INT             NOT NULL,
    [Vendedor]          VARCHAR (150)   NULL,
    PRIMARY KEY CLUSTERED ([VentaID] ASC)
);

