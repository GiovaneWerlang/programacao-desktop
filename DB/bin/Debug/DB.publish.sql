﻿/*
Deployment script for TERMINALPD25S

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TERMINALPD25S"
:setvar DefaultFilePrefix "TERMINALPD25S"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Creating Table [dbo].[Contas]...';


GO
CREATE TABLE [dbo].[Contas] (
    [Id]            INT   IDENTITY (1, 1) NOT NULL,
    [CorrentistaId] INT   NOT NULL,
    [LimiteCredito] MONEY NOT NULL,
    [Saldo]         MONEY NOT NULL,
    [DataAbertura]  DATE  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Correntistas]...';


GO
CREATE TABLE [dbo].[Correntistas] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [CPF]  VARCHAR (11) NOT NULL,
    [Nome] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Lançamentos]...';


GO
CREATE TABLE [dbo].[Lançamentos] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Data]      DATE         NOT NULL,
    [ContaId]   INT          NOT NULL,
    [Operacao]  INT          NOT NULL,
    [Historico] VARCHAR (50) NULL,
    [Valor]     MONEY        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_CORRENTISTA_CONTA]...';


GO
ALTER TABLE [dbo].[Contas] WITH NOCHECK
    ADD CONSTRAINT [FK_CORRENTISTA_CONTA] FOREIGN KEY ([CorrentistaId]) REFERENCES [dbo].[Correntistas] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_CONTA_LANCAMENTO]...';


GO
ALTER TABLE [dbo].[Lançamentos] WITH NOCHECK
    ADD CONSTRAINT [FK_CONTA_LANCAMENTO] FOREIGN KEY ([ContaId]) REFERENCES [dbo].[Contas] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Contas] WITH CHECK CHECK CONSTRAINT [FK_CORRENTISTA_CONTA];

ALTER TABLE [dbo].[Lançamentos] WITH CHECK CHECK CONSTRAINT [FK_CONTA_LANCAMENTO];


GO
PRINT N'Update complete.';


GO
