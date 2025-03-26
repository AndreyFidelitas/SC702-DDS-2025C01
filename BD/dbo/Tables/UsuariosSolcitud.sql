CREATE TABLE [dbo].[UsuariosSolcitud] (
    [SolicitudID]      INT           IDENTITY (1, 1) NOT NULL,
    [SolicitudCode]    VARCHAR (5)   NULL,
    [Cedula]           INT           NOT NULL,
    [Name]             VARCHAR (100) NOT NULL,
    [Apellidos]        VARCHAR (100) NOT NULL,
    [SolcitudAceptada] DATETIME      NULL,
    [SolcitudRechaza]  DATETIME      NULL,
    [SolcitudEstado]   BIT           NULL,
    [UsuarioID]        INT           NULL,
    CONSTRAINT [PK__Usuarios__85E95DA7BB484BBC] PRIMARY KEY CLUSTERED ([SolicitudID] ASC),
    CONSTRAINT [FK_UsuariosSolcitud_Usuarios] FOREIGN KEY ([UsuarioID]) REFERENCES [dbo].[Usuarios] ([UsuarioID])
);

