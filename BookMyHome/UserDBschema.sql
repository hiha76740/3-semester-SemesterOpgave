USE UserDB;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;
CREATE TABLE `Users` (
    `Id` char(36) NOT NULL,
    `FirstName` longtext NOT NULL,
    `LastName` longtext NOT NULL,
    `Birthdate` date NOT NULL,
    `Email` varchar(255) NOT NULL,
    `Role` longtext NOT NULL,
    `Username` varchar(255) NOT NULL,
    `PasswordHash` longtext NOT NULL,
    `RefreshToken` longtext NULL,
    `RefreshTokenExpiryTime` datetime(6) NULL,
    `Address_City` longtext NOT NULL,
    `Address_PostalCode` longtext NOT NULL,
    `Address_Street` longtext NOT NULL,
    `PhoneNumber_Value` longtext NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE UNIQUE INDEX `IX_Users_Email` ON `Users` (`Email`);

CREATE UNIQUE INDEX `IX_Users_Username` ON `Users` (`Username`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20261022080227_Initial', '10.0.13');

COMMIT;

