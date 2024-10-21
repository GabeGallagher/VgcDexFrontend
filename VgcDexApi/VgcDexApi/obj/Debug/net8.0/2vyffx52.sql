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

CREATE TABLE [Tournaments] (
    [Id] int NOT NULL IDENTITY,
    [Division] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Date] datetime2 NOT NULL,
    [Platform] int NOT NULL,
    [Players] int NOT NULL,
    [Regulation] int NOT NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_Tournaments] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241019230109_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

