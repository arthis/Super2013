﻿USE [master]
GO


CREATE DATABASE [Super2013] ON  PRIMARY 
( NAME = N'Super2013', FILENAME = N'D:\Databases\Super2013.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Super2010ReadModel_log', FILENAME = N'D:\Databases\Super2013_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Super2013] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Super2013].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Super2013] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Super2013] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Super2013] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Super2013] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Super2013] SET ARITHABORT OFF 
GO

ALTER DATABASE [Super2013] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Super2013] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Super2013] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Super2013] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Super2013] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Super2013] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Super2013] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Super2013] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Super2013] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Super2013] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Super2013] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Super2013] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Super2013] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Super2013] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Super2013] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Super2013] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Super2013] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Super2013] SET  READ_WRITE 
GO

ALTER DATABASE [Super2013] SET RECOVERY FULL 
GO

ALTER DATABASE [Super2013] SET  MULTI_USER 
GO

ALTER DATABASE [Super2013] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Super2013] SET DB_CHAINING OFF 
GO
	