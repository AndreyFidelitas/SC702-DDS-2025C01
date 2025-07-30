CREATE TABLE [dbo].[LogEventos] (
    [LogID]         INT           IDENTITY (1, 1) NOT NULL,
    [FechaEvento]   DATETIME      CONSTRAINT [DF__LogEvento__Fecha__67DE6983] DEFAULT (getdate()) NULL,
    [UsuarioID]     INT           NULL,
    [TablaAfectada] VARCHAR (100) NULL,
    [Modulo]        VARCHAR (100) NULL,
    [Detalles]      VARCHAR (MAX) NULL,
    CONSTRAINT [PK__LogEvent__5E5499A8E60E77B8] PRIMARY KEY CLUSTERED ([LogID] ASC),
    CONSTRAINT [FK_LogEventos_Usuarios] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuarios] ([UsuarioID])
);
GO

