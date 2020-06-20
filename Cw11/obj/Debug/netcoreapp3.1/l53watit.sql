IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Doctor] (
    [IdDoctor] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Doctor] PRIMARY KEY ([IdDoctor])
);

GO

CREATE TABLE [Medicament] (
    [IdMedicament] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Type] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Medicament] PRIMARY KEY ([IdMedicament])
);

GO

CREATE TABLE [Patient] (
    [IdPatient] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Birthdate] datetime2 NOT NULL,
    CONSTRAINT [PK_Patient] PRIMARY KEY ([IdPatient])
);

GO

CREATE TABLE [Prescription] (
    [IdPrescription] int NOT NULL IDENTITY,
    [Date] datetime2 NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [IdPatient] int NOT NULL,
    [IdDoctor] int NOT NULL,
    CONSTRAINT [PK_Prescription] PRIMARY KEY ([IdPrescription]),
    CONSTRAINT [FK_Prescription_Doctor_IdDoctor] FOREIGN KEY ([IdDoctor]) REFERENCES [Doctor] ([IdDoctor]) ON DELETE CASCADE,
    CONSTRAINT [FK_Prescription_Patient_IdPatient] FOREIGN KEY ([IdPatient]) REFERENCES [Patient] ([IdPatient]) ON DELETE CASCADE
);

GO

CREATE TABLE [Prescription_Medicament] (
    [IdMedicament] int NOT NULL,
    [IdPrescription] int NOT NULL,
    [Dose] int NOT NULL,
    [Details] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Prescription_Medicament] PRIMARY KEY ([IdPrescription], [IdMedicament]),
    CONSTRAINT [FK_Prescription_Medicament_Medicament_IdMedicament] FOREIGN KEY ([IdMedicament]) REFERENCES [Medicament] ([IdMedicament]) ON DELETE CASCADE,
    CONSTRAINT [FK_Prescription_Medicament_Prescription_IdPrescription] FOREIGN KEY ([IdPrescription]) REFERENCES [Prescription] ([IdPrescription]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Prescription_IdDoctor] ON [Prescription] ([IdDoctor]);

GO

CREATE INDEX [IX_Prescription_IdPatient] ON [Prescription] ([IdPatient]);

GO

CREATE INDEX [IX_Prescription_Medicament_IdMedicament] ON [Prescription_Medicament] ([IdMedicament]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200524114521_AddTables', N'3.1.3');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdDoctor', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Doctor]'))
    SET IDENTITY_INSERT [Doctor] ON;
INSERT INTO [Doctor] ([IdDoctor], [Email], [FirstName], [LastName])
VALUES (1, N'xxx@gmail.com', N'Jan', N'Kowalski'),
(2, N'yyy@gmail.com', N'Ala', N'Nowak');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdDoctor', N'Email', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Doctor]'))
    SET IDENTITY_INSERT [Doctor] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'Description', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Medicament]'))
    SET IDENTITY_INSERT [Medicament] ON;
INSERT INTO [Medicament] ([IdMedicament], [Description], [Name], [Type])
VALUES (1, N'Lorem...', N'Acerin', N'Płyn'),
(2, N'Lorem ipsum...', N'Xanax', N'Depression');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMedicament', N'Description', N'Name', N'Type') AND [object_id] = OBJECT_ID(N'[Medicament]'))
    SET IDENTITY_INSERT [Medicament] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPatient', N'Birthdate', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Patient]'))
    SET IDENTITY_INSERT [Patient] ON;
INSERT INTO [Patient] ([IdPatient], [Birthdate], [FirstName], [LastName])
VALUES (1, '1998-01-21T00:00:00.0000000', N'Monika', N'Nowakowska'),
(2, '1980-08-03T00:00:00.0000000', N'Tomasz', N'Maliszewski');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPatient', N'Birthdate', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Patient]'))
    SET IDENTITY_INSERT [Patient] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'Date', N'DueDate', N'IdDoctor', N'IdPatient') AND [object_id] = OBJECT_ID(N'[Prescription]'))
    SET IDENTITY_INSERT [Prescription] ON;
INSERT INTO [Prescription] ([IdPrescription], [Date], [DueDate], [IdDoctor], [IdPatient])
VALUES (1, '2020-01-01T00:00:00.0000000', '2020-11-01T00:00:00.0000000', 1, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'Date', N'DueDate', N'IdDoctor', N'IdPatient') AND [object_id] = OBJECT_ID(N'[Prescription]'))
    SET IDENTITY_INSERT [Prescription] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'Date', N'DueDate', N'IdDoctor', N'IdPatient') AND [object_id] = OBJECT_ID(N'[Prescription]'))
    SET IDENTITY_INSERT [Prescription] ON;
INSERT INTO [Prescription] ([IdPrescription], [Date], [DueDate], [IdDoctor], [IdPatient])
VALUES (2, '2020-04-01T00:00:00.0000000', '2020-12-01T00:00:00.0000000', 2, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'Date', N'DueDate', N'IdDoctor', N'IdPatient') AND [object_id] = OBJECT_ID(N'[Prescription]'))
    SET IDENTITY_INSERT [Prescription] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'IdMedicament', N'Details', N'Dose') AND [object_id] = OBJECT_ID(N'[Prescription_Medicament]'))
    SET IDENTITY_INSERT [Prescription_Medicament] ON;
INSERT INTO [Prescription_Medicament] ([IdPrescription], [IdMedicament], [Details], [Dose])
VALUES (1, 1, N'Once a week', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPrescription', N'IdMedicament', N'Details', N'Dose') AND [object_id] = OBJECT_ID(N'[Prescription_Medicament]'))
    SET IDENTITY_INSERT [Prescription_Medicament] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200524115033_AddData', N'3.1.3');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Doctor]') AND [c].[name] = N'Email');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Doctor] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Doctor] ALTER COLUMN [Email] nvarchar(max) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200524125945_ModifyTables', N'3.1.3');

GO

