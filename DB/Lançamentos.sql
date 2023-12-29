CREATE TABLE [dbo].[Lançamentos] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Data]      DATE         NOT NULL,
    [ContaId]   INT          NOT NULL,
    [Operacao]  INT          NOT NULL,
    [Historico] VARCHAR (50) NULL,
    [Valor]     MONEY        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CONTA_LANCAMENTO] FOREIGN KEY ([ContaId]) REFERENCES [dbo].[Contas] ([Id])
);
