USE [Super2013.Programmazione.ReadStore]
GO


/****** Object:  Table [dbo].[LastEventsReadProgrammazione]    Script Date: 06/26/2012 10:45:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LastEventsReadProgrammazione]') AND type in (N'U'))
DROP TABLE [dbo].[LastEventsReadProgrammazione]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[LastEventsReadProgrammazione]    Script Date: 06/26/2012 10:45:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LastEventsReadProgrammazione](
	[CommitId] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_LastEventsReadProgrammazione] PRIMARY KEY CLUSTERED 
(
	[CommitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[Scenario]    Script Date: 07/26/2012 10:03:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scenario]') AND type in (N'U'))
DROP TABLE [dbo].[Scenario]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[Scenario]    Script Date: 07/26/2012 10:03:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Scenario](
	[IdScenario] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[IdUser] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsPromotedToPlan] [bit] NOT NULL,
	[PromotionDate] [datetime] NULL,
	[PromotingUserId] [uniqueidentifier] NULL,
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_Scenario] PRIMARY KEY CLUSTERED 
(
	[IdScenario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Plan]    Script Date: 07/26/2012 10:03:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Plan]') AND type in (N'U'))
DROP TABLE [dbo].[Plan]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[Plan]    Script Date: 07/26/2012 10:03:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Plan](
	[IdPlan] [uniqueidentifier] NOT NULL,
	[IdPromotingUser] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED 
(
	[IdPlan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[SchedulazioneRot]    Script Date: 07/26/2012 10:24:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchedulazioneRot]') AND type in (N'U'))
DROP TABLE [dbo].[SchedulazioneRot]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[SchedulazioneRot]    Script Date: 07/26/2012 10:24:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SchedulazioneRot](
	[IdSchedulazione] [uniqueidentifier] NOT NULL,
	[IdPeriodoProgrammazione] [uniqueidentifier] NOT NULL,
	[IdScenario] [uniqueidentifier] NULL,
	[IdPlan] [uniqueidentifier] NULL,
	[IdCommittente] [uniqueidentifier] NOT NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[IdImpianto] [uniqueidentifier] NOT NULL,
	[IdTipoIntervento] [uniqueidentifier] NOT NULL,
	[IdAppaltatore] [uniqueidentifier] NOT NULL,
	[IdCategoriaCommerciale] [uniqueidentifier] NOT NULL,
	[IdDirezioneRegionale] [uniqueidentifier] NOT NULL,
	[Note] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Convoglio] [nvarchar](255) NULL,
	[RigaTurnoTreno] [nvarchar](255) NULL,
	[TurnoTreno] [nvarchar](255) NULL,
	[NumeroTrenoPartenza] [nvarchar](255) NULL,
	[DateTrenoPartenza] [datetime] NULL,
	[NumeroTrenoArrivo] [nvarchar](255) NULL,
	[DateTrenoArrivo] [datetime] NULL,
 CONSTRAINT [PK_SchedulazioneRot] PRIMARY KEY CLUSTERED 
(
	[IdSchedulazione] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[SchedulazioneRotMan]    Script Date: 07/26/2012 10:24:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchedulazioneRotMan]') AND type in (N'U'))
DROP TABLE [dbo].[SchedulazioneRotMan]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[SchedulazioneRotMan]    Script Date: 07/26/2012 10:24:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SchedulazioneRotMan](
	[IdSchedulazione] [uniqueidentifier] NOT NULL,
	[IdPeriodoProgrammazione] [uniqueidentifier] NOT NULL,
	[IdScenario] [uniqueidentifier] NULL,
	[IdPlan] [uniqueidentifier] NULL,
	[IdCommittente] [uniqueidentifier] NOT NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[IdImpianto] [uniqueidentifier] NOT NULL,
	[IdTipoIntervento] [uniqueidentifier] NOT NULL,
	[IdAppaltatore] [uniqueidentifier] NOT NULL,
	[IdCategoriaCommerciale] [uniqueidentifier] NOT NULL,
	[IdDirezioneRegionale] [uniqueidentifier] NOT NULL,
	[Note] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL
 CONSTRAINT [PK_SchedulazioneRotMan] PRIMARY KEY CLUSTERED 
(
	[IdSchedulazione] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



/****** Object:  Table [dbo].[SchedulazioneAmb]    Script Date: 07/26/2012 10:24:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchedulazioneAmb]') AND type in (N'U'))
DROP TABLE [dbo].[SchedulazioneAmb]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[SchedulazioneAmb]    Script Date: 07/26/2012 10:24:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SchedulazioneAmb](
	[IdSchedulazione] [uniqueidentifier] NOT NULL,
	[IdPeriodoProgrammazione] [uniqueidentifier] NOT NULL,
	[IdScenario] [uniqueidentifier] NULL,
	[IdPlan] [uniqueidentifier] NULL,
	[IdCommittente] [uniqueidentifier] NOT NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[IdImpianto] [uniqueidentifier] NOT NULL,
	[IdTipoIntervento] [uniqueidentifier] NOT NULL,
	[IdAppaltatore] [uniqueidentifier] NOT NULL,
	[IdCategoriaCommerciale] [uniqueidentifier] NOT NULL,
	[IdDirezioneRegionale] [uniqueidentifier] NOT NULL,
	[Note] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Quantity] [int] NULL
 CONSTRAINT [PK_SchedulazioneAmb] PRIMARY KEY CLUSTERED 
(
	[IdSchedulazione] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[SchedulazioneOggettoRot]    Script Date: 07/26/2012 10:29:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchedulazioneOggettoRot]') AND type in (N'U'))
DROP TABLE [dbo].[SchedulazioneOggettoRot]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[SchedulazioneOggettoRot]    Script Date: 07/26/2012 10:29:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SchedulazioneOggettoRot](
	[IdOggettoRot] [int] IDENTITY(1,1) NOT NULL,
	[idSchedulazioneRot] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Quantity] [int] NOT NULL,
	[idTipoOggettoInterventoRot] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SchedulazioneOggettoRot] PRIMARY KEY CLUSTERED 
(
	[IdOggettoRot] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[SchedulazioneOggettoRotMan]    Script Date: 07/26/2012 10:29:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SchedulazioneOggettoRotMan]') AND type in (N'U'))
DROP TABLE [dbo].[SchedulazioneOggettoRotMan]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[SchedulazioneOggettoRotMan]    Script Date: 07/26/2012 10:29:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SchedulazioneOggettoRotMan](
	[IdOggettoRotMan] [int] IDENTITY(1,1) NOT NULL,
	[idSchedulazioneRotMan] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Quantity] [int] NOT NULL,
	[idTipoOggettoInterventoRotMan] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SchedulazioneOggettoRotMan] PRIMARY KEY CLUSTERED 
(
	[IdOggettoRotMan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[InterventoRot]    Script Date: 07/26/2012 10:24:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterventoRot]') AND type in (N'U'))
DROP TABLE [dbo].[InterventoRot]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[InterventoRot]    Script Date: 07/26/2012 10:24:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InterventoRot](
	[IdIntervento] [uniqueidentifier] NOT NULL,
	[IdPeriodoProgrammazione] [uniqueidentifier] NOT NULL,
	[IdPlan] [uniqueidentifier] NULL,
	[IdCommittente] [uniqueidentifier] NOT NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[IdImpianto] [uniqueidentifier] NOT NULL,
	[IdTipoIntervento] [uniqueidentifier] NOT NULL,
	[IdAppaltatore] [uniqueidentifier] NOT NULL,
	[IdCategoriaCommerciale] [uniqueidentifier] NOT NULL,
	[IdDirezioneRegionale] [uniqueidentifier] NOT NULL,
	[Note] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Convoglio] [nvarchar](255) NULL,
	[RigaTurnoTreno] [nvarchar](255) NULL,
	[TurnoTreno] [nvarchar](255) NULL,
	[NumeroTrenoPartenza] [nvarchar](255) NULL,
	[DateTrenoPartenza] [datetime] NULL,
	[NumeroTrenoArrivo] [nvarchar](255) NULL,
	[DateTrenoArrivo] [datetime] NULL,
 CONSTRAINT [PK_InterventoRot] PRIMARY KEY CLUSTERED 
(
	[IdIntervento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[InterventoRotMan]    Script Date: 07/26/2012 10:24:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterventoRotMan]') AND type in (N'U'))
DROP TABLE [dbo].[InterventoRotMan]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[InterventoRotMan]    Script Date: 07/26/2012 10:24:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InterventoRotMan](
	[IdIntervento] [uniqueidentifier] NOT NULL,
	[IdPeriodoProgrammazione] [uniqueidentifier] NOT NULL,
	[IdPlan] [uniqueidentifier] NULL,
	[IdCommittente] [uniqueidentifier] NOT NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[IdImpianto] [uniqueidentifier] NOT NULL,
	[IdTipoIntervento] [uniqueidentifier] NOT NULL,
	[IdAppaltatore] [uniqueidentifier] NOT NULL,
	[IdCategoriaCommerciale] [uniqueidentifier] NOT NULL,
	[IdDirezioneRegionale] [uniqueidentifier] NOT NULL,
	[Note] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL
 CONSTRAINT [PK_InterventoRotMan] PRIMARY KEY CLUSTERED 
(
	[IdIntervento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



/****** Object:  Table [dbo].[InterventoAmb]    Script Date: 07/26/2012 10:24:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterventoAmb]') AND type in (N'U'))
DROP TABLE [dbo].[InterventoAmb]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[InterventoAmb]    Script Date: 07/26/2012 10:24:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InterventoAmb](
	[IdIntervento] [uniqueidentifier] NOT NULL,
	[IdPeriodoProgrammazione] [uniqueidentifier] NOT NULL,
	[IdPlan] [uniqueidentifier] NULL,
	[IdCommittente] [uniqueidentifier] NOT NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[IdImpianto] [uniqueidentifier] NOT NULL,
	[IdTipoIntervento] [uniqueidentifier] NOT NULL,
	[IdAppaltatore] [uniqueidentifier] NOT NULL,
	[IdCategoriaCommerciale] [uniqueidentifier] NOT NULL,
	[IdDirezioneRegionale] [uniqueidentifier] NOT NULL,
	[Note] [nvarchar](255) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Quantity] [int] NULL
 CONSTRAINT [PK_InterventoAmb] PRIMARY KEY CLUSTERED 
(
	[IdIntervento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[InterventoOggettoRot]    Script Date: 07/26/2012 10:29:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterventoOggettoRot]') AND type in (N'U'))
DROP TABLE [dbo].[InterventoOggettoRot]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[InterventoOggettoRot]    Script Date: 07/26/2012 10:29:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InterventoOggettoRot](
	[IdOggettoRot] [int] IDENTITY(1,1) NOT NULL,
	[idInterventoRot] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Quantity] [int] NOT NULL,
	[idTipoOggettoInterventoRot] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_InterventoOggettoRot] PRIMARY KEY CLUSTERED 
(
	[IdOggettoRot] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[InterventoOggettoRotMan]    Script Date: 07/26/2012 10:29:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InterventoOggettoRotMan]') AND type in (N'U'))
DROP TABLE [dbo].[InterventoOggettoRotMan]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[InterventoOggettoRotMan]    Script Date: 07/26/2012 10:29:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InterventoOggettoRotMan](
	[IdOggettoRotMan] [int] IDENTITY(1,1) NOT NULL,
	[idInterventoRotMan] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Quantity] [int] NOT NULL,
	[idTipoOggettoInterventoRotMan] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_InterventoOggettoRotMan] PRIMARY KEY CLUSTERED 
(
	[IdOggettoRotMan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[RuleRot]    Script Date: 07/26/2012 10:46:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RuleRot]') AND type in (N'U'))
DROP TABLE [dbo].[RuleRot]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[RuleRot]    Script Date: 07/26/2012 10:46:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RuleRot](
	[IdRule] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[Monday] [bit] NOT NULL,
	[Tuesday] [bit] NOT NULL,
	[Wednesday] [bit] NOT NULL,
	[Thursday] [bit] NOT NULL,
	[Friday] [bit] NOT NULL,
	[Saturday] [bit] NOT NULL,
	[Sunday] [bit] NOT NULL,
	[WeekEnd] [bit] NOT NULL,
	[HolyDay] [bit] NOT NULL,
	[PreHolyDay] [bit] NOT NULL,
	[PostHolyDay] [bit] NOT NULL,
	[Repetition] [bit] NOT NULL,
	[Frequence] [int] NULL,
	[NumeroTrenoArrivo] [nvarchar](50) NULL,
	[DateTrenoArrivo] [datetime] NULL,
	[StartIntervento] [datetime] NULL,
	[EndIntervento] [datetime] NULL,
 CONSTRAINT [PK_RuleRot] PRIMARY KEY CLUSTERED 
(
	[IdRule] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[RuleRotMan]    Script Date: 07/26/2012 10:46:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RuleRotMan]') AND type in (N'U'))
DROP TABLE [dbo].[RuleRotMan]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[RuleRotMan]    Script Date: 07/26/2012 10:46:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RuleRotMan](
	[IdRule] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[Monday] [bit] NOT NULL,
	[Tuesday] [bit] NOT NULL,
	[Wednesday] [bit] NOT NULL,
	[Thursday] [bit] NOT NULL,
	[Friday] [bit] NOT NULL,
	[Saturday] [bit] NOT NULL,
	[Sunday] [bit] NOT NULL,
	[WeekEnd] [bit] NOT NULL,
	[HolyDay] [bit] NOT NULL,
	[PreHolyDay] [bit] NOT NULL,
	[PostHolyDay] [bit] NOT NULL,
	[Repetition] [bit] NOT NULL,
	[Frequence] [int] NULL,
 CONSTRAINT [PK_RuleRotMan] PRIMARY KEY CLUSTERED 
(
	[IdRule] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[RuleAmb]    Script Date: 07/26/2012 10:46:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RuleAmb]') AND type in (N'U'))
DROP TABLE [dbo].[RuleAmb]
GO

USE [Super2013.Programmazione.ReadStore]
GO

/****** Object:  Table [dbo].[RuleAmb]    Script Date: 07/26/2012 10:46:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RuleAmb](
	[IdRule] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[Monday] [bit] NOT NULL,
	[Tuesday] [bit] NOT NULL,
	[Wednesday] [bit] NOT NULL,
	[Thursday] [bit] NOT NULL,
	[Friday] [bit] NOT NULL,
	[Saturday] [bit] NOT NULL,
	[Sunday] [bit] NOT NULL,
	[WeekEnd] [bit] NOT NULL,
	[HolyDay] [bit] NOT NULL,
	[PreHolyDay] [bit] NOT NULL,
	[PostHolyDay] [bit] NOT NULL,
	[Repetition] [bit] NOT NULL,
	[Frequence] [int] NULL,
 CONSTRAINT [PK_RuleAmb] PRIMARY KEY CLUSTERED 
(
	[IdRule] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


