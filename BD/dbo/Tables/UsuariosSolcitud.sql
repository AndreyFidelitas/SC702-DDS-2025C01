CREATE TABLE [dbo].[UsuariosSolcitud] (
    [SolicitudID]      INT           IDENTITY (1, 1) NOT NULL,
    [Cedula]           INT           NULL,
    [Name]             VARCHAR (100) NULL,
    [Apellidos]        VARCHAR (100) NULL,
    [SolcitudAceptada] DATETIME      NULL,
    [SolcitudRechaza]  DATETIME      NULL,
    [SolcitudEstado]   BIT           NULL,
    [UsuarioID]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([SolicitudID] ASC),
    CONSTRAINT [FK_UsuariosSolcitud_Usuarios] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuarios] ([UsuarioID])
);

