CREATE TABLE [Movies] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Title] NVARCHAR(250) NOT NULL,
  [YearOfRelease] int NOT NULL,
  [RunningTime] bigint NOT NULL
)
GO

CREATE TABLE [User] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirstName] NVARCHAR(250) NOT NULL,
  [LastName] NVARCHAR(250) NOT NULL
)
GO

CREATE TABLE [Genres] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(250) NOT NULL
)
GO

CREATE TABLE [Ratings] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Value] int NOT NULL
)
GO

CREATE TABLE [MovieGenres] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [MovieId] int NOT NULL,
  [GenreId] int NOT NULL
)
GO

CREATE TABLE [MovieUserRatings] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [RatingId] int NOT NULL,
  [MovieID] int NOT NULL
)
GO

ALTER TABLE [MovieUserRatings] ADD CONSTRAINT [FK_User_MovieUserRatings] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [MovieUserRatings] ADD CONSTRAINT [FK_Rating_MovieUserRatings] FOREIGN KEY ([RatingId]) REFERENCES [Ratings] ([Id])
GO

ALTER TABLE [MovieGenres] ADD CONSTRAINT [FK_Movies_MovieUserRatings] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id])
GO

ALTER TABLE [MovieGenres] ADD CONSTRAINT [FK_Genres_MovieGenres] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id])
GO

ALTER TABLE [MovieUserRatings] ADD CONSTRAINT [FK_Movies_MovieGenres] FOREIGN KEY ([MovieID]) REFERENCES [Movies] ([Id])
GO

CREATE UNIQUE INDEX [UK_MovieGenres_MovieId_GenreID] ON [MovieGenres] ("MovieId", "GenreId")
GO

CREATE UNIQUE INDEX [UK_MovieUserRatings_MovieId_UserId_RatingId] ON [MovieUserRatings] ("UserId", "RatingId", "MovieID")
GO
