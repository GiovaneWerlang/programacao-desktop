CREATE TABLE [dbo].[Correntistas] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [CPF]  VARCHAR (11) NOT NULL,
    [Nome] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);