CREATE TABLE [dbo].[TipoCilindro] (
    [TipoCilindroID]     INT          IDENTITY (1, 1) NOT NULL,
    [TipoCilindroCode]   VARCHAR (5)  NULL,
    [LoteLitraje]        VARCHAR (10) NULL,
    [TipoCilindroStatus] BIT          NULL,
    PRIMARY KEY CLUSTERED ([TipoCilindroID] ASC)
);



