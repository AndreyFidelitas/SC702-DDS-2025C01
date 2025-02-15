CREATE TABLE [dbo].[Rutas] (
    [IdRuta]     INT           IDENTITY (1, 1) NOT NULL,
    [RutaCode]   VARCHAR (5)   NOT NULL,
    [Ruta]       VARCHAR (100) NOT NULL,
    [RutaStatus] BIT           NOT NULL,
    CONSTRAINT [PK__Rutas__887538FE9468F749] PRIMARY KEY CLUSTERED ([IdRuta] ASC)
);



