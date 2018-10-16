USE [MickMVC]
GO
/****** 对象:  Table [dbo].[gjjZhiquHistory]    脚本日期: 08/21/2018 16:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[gjjZhiquHistory](
	[hisNum] [bigint] NOT NULL,
	[hisName] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[hisID] [varchar](36) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_gjjZhiquHistory_hisID]  DEFAULT ('0'),
	[hisDate] [datetime] NULL,
	[hisMoney] [decimal](26, 2) NULL,
	[hisType] [nvarchar](20) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_gjjZhiquHistory_hisType]  DEFAULT ('其他'),
	[hisOperator] [varchar](5) COLLATE Chinese_PRC_CI_AS NULL,
	[hisCount] [int] NULL,
	[hisDaNum] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_gjjZhiquHistory_hisDaNum]  DEFAULT (NULL),
	[hisRemark] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[hisNetwork] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[hisRemark2] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[hisNumStr] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[hisTypeSub] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_gjjZhiquHistory_hisTypeSub]  DEFAULT (''),
	[hisgjjID] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[hisImportDate] [datetime] NULL,
	[hiswtspNum] [bigint] NULL,
	[hisWork] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[hiszrAccount] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[hiszrAccName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[hisStateFlag] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_gjjZhiquHistory_hisStateFlag]  DEFAULT ('0'),
 CONSTRAINT [PK_gjjZhiquHistory] PRIMARY KEY CLUSTERED 
(
	[hisNum] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF



USE [MickMVC]
GO
/****** 对象:  Table [dbo].[Rights]    脚本日期: 08/21/2018 16:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rights](
	[RightID] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RightDesc] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RightUrl] [nvarchar](300) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RightName] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_Right] PRIMARY KEY CLUSTERED 
(
	[RightID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



USE [MickMVC]
GO
/****** 对象:  Table [dbo].[RoleRight]    脚本日期: 08/21/2018 16:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleRight](
	[RightID] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RoleID] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RoleRightDesc] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_dbo.RoleRights] PRIMARY KEY CLUSTERED 
(
	[RightID] ASC,
	[RoleID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



USE [MickMVC]
GO
/****** 对象:  Table [dbo].[Roles]    脚本日期: 08/21/2018 16:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RoleName] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RoleLevel] [int] NOT NULL,
	[RoleDesc] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



USE [MickMVC]
GO
/****** 对象:  Table [dbo].[UserRole]    脚本日期: 08/21/2018 16:22:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserID] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[RoleID] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



USE [MickMVC]
GO
/****** 对象:  Table [dbo].[Users]    脚本日期: 08/21/2018 16:22:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[UserName] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[UserAccount] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[UserCertNo] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NULL,
	[UserCertType] [nvarchar](2) COLLATE Chinese_PRC_CI_AS NULL,
	[UserPhone] [nvarchar](36) COLLATE Chinese_PRC_CI_AS NULL,
	[UserPwd] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[UserUnit] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[UserPwdConfirm] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[Discriminator] [nvarchar](128) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ValidateCode] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
