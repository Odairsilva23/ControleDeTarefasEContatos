CREATE TABLE [dbo].[TBcontatos] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (100) NULL,
    [Email]    VARCHAR (200) NULL,
    [Telefone] VARCHAR (50)  NULL,
    [Empresa]  VARCHAR (100) NULL,
    [Cargo]    VARCHAR (100) NULL,
    CONSTRAINT [PK_TBcontatos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

