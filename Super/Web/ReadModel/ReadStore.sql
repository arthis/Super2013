USE [master]
GO

/****** Object:  Database [Super2013.Contabilita.ReadStore]    Script Date: 07/25/2012 16:42:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Contabilita.ReadStore')
DROP DATABASE [Super2013.Contabilita.ReadStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Contabilita.ReadStore]    Script Date: 07/25/2012 16:42:25 ******/
CREATE DATABASE [Super2013.Contabilita.ReadStore] ON  PRIMARY 
( NAME = N'Super2013.Contabilita.ReadStore', FILENAME = N'D:\Databases\Super2013.Contabilita.ReadStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Contabilita.ReadStore_log', FILENAME = N'D:\Databases\Super2013.Contabilita.ReadStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Contabilita.ReadStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Contabilita.ReadStore] SET DB_CHAINING OFF 
GO


--************************************************************************************
--************************************************************************************
--************************************************************************************

USE [master]
GO

/****** Object:  Database [Super2013.Appaltatore.ReadStore]    Script Date: 07/25/2012 16:42:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Appaltatore.ReadStore')
DROP DATABASE [Super2013.Appaltatore.ReadStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Appaltatore.ReadStore]    Script Date: 07/25/2012 16:42:25 ******/
CREATE DATABASE [Super2013.Appaltatore.ReadStore] ON  PRIMARY 
( NAME = N'Super2013.Appaltatore.ReadStore', FILENAME = N'D:\Databases\Super2013.Appaltatore.ReadStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Appaltatore.ReadStore_log', FILENAME = N'D:\Databases\Super2013.Appaltatore.ReadStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Appaltatore.ReadStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Appaltatore.ReadStore] SET DB_CHAINING OFF 
GO


--************************************************************************************
--************************************************************************************
--************************************************************************************

USE [master]
GO

/****** Object:  Database [Super2013.Programmazione.ReadStore]    Script Date: 07/25/2012 16:42:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Programmazione.ReadStore')
DROP DATABASE [Super2013.Programmazione.ReadStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Programmazione.ReadStore]    Script Date: 07/25/2012 16:42:25 ******/
CREATE DATABASE [Super2013.Programmazione.ReadStore] ON  PRIMARY 
( NAME = N'Super2013.Programmazione.ReadStore', FILENAME = N'D:\Databases\Super2013.Programmazione.ReadStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Programmazione.ReadStore_log', FILENAME = N'D:\Databases\Super2013.Programmazione.ReadStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Programmazione.ReadStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Programmazione.ReadStore] SET DB_CHAINING OFF 
GO


--************************************************************************************
--************************************************************************************
--************************************************************************************

USE [master]
GO

/****** Object:  Database [Super2013.Controllo.ReadStore]    Script Date: 07/25/2012 16:42:25 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Super2013.Controllo.ReadStore')
DROP DATABASE [Super2013.Controllo.ReadStore]
GO

USE [master]
GO

/****** Object:  Database [Super2013.Controllo.ReadStore]    Script Date: 07/25/2012 16:42:25 ******/
CREATE DATABASE [Super2013.Controllo.ReadStore] ON  PRIMARY 
( NAME = N'Super2013.Controllo.ReadStore', FILENAME = N'D:\Databases\Super2013.Controllo.ReadStore.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2013.Controllo.ReadStore_log', FILENAME = N'D:\Databases\Super2013.Controllo.ReadStore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013.Controllo.ReadStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013.Controllo.ReadStore] SET DB_CHAINING OFF 
GO


--************************************************************************************
--************************************************************************************
--************************************************************************************
