BEGIN TRANSACTION;
CREATE SEQUENCE [BookingNumbers] AS int START WITH 1000 INCREMENT BY 1 NO CYCLE;

ALTER TABLE [Bookings] ADD [BookingNumber] int NOT NULL DEFAULT (NEXT VALUE FOR BookingNumbers);

CREATE UNIQUE INDEX [IX_Bookings_BookingNumber] ON [Bookings] ([BookingNumber]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261027070703_AddBookingNumber', N'10.0.13');

COMMIT;
GO

