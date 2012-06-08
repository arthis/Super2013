﻿USE [EasyNetQ.Scheduler]
GO
/****** Object:  Table [dbo].[ScheduleMe]    Script Date: 05/18/2011 16:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScheduleMe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WakeTime] [datetime] NOT NULL,
	[BindingKey] [nvarchar](1000) NOT NULL,
	[InnerMessage] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_ScheduleMe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF