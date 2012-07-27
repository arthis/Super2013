


SET QUOTED_IDENTIFIER OFF;
GO
USE [Super2013.Contabilita.ReadStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO


/****** Object:  Table [dbo].[LastEventsReadContabilita]    Script Date: 06/26/2012 10:45:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LastEventsReadContabilita]') AND type in (N'U'))
DROP TABLE [dbo].[LastEventsReadContabilita]
GO

USE [Super2013.Contabilita.ReadStore]
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

/****** Object:  Table [dbo].[TipoInterventoRot]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[CategoriaCommerciale]', 'U') IS NOT NULL
    DROP TABLE [dbo].CategoriaCommerciale;

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].CategoriaCommerciale(
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_CategoriaCommerciale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[TipoInterventoRot]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[Committente]', 'U') IS NOT NULL
    DROP TABLE [dbo].Committente;

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].Committente(
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_Committente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[TipoInterventoRot]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[Appaltatore]', 'U') IS NOT NULL
    DROP TABLE [dbo].Appaltatore;

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].Appaltatore(
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Sign] [nvarchar](10) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_Appaltatore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[TipoInterventoRot]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[DirezioneRegionale]', 'U') IS NOT NULL
    DROP TABLE [dbo].DirezioneRegionale;

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].DirezioneRegionale(
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_DirezioneRegionale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[TipoInterventoRot]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[MeasuringUnit]', 'U') IS NOT NULL
    DROP TABLE [dbo].MeasuringUnit;

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].MeasuringUnit(
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_MeasuringUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[PeriodoProgrammazione]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[PeriodoProgrammazione]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodoProgrammazione];

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PeriodoProgrammazione](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[Settore] [nvarchar](50) NULL,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_PeriodoProgrammazione] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[TipoInterventoRot]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[TipoInterventoRot]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoInterventoRot];

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoInterventoRot](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Mnemo] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[AiTreni] bit not null,
	[CalcoloDetrazioni] bit not null,
	[Classe] char not null,
	[IdMeasuringUnit] [uniqueidentifier] not null,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_TipoInterventoRot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[TipoInterventoRotMan]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[TipoInterventoRotMan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoInterventoRotMan];

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoInterventoRotMan](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Mnemo] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[IdMeasuringUnit] [uniqueidentifier] not null,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_TipoInterventoRotMan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[TipoInterventoAmb]    Script Date: 02/02/2012 14:53:43 ******/
IF OBJECT_ID(N'[dbo].[TipoInterventoAmb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoInterventoAmb];

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoInterventoAmb](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Mnemo] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[IdMeasuringUnit] [uniqueidentifier] not null,
	[Version] int not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_TipoInterventoAmb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]









-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------