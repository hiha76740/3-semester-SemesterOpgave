use AccomodationDB

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
CREATE TABLE [Accomodations] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [HostId] uniqueidentifier NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [ImageFileName] nvarchar(max) NULL,
    [Address] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Accomodations] PRIMARY KEY ([Id])
);

CREATE TABLE [Facilities] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Facilities] PRIMARY KEY ([Id])
);

CREATE TABLE [Listings] (
    [Id] uniqueidentifier NOT NULL,
    [AccomodationId] uniqueidentifier NOT NULL,
    [ListingName] nvarchar(max) NOT NULL,
    [DailyPrice] decimal(18,2) NOT NULL,
    [HouseRules] nvarchar(max) NOT NULL,
    [Type] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [ImageFileName] nvarchar(max) NULL,
    [RowVersion] rowversion NOT NULL,
    CONSTRAINT [PK_Listings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Listings_Accomodations_AccomodationId] FOREIGN KEY ([AccomodationId]) REFERENCES [Accomodations] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AccommodationFacilities] (
    [AccomodationId] uniqueidentifier NOT NULL,
    [facilitiesId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AccommodationFacilities] PRIMARY KEY ([AccomodationId], [facilitiesId]),
    CONSTRAINT [FK_AccommodationFacilities_Accomodations_AccomodationId] FOREIGN KEY ([AccomodationId]) REFERENCES [Accomodations] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccommodationFacilities_Facilities_facilitiesId] FOREIGN KEY ([facilitiesId]) REFERENCES [Facilities] ([Id]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Facilities]'))
    SET IDENTITY_INSERT [Facilities] ON;
INSERT INTO [Facilities] ([Id], [Name])
VALUES ('0fb02b10-29ea-4616-83d8-5e7870e24c3f', N'Hot Tub'),
('1d4d28b2-edc2-4aaa-be9e-e855f4dd7cd3', N'Grill'),
('1eff118c-87f2-45f6-8f1e-2a4ce1f1ccff', N'Opvaskemaskine'),
('35ae0b5a-36cf-4242-a7f3-f10a616e6626', N'TV'),
('389ee76d-5478-43a4-a5f9-94a9f8133eb9', N'Pool'),
('420dedfe-0bed-40ab-b036-63fbe52fbbab', N'EV Lader'),
('68a14b26-15d6-4831-a876-221b01260c6b', N'Wifi'),
('6f95b1bd-1039-493b-b681-b1da44d949f8', N'Tørretumbler'),
('a5d70bf0-67d1-4a14-bf0b-2857d3307e11', N'Vaskemaskine'),
('ab46c03f-4440-4ef9-8137-9dc09f82b94c', N'Air Conditioning'),
('f595c2a6-13b0-438c-bc63-c08fff41ddc4', N'Gym');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Facilities]'))
    SET IDENTITY_INSERT [Facilities] OFF;

CREATE INDEX [IX_AccommodationFacilities_facilitiesId] ON [AccommodationFacilities] ([facilitiesId]);

CREATE INDEX [IX_Listings_AccomodationId] ON [Listings] ([AccomodationId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261022080118_Initial', N'10.0.13');

COMMIT;
GO

