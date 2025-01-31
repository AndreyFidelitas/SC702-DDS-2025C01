CREATE TABLE [dbo].[Usuarios] (
    [UsuarioID]        INT           IDENTITY (1, 1) NOT NULL,
    [UsuarioCode]      VARCHAR (5)   NULL,
    [UsuarioName]      VARCHAR (100) NULL,
    [UsuarioApellidos] VARCHAR (100) NULL,
    [UsuarioUserName]  VARCHAR (100) NULL,
    [Password]         VARCHAR (100) NULL,
    [token]            VARCHAR (255) NULL,
    [RoleID]           INT           NOT NULL,
    [UsuarioCreacion]  DATETIME      NULL,
    [UsuarioUpdate]    DATETIME      NULL,
    [UsuarioDelete]    DATETIME      NULL,
    [UsuarioEstado]    BIT           NULL,
    CONSTRAINT [PK__Usuarios__2B3DE7985455D719] PRIMARY KEY CLUSTERED ([UsuarioID] ASC),
    CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([RolesId])
);







