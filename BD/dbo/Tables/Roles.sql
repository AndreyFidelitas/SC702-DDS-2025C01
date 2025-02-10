CREATE TABLE [dbo].[Roles] (
    [RolesId]    INT           IDENTITY (1, 1) NOT NULL,
    [RoleCode]   VARCHAR (5)   NOT NULL,
    [RoleName]   VARCHAR (100) NOT NULL,
    [RoleStatus] BIT           NULL,
    CONSTRAINT [PK__Roles__C4B27840F134CA87] PRIMARY KEY CLUSTERED ([RolesId] ASC)
);



