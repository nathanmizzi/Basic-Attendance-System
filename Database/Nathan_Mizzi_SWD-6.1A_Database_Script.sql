USE [master]
GO
/****** Object:  Database [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB]    Script Date: 13/01/2021 19:37:09 ******/
CREATE DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET QUERY_STORE = OFF
GO
USE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 13/01/2021 19:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Course] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 13/01/2021 19:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[LessonID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[TeacherID] [int] NOT NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 13/01/2021 19:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAttendance]    Script Date: 13/01/2021 19:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAttendance](
	[AttendanceID] [int] IDENTITY(1,1) NOT NULL,
	[LessonID] [int] NOT NULL,
	[Presence] [bit] NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_StudentAttendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 13/01/2021 19:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([GroupID], [Name], [Course]) VALUES (1, N'1A', N'Software Development')
INSERT [dbo].[Group] ([GroupID], [Name], [Course]) VALUES (2, N'2B', N'Network Engineering')
SET IDENTITY_INSERT [dbo].[Group] OFF
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (50, 1, CAST(N'2021-01-02T15:26:41.680' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (51, 1, CAST(N'2021-01-02T15:27:50.497' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (52, 1, CAST(N'2021-01-02T16:48:00.227' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (53, 1, CAST(N'2021-01-02T23:01:56.620' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (54, 1, CAST(N'2021-01-03T01:10:53.327' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (55, 1, CAST(N'2021-01-03T01:11:13.310' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (56, 1, CAST(N'2021-01-03T01:15:36.653' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (57, 1, CAST(N'2021-01-11T19:15:25.747' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (58, 1, CAST(N'2021-01-11T19:15:31.163' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (59, 1, CAST(N'2021-01-11T19:15:37.490' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (60, 1, CAST(N'2021-01-11T19:16:05.763' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (61, 2, CAST(N'2021-01-12T10:33:54.013' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (62, 1, CAST(N'2021-01-12T13:21:14.843' AS DateTime), 1)
INSERT [dbo].[Lesson] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (63, 2, CAST(N'2021-01-13T17:12:43.623' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Lesson] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (1, N'Frank', N'Borg', N'fborg@gmail.com', 1)
INSERT [dbo].[Student] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (2, N'Edward', N'Tonna', N'etonna@gmail.com', 1)
INSERT [dbo].[Student] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (3, N'Thomas', N'Zarb', N'tzarb@gmail.com', 2)
INSERT [dbo].[Student] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (4, N'Justin', N'Regal', N'jregal@gmail.com', 2)
INSERT [dbo].[Student] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (5, N'Samuel', N'Higgins', N'shiggins@gmail.com', 2)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentAttendance] ON 

INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (1, 56, 1, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (2, 56, 0, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (3, 57, 1, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (4, 57, 1, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (5, 58, 1, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (6, 58, 1, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (7, 59, 1, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (8, 59, 1, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (9, 60, 0, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (10, 60, 0, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (11, 61, 1, 3)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (12, 61, 1, 4)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (13, 62, 1, 1)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (14, 62, 1, 2)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (15, 63, 1, 3)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (16, 63, 1, 4)
INSERT [dbo].[StudentAttendance] ([AttendanceID], [LessonID], [Presence], [StudentID]) VALUES (17, 63, 0, 5)
SET IDENTITY_INSERT [dbo].[StudentAttendance] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherID], [Username], [Password], [Name], [Surname], [Email]) VALUES (1, N'janB1', N'janEdu1', N'Janice', N'Borg', N'jBorg@gmail.com')
INSERT [dbo].[Teacher] ([TeacherID], [Username], [Password], [Name], [Surname], [Email]) VALUES (7, N'testaccount', N'test', N'Test', N'Account', N'test@gmail.com')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Group]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Group]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_Lesson] FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lesson] ([LessonID])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_Lesson]
GO
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_Student]
GO
USE [master]
GO
ALTER DATABASE [Nathan_Mizzi_IT-SWD-6.1A_OOP_Assignment_DB] SET  READ_WRITE 
GO
