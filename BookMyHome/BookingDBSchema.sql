use BookingDB

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
CREATE TABLE [Bookings] (
    [Id] uniqueidentifier NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [GuestId] uniqueidentifier NOT NULL,
    [AccomodationId] uniqueidentifier NOT NULL,
    [ListingId] uniqueidentifier NOT NULL,
    [EndDate] date NOT NULL,
    [StartDate] date NOT NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261022080156_Initial', N'10.0.13');

COMMIT;
GO

