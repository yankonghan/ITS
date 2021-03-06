USE [master]
GO
/****** Object:  Database [ITS]    Script Date: 03/05/2015 11:57:44 ******/
CREATE DATABASE [ITS] ON  PRIMARY 
( NAME = N'ITS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ITS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ITS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ITS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ITS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ITS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ITS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ITS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ITS] SET ARITHABORT OFF
GO
ALTER DATABASE [ITS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ITS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ITS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ITS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ITS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ITS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ITS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ITS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ITS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ITS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ITS] SET  DISABLE_BROKER
GO
ALTER DATABASE [ITS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ITS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ITS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ITS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ITS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ITS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ITS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ITS] SET  READ_WRITE
GO
ALTER DATABASE [ITS] SET RECOVERY FULL
GO
ALTER DATABASE [ITS] SET  MULTI_USER
GO
ALTER DATABASE [ITS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ITS] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ITS', N'ON'
GO
USE [ITS]
GO
/****** Object:  Table [dbo].[line]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[line](
	[lineID] [nvarchar](20) NOT NULL,
	[lineName] [nvarchar](20) NULL,
	[lineLength] [float] NULL,
	[startStation] [nvarchar](20) NULL,
	[endStation] [nvarchar](20) NULL,
 CONSTRAINT [PK_line] PRIMARY KEY CLUSTERED 
(
	[lineID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bus]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bus](
	[busID] [nvarchar](20) NOT NULL,
	[lineID] [nvarchar](20) NULL,
	[state] [smallint] NULL,
	[isOnline] [bit] NULL,
 CONSTRAINT [PK_bus] PRIMARY KEY CLUSTERED 
(
	[busID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[statistics]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[statistics](
	[lineID] [nvarchar](20) NOT NULL,
	[busNumber] [smallint] NULL,
	[traffic] [smallint] NULL,
 CONSTRAINT [PK_statistics] PRIMARY KEY CLUSTERED 
(
	[lineID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[station]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[station](
	[stationID] [nvarchar](20) NOT NULL,
	[stationName] [nvarchar](20) NULL,
	[lat] [decimal](18, 6) NULL,
	[lng] [decimal](18, 6) NULL,
	[isOnline] [bit] NULL,
 CONSTRAINT [PK_station] PRIMARY KEY CLUSTERED 
(
	[stationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[runInfo]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[runInfo](
	[busID] [nvarchar](20) NOT NULL,
	[oilRemain] [decimal](18, 6) NULL,
	[speed] [decimal](18, 6) NULL,
	[lat] [decimal](18, 6) NULL,
	[lng] [decimal](18, 6) NULL,
	[passengerNumber] [smallint] NULL,
	[nextStationID] [nvarchar](20) NULL,
	[isAlarm] [bit] NULL,
	[isDeviate] [bit] NULL,
 CONSTRAINT [PK_runInfo] PRIMARY KEY CLUSTERED 
(
	[busID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lineStation]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lineStation](
	[stationID] [nvarchar](20) NOT NULL,
	[lineID] [nvarchar](20) NOT NULL,
	[preStationID] [nvarchar](20) NULL,
	[nextStationID] [nvarchar](20) NULL,
 CONSTRAINT [PK_lineStation] PRIMARY KEY CLUSTERED 
(
	[stationID] ASC,
	[lineID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[driver]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[driver](
	[driverID] [nvarchar](20) NOT NULL,
	[driverName] [nvarchar](20) NULL,
	[busID] [nvarchar](20) NULL,
	[sex] [bit] NULL,
	[age] [smallint] NULL,
 CONSTRAINT [PK_driver] PRIMARY KEY CLUSTERED 
(
	[driverID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[busTime]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[busTime](
	[busID] [nvarchar](20) NOT NULL,
	[stationID] [nvarchar](20) NOT NULL,
	[arriveTime] [datetime] NULL,
	[startTime] [datetime] NULL,
 CONSTRAINT [PK_busTime] PRIMARY KEY CLUSTERED 
(
	[busID] ASC,
	[stationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[event]    Script Date: 03/05/2015 11:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[event](
	[eventNumber] [nvarchar](20) NOT NULL,
	[time] [datetime] NULL,
	[scheme] [nvarchar](max) NULL,
	[result] [nvarchar](max) NULL,
	[driverID] [nvarchar](20) NULL,
 CONSTRAINT [PK_event] PRIMARY KEY CLUSTERED 
(
	[eventNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Check [CK_bus]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[bus]  WITH CHECK ADD  CONSTRAINT [CK_bus] CHECK  (([state]='1' OR [state]='0' OR [state]='-1'))
GO
ALTER TABLE [dbo].[bus] CHECK CONSTRAINT [CK_bus]
GO
/****** Object:  Check [CK_statistics]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[statistics]  WITH CHECK ADD  CONSTRAINT [CK_statistics] CHECK  (([traffic]>(0) AND [traffic]<(6)))
GO
ALTER TABLE [dbo].[statistics] CHECK CONSTRAINT [CK_statistics]
GO
/****** Object:  Check [CK_station]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[station]  WITH CHECK ADD  CONSTRAINT [CK_station] CHECK  (([lat]>=(0) AND [lat]<(360) AND [lng]>=(0) AND [lng]<(360)))
GO
ALTER TABLE [dbo].[station] CHECK CONSTRAINT [CK_station]
GO
/****** Object:  Check [CK_driver]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[driver]  WITH CHECK ADD  CONSTRAINT [CK_driver] CHECK  (([age]>(0) AND [age]<(100)))
GO
ALTER TABLE [dbo].[driver] CHECK CONSTRAINT [CK_driver]
GO
/****** Object:  ForeignKey [FK_runInfo_runInfo]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[runInfo]  WITH CHECK ADD  CONSTRAINT [FK_runInfo_runInfo] FOREIGN KEY([nextStationID])
REFERENCES [dbo].[station] ([stationID])
GO
ALTER TABLE [dbo].[runInfo] CHECK CONSTRAINT [FK_runInfo_runInfo]
GO
/****** Object:  ForeignKey [FK_lineStation_line]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[lineStation]  WITH CHECK ADD  CONSTRAINT [FK_lineStation_line] FOREIGN KEY([lineID])
REFERENCES [dbo].[line] ([lineID])
GO
ALTER TABLE [dbo].[lineStation] CHECK CONSTRAINT [FK_lineStation_line]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'lineStation的lineID参照line的lineID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'lineStation', @level2type=N'CONSTRAINT',@level2name=N'FK_lineStation_line'
GO
/****** Object:  ForeignKey [FK_lineStation_station]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[lineStation]  WITH CHECK ADD  CONSTRAINT [FK_lineStation_station] FOREIGN KEY([stationID])
REFERENCES [dbo].[station] ([stationID])
GO
ALTER TABLE [dbo].[lineStation] CHECK CONSTRAINT [FK_lineStation_station]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'lineStation的stationID参照station的stationID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'lineStation', @level2type=N'CONSTRAINT',@level2name=N'FK_lineStation_station'
GO
/****** Object:  ForeignKey [FK_lineStation_station1]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[lineStation]  WITH CHECK ADD  CONSTRAINT [FK_lineStation_station1] FOREIGN KEY([nextStationID])
REFERENCES [dbo].[station] ([stationID])
GO
ALTER TABLE [dbo].[lineStation] CHECK CONSTRAINT [FK_lineStation_station1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'lineStation的nextStationID参照station的stationID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'lineStation', @level2type=N'CONSTRAINT',@level2name=N'FK_lineStation_station1'
GO
/****** Object:  ForeignKey [FK_lineStation_station2]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[lineStation]  WITH CHECK ADD  CONSTRAINT [FK_lineStation_station2] FOREIGN KEY([preStationID])
REFERENCES [dbo].[station] ([stationID])
GO
ALTER TABLE [dbo].[lineStation] CHECK CONSTRAINT [FK_lineStation_station2]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'lineStation的preStationID参照station的stationID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'lineStation', @level2type=N'CONSTRAINT',@level2name=N'FK_lineStation_station2'
GO
/****** Object:  ForeignKey [FK_driver_driver]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[driver]  WITH CHECK ADD  CONSTRAINT [FK_driver_driver] FOREIGN KEY([busID])
REFERENCES [dbo].[bus] ([busID])
GO
ALTER TABLE [dbo].[driver] CHECK CONSTRAINT [FK_driver_driver]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'driver的busID参考bus的busID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'driver', @level2type=N'CONSTRAINT',@level2name=N'FK_driver_driver'
GO
/****** Object:  ForeignKey [FK_busTime_busID_bus]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[busTime]  WITH CHECK ADD  CONSTRAINT [FK_busTime_busID_bus] FOREIGN KEY([busID])
REFERENCES [dbo].[bus] ([busID])
GO
ALTER TABLE [dbo].[busTime] CHECK CONSTRAINT [FK_busTime_busID_bus]
GO
/****** Object:  ForeignKey [FK_busTime_stationID_station]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[busTime]  WITH CHECK ADD  CONSTRAINT [FK_busTime_stationID_station] FOREIGN KEY([stationID])
REFERENCES [dbo].[station] ([stationID])
GO
ALTER TABLE [dbo].[busTime] CHECK CONSTRAINT [FK_busTime_stationID_station]
GO
/****** Object:  ForeignKey [FK_event_event]    Script Date: 03/05/2015 11:57:46 ******/
ALTER TABLE [dbo].[event]  WITH CHECK ADD  CONSTRAINT [FK_event_event] FOREIGN KEY([driverID])
REFERENCES [dbo].[driver] ([driverID])
GO
ALTER TABLE [dbo].[event] CHECK CONSTRAINT [FK_event_event]
GO
