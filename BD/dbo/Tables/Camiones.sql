CREATE TABLE [dbo].[Camiones] (
    [CamionID]       INT           IDENTITY (1, 1) NOT NULL,
    [CamionCode]     VARCHAR (5)   NULL,
    [CamionName]     VARCHAR (100) NULL,
    [CamionPlaca]    VARCHAR (10)  NULL,
    [CamionPesaje]   VARCHAR (50)  NULL,
    [CamionCreacion] DATETIME      NULL,
    [CamionUpdate]   DATETIME      NULL,
    [CamionDelete]   DATETIME      NULL,
    [CamionStatus]   INT           NULL,
    CONSTRAINT [PK__Camiones__80E86F48460A709E] PRIMARY KEY CLUSTERED ([CamionID] ASC)
);

