USE [Test7]
GO
/****** Object:  Table [dbo].[GameGenre]    Script Date: 13.10.2021 12:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameGenre](
	[GenresTableID] [int] NOT NULL,
	[GamesTableID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GamesTable]    Script Date: 13.10.2021 12:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GamesTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameGame] [nvarchar](50) NOT NULL,
	[NameStudio] [nvarchar](50) NOT NULL,
	[RelizeDate] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenresTable]    Script Date: 13.10.2021 12:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenresTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameGenres] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[GameGenre]  WITH CHECK ADD  CONSTRAINT [FK_GameGenre_Games] FOREIGN KEY([GamesTableID])
REFERENCES [dbo].[GamesTable] ([ID])
GO
ALTER TABLE [dbo].[GameGenre] CHECK CONSTRAINT [FK_GameGenre_Games]
GO
ALTER TABLE [dbo].[GameGenre]  WITH CHECK ADD  CONSTRAINT [FK_GameGenre_Genres] FOREIGN KEY([GenresTableID])
REFERENCES [dbo].[GenresTable] ([ID])
GO
ALTER TABLE [dbo].[GameGenre] CHECK CONSTRAINT [FK_GameGenre_Genres]
GO
