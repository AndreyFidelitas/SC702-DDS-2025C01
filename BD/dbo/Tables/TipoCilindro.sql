CREATE TABLE [dbo].[TipoCilindro] (
    [TipoCilindroID]   INT           IDENTITY (1, 1) NOT NULL,
    [TipoCilindroCode] VARCHAR (5)   NULL,
    [TipoCilindroName] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([TipoCilindroID] ASC)
);

