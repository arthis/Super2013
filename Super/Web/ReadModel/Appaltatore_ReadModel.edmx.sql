USE [Super2013.Appaltatore.ReadStore]
GO



/****** Object:  Table [dbo].[LastEventsReadAppaltatore]    Script Date: 06/26/2012 10:45:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LastEventsReadAppaltatore]') AND type in (N'U'))
DROP TABLE [dbo].[LastEventsReadAppaltatore]
GO

USE [Super2013.Appaltatore.ReadStore]
GO

/****** Object:  Table [dbo].[LastEventsReadAppaltatore]    Script Date: 06/26/2012 10:45:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LastEventsReadAppaltatore](
	[CommitId] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_LastEventsReadAppaltatore] PRIMARY KEY CLUSTERED 
(
	[CommitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


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
	[Version] bigint not null,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] not null DEFAULT 0,
 CONSTRAINT [PK_Appaltatore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsAvv__0519C6AF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsAvv__0519C6AF]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsSpu__060DEAE8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsSpu__060DEAE8]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsRes__07020F21]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsRes__07020F21]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsNon__07F6335A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsNon__07F6335A]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsNon__08EA5793]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsNon__08EA5793]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsNon__09DE7BCC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsNon__09DE7BCC]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsRil__0AD2A005]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsRil__0AD2A005]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsRet__0BC6C43E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsRet__0BC6C43E]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsSos__0CBAE877]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsSos__0CBAE877]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__HasSc__0DAF0CB0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__HasSc__0DAF0CB0]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__HasSc__0EA330E9]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__HasSc__0EA330E9]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsPro__0F975522]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsPro__0F975522]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsPLX__108B795B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsPLX__108B795B]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsEst__117F9D94]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsEst__117F9D94]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsSos__1273C1CD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsSos__1273C1CD]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__HasTr__1367E606]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__HasTr__1367E606]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__HasRo__145C0A3F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__HasRo__145C0A3F]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__HasCa__15502E78]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__HasCa__15502E78]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__HasLo__164452B1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__HasLo__164452B1]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsMod__173876EA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsMod__173876EA]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsMod__182C9B23]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsMod__182C9B23]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__IsMod__1920BF5C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__IsMod__1920BF5C]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Consuntiv__Delet__1A14E395]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConsuntivazioneRot] DROP CONSTRAINT [DF__Consuntiv__Delet__1A14E395]
END

GO

USE [Super2013.Appaltatore.ReadStore]
GO

/****** Object:  Table [dbo].[ConsuntivazioneRot]    Script Date: 05/28/2012 15:14:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConsuntivazioneRot]') AND type in (N'U'))
DROP TABLE [dbo].[ConsuntivazioneRot]
GO

USE [Super2013.Appaltatore.ReadStore]
GO

/****** Object:  Table [dbo].[ConsuntivazioneRot]    Script Date: 05/28/2012 15:14:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ConsuntivazioneRot](
	[IdIntervento] [uniqueidentifier] NOT NULL,
	[IdCommittente] [uniqueidentifier] NOT NULL,
	[IdLotto] [uniqueidentifier] NOT NULL,
	[IdImpianto] [uniqueidentifier] NOT NULL,
	[IdTipoIntervento] [uniqueidentifier] NOT NULL,
	[CodiceOrdine] [nvarchar](255) NULL,
	[IsAvvisoIspezione] [bit] NOT NULL,
	[IsSpunta] [bit] NOT NULL,
	[IsReso] [bit] NOT NULL,
	[IsNonResoAppaltatore] [bit] NOT NULL,
	[IsNonReso20mn] [bit] NOT NULL,
	[IsNonResoTrenitalia] [bit] NOT NULL,
	[IsRilevatoNonReso] [bit] NOT NULL,
	[IsRettifica] [bit] NOT NULL,
	[IsSostituito] [bit] NOT NULL,
	[HasSchedaV] [bit] NOT NULL,
	[HasSchedaQ] [bit] NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[NumeroTrenoPartenza] [nvarchar](50) NULL,
	[DataTrenoPartenza] [datetime] NULL,
	StartDateProgrammata [datetime] NOT NULL,
	EndDateProgrammata [datetime] NOT NULL,
	[ComposizioneProgrammata] [nvarchar](255) NULL,
	StartDateConsuntivataAppaltatore [datetime] NOT NULL,
	EndDateConsuntivataAppaltatore [datetime] NOT NULL,
	[IsProgrammato] [bit] NOT NULL,
	[IsPLX] [bit] NOT NULL,
	[IsEstemporaneo] [bit] NOT NULL,
	[IsSostitutivo] [bit] NOT NULL,
	[HasTreni] [bit] NOT NULL,
	[HasRotabiliSingoli] [bit] NOT NULL,
	[HasCarozze] [bit] NOT NULL,
	[HasLocomotive] [bit] NOT NULL,
	[IsModificatoTrenitaliaRispettoAlProgramma] [bit] NOT NULL,
	[IsModificatoAppaltatoreRispettoAlProgramma] [bit] NOT NULL,
	[IsModificatoTrenitaliaRispettoAllAppaltatore] [bit] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_ConsuntivoRot] PRIMARY KEY CLUSTERED 
(
	[IdIntervento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsAvvisoIspezione]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsSpunta]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsReso]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsNonResoAppaltatore]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsNonReso20mn]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsNonResoTrenitalia]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsRilevatoNonReso]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsRettifica]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsSostituito]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [HasSchedaV]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [HasSchedaQ]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsProgrammato]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsPLX]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsEstemporaneo]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsSostitutivo]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [HasTreni]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [HasRotabiliSingoli]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [HasCarozze]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [HasLocomotive]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsModificatoTrenitaliaRispettoAlProgramma]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsModificatoAppaltatoreRispettoAlProgramma]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [IsModificatoTrenitaliaRispettoAllAppaltatore]
GO

ALTER TABLE [dbo].[ConsuntivazioneRot] ADD  DEFAULT ((0)) FOR [Deleted]
GO


