


SET QUOTED_IDENTIFIER OFF;
GO
USE [Super2013];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO





/****** Object:  Table [dbo].[AreaIntervento]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[AreaIntervento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AreaIntervento];

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AreaIntervento](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_AreaIntervento] PRIMARY KEY CLUSTERED 
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