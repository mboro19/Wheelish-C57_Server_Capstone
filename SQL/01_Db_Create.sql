CREATE TABLE [Vehicles] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [VehicleMake] nvarchar(255) NOT NULL,
  [VehicleModel] nvarchar(255) NOT NULL,
  [VehicleYear] int NOT NULL,
  [BodyStyleId] int NOT NULL
)
GO

CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserName] nvarchar(255) NOT NULL,
  [UserAddress] nvarchar(255) NOT NULL,
  [UserCity] nvarchar(255) NOT NULL,
  [UserState] nvarchar(255) NOT NULL,
  [UserZip] int NOT NULL,
  [UserPhone] nvarchar(255) NOT NULL,
  [UserEmail] nvarchar(255) NOT NULL,
  [FirebaseUserId] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [UserVehicles] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [VehicleId] int NOT NULL,
  [UserId] int NOT NULL,
  [VehicleMiles] int NOT NULL,
  [VehicleCost] float NOT NULL,
  [IsVehicleAvailable] bit NOT NULL
)
GO

CREATE TABLE [BodyStyle] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [BodyStyleName] nvarchar(255) NOT NULL
)
GO

ALTER TABLE [UserVehicles] ADD FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id])
GO

ALTER TABLE [UserVehicles] ADD FOREIGN KEY ([UserId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Vehicles] ADD FOREIGN KEY ([BodyStyleId]) REFERENCES [BodyStyle] ([Id])
GO
