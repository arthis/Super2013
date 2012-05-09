
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/26/2010 22:39:10
-- Generated from EDMX file: C:\Projects\ncqrs\Samples\MyNotes\src\ReadModel\ReadModel.edmx
-- --------------------------------------------------

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
	[IdAreaInterventoSuper] [int] NULL,
	[Descrizione] [nvarchar](255) NULL,
	[Inizio] [datetime] NOT NULL,
	[Fine] [datetime] NULL,
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
	[IdTipoInterventoSuper] [int] NULL,
	[Descrizione] [nvarchar](255) NULL,
	[Inizio] [datetime] NOT NULL,
	[Fine] [datetime] NULL,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_TipoIntervento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[[ConsuntivazioneRot]]    Script Date: 02/07/2012 14:42:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConsuntivazioneRot]') AND type in (N'U'))
DROP TABLE [dbo].[ConsuntivazioneRot]
GO


/****** Object:  Table [dbo].[[ConsuntivazioneRot]]    Script Date: 02/07/2012 14:42:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ConsuntivazioneRot](
	[IdIntervento] [uniqueidentifier] NOT NULL,
	[IdInterventoSuper2010] [int] NOT NULL,
	[IdCommittente] [uniqueidentifier] NOT NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[IdAreaIntervento] [uniqueidentifier] NOT NULL,
	[IdTipoIntervento] [uniqueidentifier] NOT NULL,
	[CodiceOrdine] [nvarchar](255) NULL,
	[IsAvvisoIspezione] [bit] NOT NULL Default(0),
	[IsSpunta] [bit] NOT NULL Default(0),
	[IsReso] [bit] NOT NULL Default(0),
	[IsNonResoAppaltatore] [bit] NOT NULL Default(0),
	[IsNonReso20mn] [bit] NOT NULL Default(0),
	[IsNonResoTrenitalia] [bit] NOT NULL Default(0),
	[IsRilevatoNonReso] [bit] NOT NULL Default(0),
	[IsRettifica] [bit] NOT NULL Default(0),
	[IsSostituito] [bit] NOT NULL Default(0),
	[HasSchedaV] [bit] NOT NULL Default(0),
	[HasSchedaQ] [bit] NOT NULL Default(0),
	[Data] [datetime] NOT NULL,
	[AreaInterventoDescrizione] [nvarchar](255) NOT NULL,
	[CategoriaTreno] [nvarchar](255) NULL,
	[NumeroTrenoPartenza] [nvarchar](50) NULL,
	[DataTrenoPartenza] [datetime] NULL,
	[TipoInterventoDescrizione] [nvarchar](255) NOT NULL,
	[DataInizioProgrammata] [datetime] NOT NULL,
	[DataFineProgrammata] [datetime] NOT NULL,
	[ComposizioneProgrammata] [nvarchar](255) NULL,
	[DataInizioConsuntivataAppaltatore] [datetime] NOT NULL,
	[DataFineConsuntivataAppaltatore] [datetime] NOT NULL,
	[IsProgrammato] [bit] NOT NULL Default(0),
	[IsPLX] [bit] NOT NULL Default(0),
	[IsEstemporaneo] [bit] NOT NULL Default(0),
	[IsSostitutivo] [bit] NOT NULL Default(0),
	[HasTreni] [bit] NOT NULL Default(0),
	[HasRotabiliSingoli] [bit] NOT NULL Default(0),
	[HasCarozze] [bit] NOT NULL Default(0),
	[HasLocomotive] [bit] NOT NULL Default(0),
	[IsModificatoTrenitaliaRispettoAlProgramma] [bit] NOT NULL Default(0),
	[IsModificatoAppaltatoreRispettoAlProgramma] [bit] NOT NULL Default(0),
	[IsModificatoTrenitaliaRispettoAllAppaltatore] [bit] NOT NULL Default(0),
	[CreationDate] datetime not null,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_ConsuntivoRot] PRIMARY KEY CLUSTERED 
(
	[IdIntervento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]









-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------