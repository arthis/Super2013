USE [master]
GO

/****** Object:  Database [Super2013.Saga.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Saga.EventStore')
DROP DATABASE [Super2013.Saga.EventStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Saga.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
CREATE DATABASE [Super2013.Saga.EventStore] ON  PRIMARY 
( NAME = N'Super2013.Saga.EventStore', FILENAME = N'D:\Databases\Super2013.Saga.EventStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Saga.EventStore_log', FILENAME = N'D:\Databases\Super2013.Saga.EventStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Saga.EventStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Saga.EventStore] SET DB_CHAINING OFF 
GO

USE [master]
GO

/****** Object:  Database [Super2013.Appaltatore.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Appaltatore.EventStore')
DROP DATABASE [Super2013.Appaltatore.EventStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Appaltatore.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
CREATE DATABASE [Super2013.Appaltatore.EventStore] ON  PRIMARY 
( NAME = N'Super2013.Appaltatore.EventStore', FILENAME = N'D:\Databases\Super2013.Appaltatore.EventStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Appaltatore.EventStore_log', FILENAME = N'D:\Databases\Super2013.Appaltatore.EventStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Appaltatore.EventStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Appaltatore.EventStore] SET DB_CHAINING OFF 
GO

USE [master]
GO

/****** Object:  Database [Super2013.Controllo.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Controllo.EventStore')
DROP DATABASE [Super2013.Controllo.EventStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Controllo.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
CREATE DATABASE [Super2013.Controllo.EventStore] ON  PRIMARY 
( NAME = N'Super2013.Controllo.EventStore', FILENAME = N'D:\Databases\Super2013.Controllo.EventStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Controllo.EventStore_log', FILENAME = N'D:\Databases\Super2013.Controllo.EventStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Controllo.EventStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Controllo.EventStore] SET DB_CHAINING OFF 
GO

USE [master]
GO

/****** Object:  Database [Super2013.Programmazione.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Programmazione.EventStore')
DROP DATABASE [Super2013.Programmazione.EventStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Programmazione.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
CREATE DATABASE [Super2013.Programmazione.EventStore] ON  PRIMARY 
( NAME = N'Super2013.Programmazione.EventStore', FILENAME = N'D:\Databases\Super2013.Programmazione.EventStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Programmazione.EventStore_log', FILENAME = N'D:\Databases\Super2013.Programmazione.EventStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Programmazione.EventStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Programmazione.EventStore] SET DB_CHAINING OFF 
GO

USE [master]
GO

/****** Object:  Database [Super2013.Contabilita.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Contabilita.EventStore')
DROP DATABASE [Super2013.Contabilita.EventStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Contabilita.EventStore]    Script Date: 06/21/2012 09:01:25 ******/
CREATE DATABASE [Super2013.Contabilita.EventStore] ON  PRIMARY 
( NAME = N'Super2013.Contabilita.EventStore', FILENAME = N'D:\Databases\Super2013.Contabilita.EventStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Contabilita.EventStore_log', FILENAME = N'D:\Databases\Super2013.Contabilita.EventStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Contabilita.EventStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Contabilita.EventStore] SET DB_CHAINING OFF 
GO

USE [Super2013.Contabilita.EventStore]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 06/29/2012 11:51:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commands]') AND type in (N'U'))
DROP TABLE [dbo].[Commands]
GO

USE [Super2013.Contabilita.EventStore]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 06/29/2012 11:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Commands](
	[CommitId] [uniqueidentifier] NOT NULL,
	[CommitStamp] [datetime] NOT NULL,
	[IsExecuted] [bit] NOT NULL,
	[PayLoad] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED 
(
	[CommitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



USE [Super2013.Appaltatore.EventStore]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 06/29/2012 11:51:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commands]') AND type in (N'U'))
DROP TABLE [dbo].[Commands]
GO

USE [Super2013.Appaltatore.EventStore]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 06/29/2012 11:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Commands](
	[CommitId] [uniqueidentifier] NOT NULL,
	[CommitStamp] [datetime] NOT NULL,
	[IsExecuted] [bit] NOT NULL,
	[PayLoad] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED 
(
	[CommitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [Super2013.Programmazione.EventStore]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 06/29/2012 11:51:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commands]') AND type in (N'U'))
DROP TABLE [dbo].[Commands]
GO

USE [Super2013.Programmazione.EventStore]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 06/29/2012 11:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Commands](
	[CommitId] [uniqueidentifier] NOT NULL,
	[CommitStamp] [datetime] NOT NULL,
	[IsExecuted] [bit] NOT NULL,
	[PayLoad] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED 
(
	[CommitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [Super2013.Controllo.EventStore]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 06/29/2012 11:51:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commands]') AND type in (N'U'))
DROP TABLE [dbo].[Commands]
GO

USE [Super2013.Controllo.EventStore]
GO

/****** Object:  Table [dbo].[Commands]    Script Date: 06/29/2012 11:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Commands](
	[CommitId] [uniqueidentifier] NOT NULL,
	[CommitStamp] [datetime] NOT NULL,
	[IsExecuted] [bit] NOT NULL,
	[PayLoad] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED 
(
	[CommitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO





