IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovieUserRatings]') AND type in (N'U'))
ALTER TABLE [dbo].[MovieUserRatings] DROP CONSTRAINT IF EXISTS [FK_User_MovieUserRatings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovieUserRatings]') AND type in (N'U'))
ALTER TABLE [dbo].[MovieUserRatings] DROP CONSTRAINT IF EXISTS [FK_Rating_MovieUserRatings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovieUserRatings]') AND type in (N'U'))
ALTER TABLE [dbo].[MovieUserRatings] DROP CONSTRAINT IF EXISTS [FK_Movies_MovieGenres]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovieGenres]') AND type in (N'U'))
ALTER TABLE [dbo].[MovieGenres] DROP CONSTRAINT IF EXISTS [FK_Movies_MovieUserRatings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MovieGenres]') AND type in (N'U'))
ALTER TABLE [dbo].[MovieGenres] DROP CONSTRAINT IF EXISTS [FK_Genres_MovieGenres]
GO
/****** Object:  Index [UK_MovieUserRatings_MovieId_UserId_RatingId]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP INDEX IF EXISTS [UK_MovieUserRatings_MovieId_UserId_RatingId] ON [dbo].[MovieUserRatings]
GO
/****** Object:  Index [UK_MovieGenres_MovieId_GenreID]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP INDEX IF EXISTS [UK_MovieGenres_MovieId_GenreID] ON [dbo].[MovieGenres]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP TABLE IF EXISTS [dbo].[User]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP TABLE IF EXISTS [dbo].[Ratings]
GO
/****** Object:  Table [dbo].[MovieUserRatings]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP TABLE IF EXISTS [dbo].[MovieUserRatings]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP TABLE IF EXISTS [dbo].[Movies]
GO
/****** Object:  Table [dbo].[MovieGenres]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP TABLE IF EXISTS [dbo].[MovieGenres]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP TABLE IF EXISTS [dbo].[Genres]
GO
/****** Object:  Database [MoviesApp]    Script Date: 9/5/2021 3:07:47 PM ******/
DROP DATABASE IF EXISTS [MoviesApp]
GO
/****** Object:  Database [MoviesApp]    Script Date: 9/5/2021 3:07:47 PM ******/
CREATE DATABASE [MoviesApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoviesApp', FILENAME = N'C:\Users\vamsi\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MoviesApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoviesApp_log', FILENAME = N'C:\Users\vamsi\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\MoviesApp.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MoviesApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoviesApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MoviesApp] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [MoviesApp] SET ANSI_NULLS ON 
GO
ALTER DATABASE [MoviesApp] SET ANSI_PADDING ON 
GO
ALTER DATABASE [MoviesApp] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [MoviesApp] SET ARITHABORT ON 
GO
ALTER DATABASE [MoviesApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MoviesApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MoviesApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MoviesApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MoviesApp] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [MoviesApp] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [MoviesApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MoviesApp] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [MoviesApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MoviesApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MoviesApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MoviesApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MoviesApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MoviesApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MoviesApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MoviesApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MoviesApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MoviesApp] SET RECOVERY FULL 
GO
ALTER DATABASE [MoviesApp] SET  MULTI_USER 
GO
ALTER DATABASE [MoviesApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MoviesApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MoviesApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MoviesApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MoviesApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MoviesApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MoviesApp] SET QUERY_STORE = OFF
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 9/5/2021 3:07:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieGenres]    Script Date: 9/5/2021 3:07:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieGenres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 9/5/2021 3:07:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[YearOfRelease] [int] NOT NULL,
	[RunningTime] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieUserRatings]    Script Date: 9/5/2021 3:07:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieUserRatings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RatingId] [int] NOT NULL,
	[MovieID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 9/5/2021 3:07:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/5/2021 3:07:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Action')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Comedy')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Drama')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Fantasy')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Horror')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (6, N'Mystery')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (7, N'Thriller')
GO
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[MovieGenres] ON 
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (7, 1, 1)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (29, 1, 6)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (8, 1, 7)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (9, 2, 5)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (10, 3, 2)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (11, 4, 7)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (12, 5, 4)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (13, 6, 5)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (14, 6, 7)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (15, 7, 5)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (16, 7, 7)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (17, 8, 5)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (19, 8, 6)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (18, 8, 7)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (24, 9, 2)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (23, 9, 3)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (25, 9, 6)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (20, 10, 5)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (22, 10, 6)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (21, 10, 7)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (31, 11, 2)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (26, 11, 4)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (32, 11, 6)
GO
SET IDENTITY_INSERT [dbo].[MovieGenres] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (1, N'Avengers: End Game', 2020, 9600)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (2, N'Conjuring 3', 2021, 11000)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (3, N'Yes Day', 2020, 9500)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (4, N'Hush', 2019, 9600)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (5, N'Luca', 2021, 9600)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (6, N'Conjuring', 2015, 9600)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (7, N'Conjuring 2', 2019, 9606)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (8, N'Facebook', 2020, 9613)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (9, N'The Terminal', 2004, 9616)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (10, N'Insidious', 2011, 9617)
GO
INSERT [dbo].[Movies] ([Id], [Title], [YearOfRelease], [RunningTime]) VALUES (11, N'Jungle cruise', 2021, 9609)
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[MovieUserRatings] ON 
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (13, 1, 1, 5)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (5, 2, 2, 3)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (4, 2, 3, 2)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (3, 2, 4, 1)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (49, 2, 5, 6)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (7, 3, 2, 2)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (6, 3, 2, 3)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (8, 3, 2, 4)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (29, 5, 1, 9)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (14, 5, 2, 6)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (44, 5, 2, 11)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (24, 5, 3, 8)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (34, 5, 4, 10)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (19, 5, 5, 7)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (25, 6, 1, 8)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (30, 6, 1, 9)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (15, 6, 3, 6)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (20, 6, 3, 7)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (35, 6, 5, 10)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (45, 6, 5, 11)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (21, 7, 1, 7)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (26, 7, 1, 8)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (16, 7, 2, 6)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (31, 7, 2, 9)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (46, 7, 2, 11)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (36, 7, 3, 10)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (17, 8, 2, 6)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (27, 8, 2, 8)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (32, 8, 2, 9)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (47, 8, 3, 11)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (37, 8, 4, 10)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (22, 8, 5, 7)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (38, 9, 1, 10)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (48, 9, 1, 11)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (18, 9, 2, 6)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (28, 9, 2, 8)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (33, 9, 2, 9)
GO
INSERT [dbo].[MovieUserRatings] ([Id], [UserId], [RatingId], [MovieID]) VALUES (23, 9, 4, 7)
GO
SET IDENTITY_INSERT [dbo].[MovieUserRatings] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 
GO
INSERT [dbo].[Ratings] ([Id], [Value]) VALUES (1, 1)
GO
INSERT [dbo].[Ratings] ([Id], [Value]) VALUES (2, 2)
GO
INSERT [dbo].[Ratings] ([Id], [Value]) VALUES (3, 3)
GO
INSERT [dbo].[Ratings] ([Id], [Value]) VALUES (4, 4)
GO
INSERT [dbo].[Ratings] ([Id], [Value]) VALUES (5, 5)
GO
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (1, N'Ronaldo', N'Desouza')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (2, N'Free', N'Will')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (3, N'Vamsi', N'Dogiparthi')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (4, N'Robert', N'D')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (5, N'Batman', N'hero')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (6, N'Cap', N'Man')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (7, N'CapMan', N'Rolace')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (8, N'FreeWill', N'Comcast')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (9, N'Vamsi', N'Krishna')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (10, N'Ronaldo', N'Desouza')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName]) VALUES (11, N'Kurt', N'Eldridge')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [UK_MovieGenres_MovieId_GenreID]    Script Date: 9/5/2021 3:07:47 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_MovieGenres_MovieId_GenreID] ON [dbo].[MovieGenres]
(
	[MovieId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_MovieUserRatings_MovieId_UserId_RatingId]    Script Date: 9/5/2021 3:07:47 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_MovieUserRatings_MovieId_UserId_RatingId] ON [dbo].[MovieUserRatings]
(
	[UserId] ASC,
	[RatingId] ASC,
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MovieGenres]  WITH CHECK ADD  CONSTRAINT [FK_Genres_MovieGenres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[MovieGenres] CHECK CONSTRAINT [FK_Genres_MovieGenres]
GO
ALTER TABLE [dbo].[MovieGenres]  WITH CHECK ADD  CONSTRAINT [FK_Movies_MovieUserRatings] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieGenres] CHECK CONSTRAINT [FK_Movies_MovieUserRatings]
GO
ALTER TABLE [dbo].[MovieUserRatings]  WITH CHECK ADD  CONSTRAINT [FK_Movies_MovieGenres] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieUserRatings] CHECK CONSTRAINT [FK_Movies_MovieGenres]
GO
ALTER TABLE [dbo].[MovieUserRatings]  WITH CHECK ADD  CONSTRAINT [FK_Rating_MovieUserRatings] FOREIGN KEY([RatingId])
REFERENCES [dbo].[Ratings] ([Id])
GO
ALTER TABLE [dbo].[MovieUserRatings] CHECK CONSTRAINT [FK_Rating_MovieUserRatings]
GO
ALTER TABLE [dbo].[MovieUserRatings]  WITH CHECK ADD  CONSTRAINT [FK_User_MovieUserRatings] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[MovieUserRatings] CHECK CONSTRAINT [FK_User_MovieUserRatings]
GO
ALTER DATABASE [MoviesApp] SET  READ_WRITE 
GO
