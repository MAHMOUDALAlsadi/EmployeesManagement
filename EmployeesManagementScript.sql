USE [EmployeesManagement]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 12/8/2021 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 12/8/2021 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/8/2021 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Salary] [money] NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdateOn] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (1, N'Jordan')
GO
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (2, N'KSA')
GO
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (3, N'USA')
GO
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (4, N'UK')
GO
INSERT [dbo].[Country] ([CountryId], [Name]) VALUES (5, N'UEA')
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([DepartmentId], [Name]) VALUES (1, N'IT')
GO
INSERT [dbo].[Department] ([DepartmentId], [Name]) VALUES (2, N'Support')
GO
INSERT [dbo].[Department] ([DepartmentId], [Name]) VALUES (3, N'Audit')
GO
INSERT [dbo].[Department] ([DepartmentId], [Name]) VALUES (4, N'Financial')
GO
INSERT [dbo].[Department] ([DepartmentId], [Name]) VALUES (5, N'HR')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([EmployeeId], [FullName], [DepartmentId], [Salary], [PhoneNumber], [CountryId], [CreatedOn], [UpdateOn]) VALUES (1, N'Mahmoud Alsadii', 2, 1200.0000, N'0786103701', 3, CAST(N'2021-12-08T00:15:00.140' AS DateTime), CAST(N'2021-12-08T00:29:15.413' AS DateTime))
GO
INSERT [dbo].[Employee] ([EmployeeId], [FullName], [DepartmentId], [Salary], [PhoneNumber], [CountryId], [CreatedOn], [UpdateOn]) VALUES (2, N'Mahmoud Alsadi', 1, 1000.0000, N'0786103700', 1, CAST(N'2021-12-08T00:15:19.197' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Country]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 12/8/2021 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddEmployee]
(
	@FullName		NVARCHAR(50),
	@DepartmentId	INT,
	@PhoneNumber	NVARCHAR(50),
	@CountryId		INT,
	@CreatedOn		DATETIME,
	@Salary			MONEY
)
AS
SET NOCOUNT ON
BEGIN TRY

	INSERT [dbo].[Employee] (FullName, DepartmentId, Salary, PhoneNumber, CountryId, CreatedOn, UpdateOn)
	VALUES					(@FullName,@DepartmentId,@Salary, @PhoneNumber,@CountryId,@CreatedOn, NULL)


END TRY
BEGIN CATCH
    DECLARE @ErrorMessage Nvarchar(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;


    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();


    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 12/8/2021 12:33:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployee]
(
	@EmployeeId		INT,
	@FullName		NVARCHAR(50),
	@DepartmentId	INT,
	@PhoneNumber	NVARCHAR(50),
	@CountryId		INT,
	@UpdateOn		DATETIME = NULL,
	@Salary			MONEY
)
AS
SET NOCOUNT ON
BEGIN TRY

UPDATE [dbo].[Employee]
SET		FullName	 = @FullName,
		DepartmentId = @DepartmentId,	
		PhoneNumber	 = @PhoneNumber,	
		CountryId	 = @CountryId,		
		UpdateOn	 = @UpdateOn,	
		Salary		 = @Salary	
WHERE	EmployeeId	 = @EmployeeId		

END TRY
BEGIN CATCH
    DECLARE @ErrorMessage Nvarchar(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;


    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();


    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
END CATCH

GO
