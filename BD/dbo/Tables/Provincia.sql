CREATE TABLE [dbo].[Provincia] (
    [ProvinciaID]   INT           IDENTITY (1, 1) NOT NULL,
    [ProvinciaCode] VARCHAR (5)   NULL,
    [ProvinciaName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__Provinci__F7CBC757C4FEB341] PRIMARY KEY CLUSTERED ([ProvinciaID] ASC)
);

