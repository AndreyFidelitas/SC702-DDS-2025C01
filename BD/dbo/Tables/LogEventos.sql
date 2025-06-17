CREATE TABLE [dbo].[LogEventos] (
    [LogID]         INT            IDENTITY (1, 1) NOT NULL,
    [FechaEvento]   DATETIME       DEFAULT (getdate()) NULL,
    [UsuarioID]     INT            NOT NULL,
    [TablaAfectada] VARCHAR (100)  NULL,
    [Modulo]        VARCHAR (100)  NULL,
    [Detalles]      NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([LogID] ASC),
    CONSTRAINT [FK_LogEventos_Usuarios] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuarios] ([UsuarioID])
);

