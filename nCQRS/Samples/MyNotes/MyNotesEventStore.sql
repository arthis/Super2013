USE [master]
GO

IF exists(SELECT * FROM sys.databases WHERE name = 'MyNotesEventStore')
BEGIN
	DROP DATABASE [MyNotesEventStore]
END
GO

CREATE DATABASE [MyNotesEventStore]
GO

USE [MyNotesEventStore]
GO

CREATE TABLE [dbo].[Events]
(
	[SequentialId] [int] IDENTITY(1,1) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,

	[Name] [varchar](max) NOT NULL,
	[Version] [varchar](max) NOT NULL,

	[EventSourceId] [uniqueidentifier] NOT NULL,
	[Sequence] [bigint], 

	[Data] [nvarchar](max) NOT NULL
	CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
	(
		[SequentialId] ASC
	)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EventSources]
(
	[Id] [uniqueidentifier] NOT NULL, [Type] [nvarchar](255) NOT NULL, [Version] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Snapshots]
(
	[EventSourceId] [uniqueidentifier] NOT NULL, [Version] [bigint], [TimeStamp] [datetime] NOT NULL, 
	[Type] varchar(255) NOT NULL, [Data] [varbinary](max) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PipelineState](
	[BatchId] [int] IDENTITY(1,1) NOT NULL,
	[PipelineName] [varchar](255) NOT NULL,
	[LastProcessedEventId] [uniqueidentifier] NOT NULL,
	CONSTRAINT [PK_MainPipelineState] PRIMARY KEY CLUSTERED 
	(
		[BatchId] ASC
	)
	WITH
	(
		PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF,
		IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
		ALLOW_PAGE_LOCKS  = ON
	)
) ON [PRIMARY]
GO