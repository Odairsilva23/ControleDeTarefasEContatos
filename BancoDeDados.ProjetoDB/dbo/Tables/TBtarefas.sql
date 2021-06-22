CREATE TABLE [dbo].[TBtarefas] (
    [Id]                  INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]              VARCHAR (200) NULL,
    [NivelDePrioridade]   VARCHAR (50)  NULL,
    [DatadeCriacao]       DATETIME      NULL,
    [DataConclusao]       DATETIME      NULL,
    [PercentualConcluido] DECIMAL (18)  NULL,
    CONSTRAINT [PK_TBtarefas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

