CREATE TABLE [dbo].[Contas] (
    [Id]            INT   IDENTITY (1, 1) NOT NULL,
    [CorrentistaId] INT   NOT NULL,
    [LimiteCredito] MONEY NOT NULL,
    [Saldo]         MONEY NOT NULL,
    [DataAbertura]  DATE  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CORRENTISTA_CONTA] FOREIGN KEY ([CorrentistaId]) REFERENCES [dbo].[Correntistas] ([Id])
);
