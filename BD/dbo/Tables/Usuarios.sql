CREATE TABLE [dbo].[Usuarios] (
    [UsuarioID]        INT           IDENTITY (1, 1) NOT NULL,
    [UsuarioCode]      VARCHAR (5)   NULL,
    [UsuarioName]      VARCHAR (100) NULL,
    [UsuarioApellidos] VARCHAR (100) NULL,
    [UsuarioUserName]  VARCHAR (100) NULL,
    [Password]         VARCHAR (100) NULL,
    [token]            VARCHAR (255) NULL,
    [UsuarioCreacion]  DATETIME      NULL,
    [UsuarioUpdate]    DATETIME      NULL,
    [UsuarioDelete]    DATETIME      NULL,
    [UsuarioEstado]    BIT           NULL,
    PRIMARY KEY CLUSTERED ([UsuarioID] ASC)
);

