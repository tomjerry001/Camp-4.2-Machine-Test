USE [master]
GO
/****** Object:  Database [AirlineManagementSystem]    Script Date: 28-08-2024 16:09:03 ******/
CREATE DATABASE [AirlineManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AirlineManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AirlineManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AirlineManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AirlineManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AirlineManagementSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AirlineManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AirlineManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AirlineManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AirlineManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AirlineManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AirlineManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AirlineManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [AirlineManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AirlineManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AirlineManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AirlineManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AirlineManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AirlineManagementSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AirlineManagementSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [AirlineManagementSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AirlineManagementSystem]
GO
/****** Object:  Table [dbo].[Airport]    Script Date: 28-08-2024 16:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airport](
	[Code] [nvarchar](10) NOT NULL,
	[City] [nvarchar](100) NULL,
	[AirportName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 28-08-2024 16:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[FlightId] [int] IDENTITY(1,1) NOT NULL,
	[DepAirport] [nvarchar](10) NULL,
	[DepDate] [date] NULL,
	[DepTime] [time](7) NULL,
	[ArrAirport] [nvarchar](10) NULL,
	[ArrDate] [date] NULL,
	[ArrTime] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[FlightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Airport] ([Code], [City], [AirportName]) VALUES (N'DFW', N'Dallas', N'Dallas Worth International Airport')
INSERT [dbo].[Airport] ([Code], [City], [AirportName]) VALUES (N'JFK', N'New York', N'John F. Kennedy International Airport')
INSERT [dbo].[Airport] ([Code], [City], [AirportName]) VALUES (N'LAX', N'Los Angeles', N'Los Angeles International Airport')
INSERT [dbo].[Airport] ([Code], [City], [AirportName]) VALUES (N'ORD', N'Chicago', N'Hare International Airport')
INSERT [dbo].[Airport] ([Code], [City], [AirportName]) VALUES (N'SFO', N'San Francisco', N'San Francisco International Airport')
GO
SET IDENTITY_INSERT [dbo].[Flight] ON 

INSERT [dbo].[Flight] ([FlightId], [DepAirport], [DepDate], [DepTime], [ArrAirport], [ArrDate], [ArrTime]) VALUES (1, N'JFK', CAST(N'2024-09-01' AS Date), CAST(N'10:00:00' AS Time), N'LAX', CAST(N'2024-09-01' AS Date), CAST(N'13:00:00' AS Time))
INSERT [dbo].[Flight] ([FlightId], [DepAirport], [DepDate], [DepTime], [ArrAirport], [ArrDate], [ArrTime]) VALUES (2, N'LAX', CAST(N'2024-09-02' AS Date), CAST(N'15:00:00' AS Time), N'ORD', CAST(N'2024-09-02' AS Date), CAST(N'21:00:00' AS Time))
INSERT [dbo].[Flight] ([FlightId], [DepAirport], [DepDate], [DepTime], [ArrAirport], [ArrDate], [ArrTime]) VALUES (3, N'ORD', CAST(N'2024-09-03' AS Date), CAST(N'08:00:00' AS Time), N'DFW', CAST(N'2024-09-03' AS Date), CAST(N'11:00:00' AS Time))
INSERT [dbo].[Flight] ([FlightId], [DepAirport], [DepDate], [DepTime], [ArrAirport], [ArrDate], [ArrTime]) VALUES (4, N'DFW', CAST(N'2024-09-04' AS Date), CAST(N'14:00:00' AS Time), N'SFO', CAST(N'2024-09-04' AS Date), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Flight] ([FlightId], [DepAirport], [DepDate], [DepTime], [ArrAirport], [ArrDate], [ArrTime]) VALUES (5, N'LAX', CAST(N'2024-09-10' AS Date), CAST(N'10:10:30' AS Time), N'ORD', CAST(N'2024-09-11' AS Date), CAST(N'08:30:10' AS Time))
INSERT [dbo].[Flight] ([FlightId], [DepAirport], [DepDate], [DepTime], [ArrAirport], [ArrDate], [ArrTime]) VALUES (8, N'JFK', CAST(N'2024-09-09' AS Date), CAST(N'10:10:10' AS Time), N'SFO', CAST(N'2024-09-10' AS Date), CAST(N'08:30:10' AS Time))
INSERT [dbo].[Flight] ([FlightId], [DepAirport], [DepDate], [DepTime], [ArrAirport], [ArrDate], [ArrTime]) VALUES (9, N'DFW', CAST(N'2024-09-10' AS Date), CAST(N'10:10:10' AS Time), N'ORD', CAST(N'2024-09-11' AS Date), CAST(N'08:30:10' AS Time))
SET IDENTITY_INSERT [dbo].[Flight] OFF
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD FOREIGN KEY([ArrAirport])
REFERENCES [dbo].[Airport] ([Code])
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD FOREIGN KEY([DepAirport])
REFERENCES [dbo].[Airport] ([Code])
GO
/****** Object:  StoredProcedure [dbo].[sp_AddFlight]    Script Date: 28-08-2024 16:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddFlight]
    @DepAirport NVARCHAR(10),
    @DepDate DATE,
    @DepTime TIME,
    @ArrAirport NVARCHAR(10),
    @ArrDate DATE,
    @ArrTime TIME
AS
BEGIN
    INSERT INTO Flight (DepAirport, DepDate, DepTime, ArrAirport, ArrDate, ArrTime)
    VALUES (@DepAirport, @DepDate, @DepTime, @ArrAirport, @ArrDate, @ArrTime);
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_GetFlightById]    Script Date: 28-08-2024 16:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetFlightById]
    @FlightId INT
AS
BEGIN
    SELECT FlightId, DepAirport, DepDate, DepTime, ArrAirport, ArrDate, ArrTime
    FROM Flight
    WHERE FlightId = @FlightId;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_ListAllFlights]    Script Date: 28-08-2024 16:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListAllFlights]
AS
BEGIN
    SELECT FlightId, DepAirport, DepDate, DepTime, ArrAirport, ArrDate, ArrTime
    FROM Flight;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateFlight]    Script Date: 28-08-2024 16:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateFlight]
    @FlightId INT,
    @DepAirport NVARCHAR(10),
    @DepDate DATE,
    @DepTime TIME,
    @ArrAirport NVARCHAR(10),
    @ArrDate DATE,
    @ArrTime TIME
AS
BEGIN
    UPDATE Flight
    SET DepAirport = @DepAirport,
        DepDate = @DepDate,
        DepTime = @DepTime,
        ArrAirport = @ArrAirport,
        ArrDate = @ArrDate,
        ArrTime = @ArrTime
    WHERE FlightId = @FlightId;
END;

GO
USE [master]
GO
ALTER DATABASE [AirlineManagementSystem] SET  READ_WRITE 
GO
