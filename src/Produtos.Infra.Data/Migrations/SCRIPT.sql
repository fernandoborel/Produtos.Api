IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Produto] (
    [IDPRODUTO] uniqueidentifier NOT NULL,
    [NOME] nvarchar(150) NOT NULL,
    [PRECO] decimal(18,2) NOT NULL,
    [QUANTIDADE] int NOT NULL,
    [DATACRIACAO] datetime2 NOT NULL,
    [DATAULTIMAALTERACAO] datetime2 NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([IDPRODUTO])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240130141941_Initial', N'8.0.1');
GO

COMMIT;
GO

