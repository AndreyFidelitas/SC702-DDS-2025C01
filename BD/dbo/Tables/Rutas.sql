CREATE TABLE [dbo].[Rutas] (
    [IdRuta]     INT           IDENTITY (1, 1) NOT NULL,
    [RutaCode]   VARCHAR (1)   NOT NULL,
    [Ruta]       VARCHAR (100) NOT NULL,
    [RutaStatus] BIT           NULL,
    PRIMARY KEY CLUSTERED ([IdRuta] ASC)
);

