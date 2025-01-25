CREATE TABLE [dbo].[Camiones] (
    [CamionID]       INT           IDENTITY (1, 1) NOT NULL,
    [CamionCode]     VARCHAR (5)   NULL,
    [CamionName]     VARCHAR (100) NULL,
    [CamionCreacion] DATETIME      NULL,
    [CamionUpdate]   DATETIME      NULL,
    [CamionDelete]   DATETIME      NULL,
    [CamionStatus]   BIT           NULL,
    PRIMARY KEY CLUSTERED ([CamionID] ASC)
);

