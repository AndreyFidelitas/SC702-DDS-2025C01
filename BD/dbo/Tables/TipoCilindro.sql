CREATE TABLE [dbo].[TipoCilindro] (
    [TipoCilindroID]     INT          IDENTITY (1, 1) NOT NULL,
    [TipoCilindroCode]   VARCHAR(100)  NULL,
    [LoteLitraje]        VARCHAR (100) NULL,
    [TipoCilindroStatus] BIT          NULL,
    PRIMARY KEY CLUSTERED ([TipoCilindroID] ASC)
);



