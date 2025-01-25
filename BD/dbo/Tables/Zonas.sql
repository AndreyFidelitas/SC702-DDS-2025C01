CREATE TABLE [dbo].[Zonas] (
    [ZonasID]       INT           IDENTITY (1, 1) NOT NULL,
    [ProvinciaID]   INT           NULL,
    [ZonasCode]     VARCHAR (5)   NOT NULL,
    [ZonasName]     VARCHAR (100) NOT NULL,
    [ZonasCreacion] DATETIME      NULL,
    [ZonasUpdate]   DATETIME      NULL,
    [ZonasDelete]   DATETIME      NULL,
    [ZonasEstado]   BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ZonasID] ASC),
    FOREIGN KEY ([ProvinciaID]) REFERENCES [dbo].[Provincia] ([ProvinciaID])
);

