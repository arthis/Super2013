


SET QUOTED_IDENTIFIER OFF;
GO
USE [Super2013];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO


/****** Object:  Table [dbo].[LastEventsReadContabilita]    Script Date: 06/26/2012 10:45:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LastEventsReadContabilita]') AND type in (N'U'))
DROP TABLE [dbo].[LastEventsReadContabilita]
GO

USE [Super2013]
GO

/****** Object:  Table [dbo].[LastEventsReadContabilita]    Script Date: 06/26/2012 10:45:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LastEventsReadContabilita](
	[CommitId] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_LastEventsReadContabilita] PRIMARY KEY CLUSTERED 
(
	[CommitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




/****** Object:  Table [dbo].[Lotto]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[Lotto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lotto];

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lotto](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[CreationDate] [datetime] NOT NULL,
	[Version] int not null,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_Lotto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




/****** Object:  Table [dbo].[Impianto]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[Impianto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Impianto];

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Impianto](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_Impianto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




/****** Object:  Table [dbo].[TipoIntervento]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[TipoIntervento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoIntervento];

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoIntervento](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_TipoIntervento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]









-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------