USE [master]
GO
/****** Object:  Database [Ticketing]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE DATABASE [Ticketing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ticketing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Ticketing.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ticketing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Ticketing_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Ticketing] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ticketing].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ticketing] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ticketing] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ticketing] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ticketing] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ticketing] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ticketing] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ticketing] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ticketing] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ticketing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ticketing] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ticketing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ticketing] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ticketing] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ticketing] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ticketing] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ticketing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ticketing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ticketing] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ticketing] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ticketing] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ticketing] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ticketing] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ticketing] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Ticketing] SET  MULTI_USER 
GO
ALTER DATABASE [Ticketing] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ticketing] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ticketing] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ticketing] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ticketing] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ticketing] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Ticketing] SET QUERY_STORE = ON
GO
ALTER DATABASE [Ticketing] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Ticketing]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActionObject]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionObject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [nvarchar](max) NULL,
	[Serial] [int] NULL,
	[Type] [int] NULL,
	[RaisedById] [int] NULL,
	[ForwardedToId] [int] NULL,
	[Comments] [nvarchar](max) NULL,
	[AdditionalInfo] [nvarchar](max) NULL,
	[TicketId] [int] NULL,
 CONSTRAINT [PK_ActionObject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[Headline] [nvarchar](max) NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chats]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NULL,
 CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConnectionHolderClass]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConnectionHolderClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ChatId] [int] NULL,
	[ConnectionId] [nvarchar](max) NULL,
 CONSTRAINT [PK_ConnectionHolderClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConversationClass]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConversationClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromId] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[Time] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[ChatId] [int] NULL,
 CONSTRAINT [PK_ConversationClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailsClass]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailsClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](max) NULL,
	[Input] [nvarchar](max) NULL,
	[TeamId] [int] NULL,
	[TicketId] [int] NULL,
 CONSTRAINT [PK_DetailsClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[File2]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File2](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[OriginalName] [nvarchar](max) NULL,
	[ConversationId] [int] NULL,
	[NoteId] [int] NULL,
	[ActionId] [int] NULL,
	[TicketId] [int] NULL,
 CONSTRAINT [PK_File2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mentions]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mentions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NoteId] [int] NULL,
	[NotificationId] [int] NULL,
 CONSTRAINT [PK_Mentions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NULL,
	[Data] [nvarchar](max) NULL,
	[TakenBy] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Caption] [nvarchar](max) NULL,
	[Mentions] [nvarchar](max) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[TicketId] [int] NULL,
	[FromId] [int] NULL,
	[ToId] [int] NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Mentions] [varchar](max) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProblemTypesClass]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProblemTypesClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Subs] [varchar](max) NOT NULL,
	[TeamId] [int] NULL,
 CONSTRAINT [PK_ProblemTypesClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subordinates]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subordinates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[TeamId] [int] NULL,
	[Rank] [int] NULL,
 CONSTRAINT [PK_Subordinates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamLeaders]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamLeaders](
	[LeadersId] [int] NOT NULL,
	[TeamsLeadedId] [int] NOT NULL,
 CONSTRAINT [PK_TeamLeaders] PRIMARY KEY CLUSTERED 
(
	[LeadersId] ASC,
	[TeamsLeadedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamMonitors]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamMonitors](
	[MonitorsId] [int] NOT NULL,
	[TeamsMonitoredId] [int] NOT NULL,
 CONSTRAINT [PK_TeamMonitors] PRIMARY KEY CLUSTERED 
(
	[MonitorsId] ASC,
	[TeamsMonitoredId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HasServices] [bit] NULL,
	[Name] [nvarchar](max) NULL,
	[HeadId] [int] NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](max) NOT NULL,
	[Number] [int] NOT NULL,
	[Department] [nvarchar](max) NULL,
	[ProblemDetails] [nvarchar](max) NULL,
	[Assigned] [bit] NULL,
	[HasService] [bit] NULL,
	[Location] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Extension] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[ApprovalRequired] [bit] NULL,
	[Remarks] [nvarchar](max) NULL,
	[CloseRequested] [bit] NULL,
	[AssignedToId] [int] NULL,
	[TicketType] [nvarchar](max) NULL,
	[RaisedById] [int] NULL,
	[Status] [nvarchar](max) NULL,
	[PrevStatus] [nvarchar](max) NULL,
	[Ask] [bit] NULL,
	[Type] [nvarchar](max) NULL,
	[Infos] [varchar](max) NULL,
	[RequestDate] [nvarchar](max) NULL,
	[CurrentHandlerId] [int] NULL,
	[TicketingHeadId] [int] NULL,
	[PrevHandlerId] [int] NULL,
	[ServiceType] [nvarchar](max) NULL,
	[MadeCloseRequest] [bit] NULL,
	[BeenRejected] [bit] NULL,
	[Accepted] [bit] NULL,
	[Mentions] [varchar](max) NULL,
	[Users] [varchar](max) NULL,
	[TimesRaised] [int] NOT NULL,
	[Genesis] [bit] NOT NULL,
	[GenesisId] [int] NULL,
	[InitialType] [nvarchar](max) NULL,
	[InitialLocation] [nvarchar](max) NULL,
	[InitialPriorityId] [int] NULL,
	[Source] [nvarchar](max) NULL,
	[InitialPriority] [nvarchar](max) NULL,
	[Priority] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/26/2024 12:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [nvarchar](max) NULL,
	[EmpCode] [nvarchar](max) NULL,
	[Designation] [nvarchar](max) NULL,
	[MailAddress] [nvarchar](max) NULL,
	[Unit] [nvarchar](max) NULL,
	[Section] [nvarchar](max) NULL,
	[Wing] [nvarchar](max) NULL,
	[Team] [nvarchar](max) NULL,
	[Groups] [varchar](max) NULL,
	[Department] [nvarchar](max) NULL,
	[TeamType] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Rank] [int] NOT NULL,
	[UserType] [nvarchar](max) NULL,
	[TravelUserType] [nvarchar](max) NULL,
	[Available] [bit] NULL,
	[Rating] [int] NULL,
	[Raters] [int] NULL,
	[Extension] [nvarchar](max) NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Numbers] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231227051718_initial creation', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240130021652_new migrations from ticketing 2', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240130031511_new migrations from ticketing 3', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240131052543_changed the notes entity', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240203051517_removed groups from ticketing', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240203055541_asdasd', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240205082146_changed the blog id', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240205082848_migrations added for blogs', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240205083503_blogs configuration changed', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240222064722_changed the connetion holder class', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240225092046_changed the priorty class', N'7.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240225095735_rasdfagargasddgjaenbf', N'7.0.0')
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([Id], [Name]) VALUES (1, N'Dhaka')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (3, N'Kaliganj')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (4, N'Mawna')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (5, N'Tongi')
INSERT [dbo].[Locations] ([Id], [Name]) VALUES (6, N'Tangail')
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[ProblemTypesClass] ON 

INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (2005, N'asd', N'asd', NULL)
INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (2006, N'213', N'12', NULL)
INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (2007, N'asdf', N'asdf', NULL)
INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (2008, N'asdf', N'asdf', NULL)
INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (2009, N'123', N'adsf', NULL)
INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (2010, N'213123', N'asdf', NULL)
INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (3005, N'Hardware Problems', N'printer not working,laptop too slow', 3003)
INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (3006, N'Software problems', N'cant open account in hris', 3003)
INSERT [dbo].[ProblemTypesClass] ([Id], [Name], [Subs], [TeamId]) VALUES (3007, N'Communication problems', N'Mail not reaching client', 3003)
SET IDENTITY_INSERT [dbo].[ProblemTypesClass] OFF
GO
SET IDENTITY_INSERT [dbo].[Subordinates] ON 

INSERT [dbo].[Subordinates] ([Id], [UserId], [TeamId], [Rank]) VALUES (3003, 1011, 3003, 2)
SET IDENTITY_INSERT [dbo].[Subordinates] OFF
GO
INSERT [dbo].[TeamLeaders] ([LeadersId], [TeamsLeadedId]) VALUES (1010, 3003)
GO
INSERT [dbo].[TeamMonitors] ([MonitorsId], [TeamsMonitoredId]) VALUES (1009, 3003)
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([Id], [HasServices], [Name], [HeadId]) VALUES (3003, 0, N'Information Technology', NULL)
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [EmpName], [EmpCode], [Designation], [MailAddress], [Unit], [Section], [Wing], [Team], [Groups], [Department], [TeamType], [Password], [Rank], [UserType], [TravelUserType], [Available], [Rating], [Raters], [Extension], [MobileNo], [Location], [Numbers]) VALUES (1007, N'Md. Golam Muktadir Asif', N'051188', N'Management Trainee Officer', N'md.asif@hameemgroup.com', N'Corporate Office', N'Recruitment & Selection', N'', N'', NULL, NULL, NULL, N'U2FsdFNhbHRTYWx0U2FsdMA2CUXFcecGX5zB3syQAbowWH1h/lS5aynYs3Vp5v5x', 2, N'admin', N'normal', 1, 0, 0, N'Not Available', N'01751634503', N'Not Available', 0)
INSERT [dbo].[Users] ([Id], [EmpName], [EmpCode], [Designation], [MailAddress], [Unit], [Section], [Wing], [Team], [Groups], [Department], [TeamType], [Password], [Rank], [UserType], [TravelUserType], [Available], [Rating], [Raters], [Extension], [MobileNo], [Location], [Numbers]) VALUES (1008, N'Ahmad Nafi-Us-Saleheen', N'051200', N'Management Trainee Officer', N'ahmad.saleheen@hameemgroup.com', N'Corporate Office', N'', N'', N'', NULL, NULL, NULL, N'U2FsdFNhbHRTYWx0U2FsdMA2CUXFcecGX5zB3syQAbowWH1h/lS5aynYs3Vp5v5x', 2, N'normal', N'normal', 1, 0, 0, N'Not Available', N'01746614860', N'Dhaka', 0)
INSERT [dbo].[Users] ([Id], [EmpName], [EmpCode], [Designation], [MailAddress], [Unit], [Section], [Wing], [Team], [Groups], [Department], [TeamType], [Password], [Rank], [UserType], [TravelUserType], [Available], [Rating], [Raters], [Extension], [MobileNo], [Location], [Numbers]) VALUES (1009, N'Taif Bin Islam', N'051916', N'Officer', N'taifhr@hameemgroup.com', N'Corporate Office', N'Compensation & Benefit', N'Corporate Office', N'Md. Taifur Rahman', NULL, NULL, NULL, N'U2FsdFNhbHRTYWx0U2FsdMA2CUXFcecGX5zB3syQAbowWH1h/lS5aynYs3Vp5v5x', 2, N'Ticket Manager (Department)', N'normal', 1, 0, 0, N'Not Available', N'01976794655', N'Dhaka', 0)
INSERT [dbo].[Users] ([Id], [EmpName], [EmpCode], [Designation], [MailAddress], [Unit], [Section], [Wing], [Team], [Groups], [Department], [TeamType], [Password], [Rank], [UserType], [TravelUserType], [Available], [Rating], [Raters], [Extension], [MobileNo], [Location], [Numbers]) VALUES (1010, N'Mohammad Moniruzzaman', N'000025', N'Manager', N'moniruzzaman@hameemgroup.com', N'Corporate Office', N'Core Accounts', N'', N'', NULL, NULL, NULL, N'U2FsdFNhbHRTYWx0U2FsdMA2CUXFcecGX5zB3syQAbowWH1h/lS5aynYs3Vp5v5x', 2, N'leader', N'normal', 1, 0, 0, N'Not Available', N'01915233571', N'Dhaka', 0)
INSERT [dbo].[Users] ([Id], [EmpName], [EmpCode], [Designation], [MailAddress], [Unit], [Section], [Wing], [Team], [Groups], [Department], [TeamType], [Password], [Rank], [UserType], [TravelUserType], [Available], [Rating], [Raters], [Extension], [MobileNo], [Location], [Numbers]) VALUES (1011, N'Rabiul Islam', N'006725', N'Officer', N'rabiulhr@hameemgroup.com', N'Corporate Office', N'Organizational Development', N'', N'', NULL, NULL, NULL, N'U2FsdFNhbHRTYWx0U2FsdMA2CUXFcecGX5zB3syQAbowWH1h/lS5aynYs3Vp5v5x', 2, N'support', N'normal', 1, 0, 0, N'Not Available', N'01742095736', N'Dhaka', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_ActionObject_ForwardedToId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ActionObject_ForwardedToId] ON [dbo].[ActionObject]
(
	[ForwardedToId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ActionObject_RaisedById]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ActionObject_RaisedById] ON [dbo].[ActionObject]
(
	[RaisedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ActionObject_TicketId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ActionObject_TicketId] ON [dbo].[ActionObject]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Blogs_AuthorId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Blogs_AuthorId] ON [dbo].[Blogs]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Chats_TicketId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Chats_TicketId] ON [dbo].[Chats]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConnectionHolderClass_ChatId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ConnectionHolderClass_ChatId] ON [dbo].[ConnectionHolderClass]
(
	[ChatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConversationClass_ChatId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ConversationClass_ChatId] ON [dbo].[ConversationClass]
(
	[ChatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ConversationClass_FromId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ConversationClass_FromId] ON [dbo].[ConversationClass]
(
	[FromId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetailsClass_TeamId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_DetailsClass_TeamId] ON [dbo].[DetailsClass]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetailsClass_TicketId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_DetailsClass_TicketId] ON [dbo].[DetailsClass]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_File2_ActionId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_File2_ActionId] ON [dbo].[File2]
(
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_File2_ConversationId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_File2_ConversationId] ON [dbo].[File2]
(
	[ConversationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_File2_NoteId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_File2_NoteId] ON [dbo].[File2]
(
	[NoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_File2_TicketId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_File2_TicketId] ON [dbo].[File2]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Mentions_NoteId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Mentions_NoteId] ON [dbo].[Mentions]
(
	[NoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Mentions_NotificationId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Mentions_NotificationId] ON [dbo].[Mentions]
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notes_TicketId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notes_TicketId] ON [dbo].[Notes]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notes_UserId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notes_UserId] ON [dbo].[Notes]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notifications_FromId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_FromId] ON [dbo].[Notifications]
(
	[FromId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notifications_TicketId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_TicketId] ON [dbo].[Notifications]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notifications_ToId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_ToId] ON [dbo].[Notifications]
(
	[ToId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProblemTypesClass_TeamId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProblemTypesClass_TeamId] ON [dbo].[ProblemTypesClass]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subordinates_TeamId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subordinates_TeamId] ON [dbo].[Subordinates]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subordinates_UserId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subordinates_UserId] ON [dbo].[Subordinates]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeamLeaders_TeamsLeadedId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeamLeaders_TeamsLeadedId] ON [dbo].[TeamLeaders]
(
	[TeamsLeadedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeamMonitors_TeamsMonitoredId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeamMonitors_TeamsMonitoredId] ON [dbo].[TeamMonitors]
(
	[TeamsMonitoredId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teams_HeadId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Teams_HeadId] ON [dbo].[Teams]
(
	[HeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_AssignedToId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_AssignedToId] ON [dbo].[Tickets]
(
	[AssignedToId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_CurrentHandlerId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_CurrentHandlerId] ON [dbo].[Tickets]
(
	[CurrentHandlerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_PrevHandlerId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_PrevHandlerId] ON [dbo].[Tickets]
(
	[PrevHandlerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_RaisedById]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_RaisedById] ON [dbo].[Tickets]
(
	[RaisedById] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_TicketingHeadId]    Script Date: 2/26/2024 12:13:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_TicketingHeadId] ON [dbo].[Tickets]
(
	[TicketingHeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActionObject]  WITH CHECK ADD  CONSTRAINT [FK_ActionObject_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActionObject] CHECK CONSTRAINT [FK_ActionObject_Tickets_TicketId]
GO
ALTER TABLE [dbo].[ActionObject]  WITH CHECK ADD  CONSTRAINT [FK_ActionObject_Users_ForwardedToId] FOREIGN KEY([ForwardedToId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ActionObject] CHECK CONSTRAINT [FK_ActionObject_Users_ForwardedToId]
GO
ALTER TABLE [dbo].[ActionObject]  WITH CHECK ADD  CONSTRAINT [FK_ActionObject_Users_RaisedById] FOREIGN KEY([RaisedById])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ActionObject] CHECK CONSTRAINT [FK_ActionObject_Users_RaisedById]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Users_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_Blogs_Users_AuthorId]
GO
ALTER TABLE [dbo].[Chats]  WITH CHECK ADD  CONSTRAINT [FK_Chats_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Chats] CHECK CONSTRAINT [FK_Chats_Tickets_TicketId]
GO
ALTER TABLE [dbo].[ConnectionHolderClass]  WITH CHECK ADD  CONSTRAINT [FK_ConnectionHolderClass_Chats_ChatId] FOREIGN KEY([ChatId])
REFERENCES [dbo].[Chats] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConnectionHolderClass] CHECK CONSTRAINT [FK_ConnectionHolderClass_Chats_ChatId]
GO
ALTER TABLE [dbo].[ConversationClass]  WITH CHECK ADD  CONSTRAINT [FK_ConversationClass_Chats_ChatId] FOREIGN KEY([ChatId])
REFERENCES [dbo].[Chats] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConversationClass] CHECK CONSTRAINT [FK_ConversationClass_Chats_ChatId]
GO
ALTER TABLE [dbo].[ConversationClass]  WITH CHECK ADD  CONSTRAINT [FK_ConversationClass_Users_FromId] FOREIGN KEY([FromId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ConversationClass] CHECK CONSTRAINT [FK_ConversationClass_Users_FromId]
GO
ALTER TABLE [dbo].[DetailsClass]  WITH CHECK ADD  CONSTRAINT [FK_DetailsClass_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetailsClass] CHECK CONSTRAINT [FK_DetailsClass_Teams_TeamId]
GO
ALTER TABLE [dbo].[DetailsClass]  WITH CHECK ADD  CONSTRAINT [FK_DetailsClass_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
GO
ALTER TABLE [dbo].[DetailsClass] CHECK CONSTRAINT [FK_DetailsClass_Tickets_TicketId]
GO
ALTER TABLE [dbo].[File2]  WITH CHECK ADD  CONSTRAINT [FK_File2_ActionObject_ActionId] FOREIGN KEY([ActionId])
REFERENCES [dbo].[ActionObject] ([Id])
GO
ALTER TABLE [dbo].[File2] CHECK CONSTRAINT [FK_File2_ActionObject_ActionId]
GO
ALTER TABLE [dbo].[File2]  WITH CHECK ADD  CONSTRAINT [FK_File2_ConversationClass_ConversationId] FOREIGN KEY([ConversationId])
REFERENCES [dbo].[ConversationClass] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[File2] CHECK CONSTRAINT [FK_File2_ConversationClass_ConversationId]
GO
ALTER TABLE [dbo].[File2]  WITH CHECK ADD  CONSTRAINT [FK_File2_Notes_NoteId] FOREIGN KEY([NoteId])
REFERENCES [dbo].[Notes] ([Id])
GO
ALTER TABLE [dbo].[File2] CHECK CONSTRAINT [FK_File2_Notes_NoteId]
GO
ALTER TABLE [dbo].[File2]  WITH CHECK ADD  CONSTRAINT [FK_File2_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
GO
ALTER TABLE [dbo].[File2] CHECK CONSTRAINT [FK_File2_Tickets_TicketId]
GO
ALTER TABLE [dbo].[Mentions]  WITH CHECK ADD  CONSTRAINT [FK_Mentions_Notes_NoteId] FOREIGN KEY([NoteId])
REFERENCES [dbo].[Notes] ([Id])
GO
ALTER TABLE [dbo].[Mentions] CHECK CONSTRAINT [FK_Mentions_Notes_NoteId]
GO
ALTER TABLE [dbo].[Mentions]  WITH CHECK ADD  CONSTRAINT [FK_Mentions_Notifications_NotificationId] FOREIGN KEY([NotificationId])
REFERENCES [dbo].[Notifications] ([Id])
GO
ALTER TABLE [dbo].[Mentions] CHECK CONSTRAINT [FK_Mentions_Notifications_NotificationId]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_Tickets_TicketId]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_Users_UserId]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Tickets_TicketId]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Users_FromId] FOREIGN KEY([FromId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Users_FromId]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Users_ToId] FOREIGN KEY([ToId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Users_ToId]
GO
ALTER TABLE [dbo].[ProblemTypesClass]  WITH CHECK ADD  CONSTRAINT [FK_ProblemTypesClass_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProblemTypesClass] CHECK CONSTRAINT [FK_ProblemTypesClass_Teams_TeamId]
GO
ALTER TABLE [dbo].[Subordinates]  WITH CHECK ADD  CONSTRAINT [FK_Subordinates_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subordinates] CHECK CONSTRAINT [FK_Subordinates_Teams_TeamId]
GO
ALTER TABLE [dbo].[Subordinates]  WITH CHECK ADD  CONSTRAINT [FK_Subordinates_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Subordinates] CHECK CONSTRAINT [FK_Subordinates_Users_UserId]
GO
ALTER TABLE [dbo].[TeamLeaders]  WITH CHECK ADD  CONSTRAINT [FK_TeamLeaders_Teams_TeamsLeadedId] FOREIGN KEY([TeamsLeadedId])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamLeaders] CHECK CONSTRAINT [FK_TeamLeaders_Teams_TeamsLeadedId]
GO
ALTER TABLE [dbo].[TeamLeaders]  WITH CHECK ADD  CONSTRAINT [FK_TeamLeaders_Users_LeadersId] FOREIGN KEY([LeadersId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamLeaders] CHECK CONSTRAINT [FK_TeamLeaders_Users_LeadersId]
GO
ALTER TABLE [dbo].[TeamMonitors]  WITH CHECK ADD  CONSTRAINT [FK_TeamMonitors_Teams_TeamsMonitoredId] FOREIGN KEY([TeamsMonitoredId])
REFERENCES [dbo].[Teams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamMonitors] CHECK CONSTRAINT [FK_TeamMonitors_Teams_TeamsMonitoredId]
GO
ALTER TABLE [dbo].[TeamMonitors]  WITH CHECK ADD  CONSTRAINT [FK_TeamMonitors_Users_MonitorsId] FOREIGN KEY([MonitorsId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeamMonitors] CHECK CONSTRAINT [FK_TeamMonitors_Users_MonitorsId]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Users_HeadId] FOREIGN KEY([HeadId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Users_HeadId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users_AssignedToId] FOREIGN KEY([AssignedToId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users_AssignedToId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users_CurrentHandlerId] FOREIGN KEY([CurrentHandlerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users_CurrentHandlerId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users_PrevHandlerId] FOREIGN KEY([PrevHandlerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users_PrevHandlerId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users_RaisedById] FOREIGN KEY([RaisedById])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users_RaisedById]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users_TicketingHeadId] FOREIGN KEY([TicketingHeadId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users_TicketingHeadId]
GO
USE [master]
GO
ALTER DATABASE [Ticketing] SET  READ_WRITE 
GO
