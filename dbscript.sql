USE [master]
GO
/****** Object:  Database [ThunderDuck]    Script Date: 10/29/2018 10:29:08 PM ******/
CREATE DATABASE [ThunderDuck]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ThunderDuck', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ThunderDuck.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ThunderDuck_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ThunderDuck_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ThunderDuck] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ThunderDuck].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ThunderDuck] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ThunderDuck] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ThunderDuck] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ThunderDuck] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ThunderDuck] SET ARITHABORT OFF 
GO
ALTER DATABASE [ThunderDuck] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ThunderDuck] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ThunderDuck] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ThunderDuck] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ThunderDuck] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ThunderDuck] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ThunderDuck] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ThunderDuck] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ThunderDuck] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ThunderDuck] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ThunderDuck] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ThunderDuck] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ThunderDuck] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ThunderDuck] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ThunderDuck] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ThunderDuck] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ThunderDuck] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ThunderDuck] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ThunderDuck] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ThunderDuck] SET  MULTI_USER 
GO
ALTER DATABASE [ThunderDuck] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ThunderDuck] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ThunderDuck] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ThunderDuck] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ThunderDuck]
GO
/****** Object:  Table [dbo].[Td_BrandMaker_AreaType]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_AreaType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[Filter] [nvarchar](50) NULL,
 CONSTRAINT [PK_Td_AreaType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_BrandMaker_Contact]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_Contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Hotline] [nvarchar](max) NULL,
	[Headaddress] [nvarchar](300) NULL,
	[OfficeAddress] [nvarchar](300) NULL,
	[Phone1] [nvarchar](max) NULL,
	[Email1] [nvarchar](max) NULL,
	[Email2] [nvarchar](max) NULL,
 CONSTRAINT [PK_Td_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_BrandMaker_Events]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_Events](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Price] [nvarchar](100) NULL,
	[Description] [nvarchar](1000) NULL,
	[Images] [nvarchar](50) NULL,
	[TypeId] [int] NULL,
	[Amount] [nvarchar](50) NULL,
 CONSTRAINT [PK_Td_Event] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_BrandMaker_Images]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_Images](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[images1] [nvarchar](50) NULL,
	[Subtitle] [nvarchar](50) NULL,
	[Title] [nvarchar](150) NULL,
 CONSTRAINT [PK_Td_Images] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_BrandMaker_Members]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_Members](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Subtitle] [nvarchar](200) NULL,
	[Images] [nvarchar](50) NULL,
 CONSTRAINT [PK_Td_Member] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_BrandMaker_News]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_News](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Images] [nvarchar](50) NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_Td_News] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_BrandMaker_Slider]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_Slider](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Description] [nvarchar](200) NULL,
	[Video] [nvarchar](200) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Logo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Td_Slider] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_BrandMaker_Story]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_Story](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Description] [nvarchar](500) NULL,
	[Signature] [nvarchar](50) NULL,
	[Images] [nvarchar](50) NULL,
	[Description1] [nvarchar](500) NULL,
 CONSTRAINT [PK_Td_Story] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_BrandMaker_Tours]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_BrandMaker_Tours](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [nvarchar](50) NULL,
	[Images] [nvarchar](50) NULL,
 CONSTRAINT [PK_Td_Tour] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_Construction_Construction]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_Construction_Construction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Images] [nvarchar](50) NULL,
	[Avatar] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Td_Construction_Construction] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_Construction_Contact]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_Construction_Contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[HeadAddress] [nvarchar](300) NULL,
	[OfficeAddress] [nvarchar](300) NULL,
	[Email] [nvarchar](max) NULL,
	[Email1] [nvarchar](max) NULL,
	[Email2] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Phone1] [nvarchar](max) NULL,
	[Hotline] [nvarchar](max) NULL,
 CONSTRAINT [PK_Td_Construction_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_Construction_Images]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_Construction_Images](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Images] [nvarchar](50) NULL,
 CONSTRAINT [PK_Td_Construction_Images] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_Construction_Member]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_Construction_Member](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Subtitle] [nvarchar](150) NULL,
	[Images] [nvarchar](50) NULL,
	[Introduction] [nvarchar](200) NULL,
 CONSTRAINT [PK_Td_Construction_Member] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_Construction_New]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_Construction_New](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](200) NULL,
	[Images] [nvarchar](50) NULL,
 CONSTRAINT [PK_Td_Construction_New] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_Construction_Slider]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_Construction_Slider](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Logo] [nvarchar](50) NULL,
	[Title] [nvarchar](150) NULL,
	[Subtitle] [nvarchar](200) NULL,
	[Images] [nvarchar](50) NULL,
	[Images1] [nvarchar](50) NULL,
	[Images2] [nvarchar](50) NULL,
	[Title1] [nvarchar](150) NULL,
	[Subtitle1] [nvarchar](200) NULL,
	[Title2] [nvarchar](150) NULL,
	[Subtitle2] [nvarchar](200) NULL,
 CONSTRAINT [PK_Td_Construction_Slider] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Td_Constrution_Story]    Script Date: 10/29/2018 10:29:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Td_Constrution_Story](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Signature] [nvarchar](50) NULL,
	[Images] [nvarchar](50) NULL,
	[Description1] [nvarchar](500) NULL,
 CONSTRAINT [PK_Td_Constrution_Story] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_AreaType] ON 

INSERT [dbo].[Td_BrandMaker_AreaType] ([id], [Type], [Filter]) VALUES (1, N'Toàn Bộ', N'all')
INSERT [dbo].[Td_BrandMaker_AreaType] ([id], [Type], [Filter]) VALUES (2, N'Miền Đông', N'.east')
INSERT [dbo].[Td_BrandMaker_AreaType] ([id], [Type], [Filter]) VALUES (3, N'Miền Tây', N'.west')
INSERT [dbo].[Td_BrandMaker_AreaType] ([id], [Type], [Filter]) VALUES (4, N'Miền Trung', N'.central')
INSERT [dbo].[Td_BrandMaker_AreaType] ([id], [Type], [Filter]) VALUES (5, N'Nước Ngoài', N'.foreign')
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_AreaType] OFF
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Contact] ON 

INSERT [dbo].[Td_BrandMaker_Contact] ([id], [Email], [Phone], [Hotline], [Headaddress], [OfficeAddress], [Phone1], [Email1], [Email2]) VALUES (1, N'abcd@gmail.com', N'(+8423) 1234 4654', N'(+84) 741 852 963', N'Số 6, Nguyễn Đình Chiểu, Phường Đa Kao, Quận 1, TP HCM', N'Số 100, Song Hành, Phường Anh Phú, Quận 2, TP HCM', N'(+84) 852 963 741', N'abc1@gmail.com', N'abc2@gmail.com')
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Contact] OFF
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Events] ON 

INSERT [dbo].[Td_BrandMaker_Events] ([id], [Title], [Price], [Description], [Images], [TypeId], [Amount]) VALUES (2, N'Singapore - Malaysia', N'9.000.000/1 Người', N'Singapore là một thành phố quốc tế sầm uất với nhiều tòa nhà cao tầng, công viên và địa điểm giàu nét văn hóa. Singapore cũng là nơi giao thoa của những nét đẹp tinh túy nhất từ phương Đông và phương Tây.', N'sin-malay.png', 1, NULL)
INSERT [dbo].[Td_BrandMaker_Events] ([id], [Title], [Price], [Description], [Images], [TypeId], [Amount]) VALUES (3, N'Bangkok - Pattaya', N'15.000.000/2 người', N'Cùng khám phá tổng quan về Bangkok, một đô thị lớn sầm uất phát triển không ngừng, thủ đô của Thái Lan là một điểm đến hấp dẫn nhất khu vực Đông Nam Á.', N'promo3.jpg', 1, NULL)
INSERT [dbo].[Td_BrandMaker_Events] ([id], [Title], [Price], [Description], [Images], [TypeId], [Amount]) VALUES (4, N'Sài Gòn - Mỹ Tho - Cần Thơ - Châu Đốc', N'4.000.000/10 Người', N'Vùng đồng bằng sông Cửu Long là vùng cực Nam của Việt Nam, hay còn gọi là vùng đồng bằng sông Mê Kông, vùng đồng bằng Nam Bộ hoặc miền Tây Nam Bộ hoặc nói ngắn gọn là miền Tây thì người dân Việt Nam cũng có thể hiểu được.', N'bangkok-pattaya.jpg', 1, NULL)
INSERT [dbo].[Td_BrandMaker_Events] ([id], [Title], [Price], [Description], [Images], [TypeId], [Amount]) VALUES (5, N'Sài Gòn–Mỹ Tho–Cần Thơ–Sóc Trăng–Bạc Liêu–Cần Thơ', N'4.000.000/10 Người', N'Miền Tây nổi tiếng với nhiều kênh rạch chằng chịt, sông ngòi dày đặc. Các con sông này nguồn nước dẫn chủ yếu là từ sông Cửu Long (Cửu Long giang), là tên gọi chung cho các phân lưu của sông Mê Kông chảy trên lãnh thổ của Việt Nam.', N'promo1.jpg', 2, NULL)
INSERT [dbo].[Td_BrandMaker_Events] ([id], [Title], [Price], [Description], [Images], [TypeId], [Amount]) VALUES (6, N'Sài Gòn-Mỹ Tho-Cần Thơ-Châu Đốc-Đồng Tháp', N'3.000.000/2 Người', N'Miền Tây Nam Bộ gồm có 12 tỉnh (An Giang, Bạc Liêu, Bến Tre, Cà Mau, Đồng Tháp, Tiền Giang, Sóc Trăng, Long An, Hậu Giang, Kiên Giang, Trà Vinh, Vĩnh Long) và 1 thành phố trực thuộc Trung ương (Cần Thơ).', N'footer.jpg', 3, NULL)
INSERT [dbo].[Td_BrandMaker_Events] ([id], [Title], [Price], [Description], [Images], [TypeId], [Amount]) VALUES (7, N'Singapore-Malaysia', N'5.000.000/1 Người', N'Singapore là một thành phố quốc tế sầm uất với nhiều tòa nhà cao tầng, công viên và địa điểm giàu nét văn hóa. Singapore cũng là nơi giao thoa của những nét đẹp tinh túy nhất từ phương Đông và phương Tây.', N'2.jpg', 5, NULL)
INSERT [dbo].[Td_BrandMaker_Events] ([id], [Title], [Price], [Description], [Images], [TypeId], [Amount]) VALUES (8, N'Sài Gòn–Mỹ Tho–Cần Thơ–Châu Dốc–Hà Tiên–Phú Quốc', N'2.500.000/1 Người', N'Phú Quốc là điểm nghỉ dưỡng, tham quan, và khám phá sinh thái tuyệt vời. Bãi Sao cát trắng mịn, dáng cong, nước xanh ngọc bích. Phú Quốc thực sự là một viên ngọc quý trên bản đồ Việt Nam.', N'4.jpg', 3, NULL)
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Events] OFF
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Images] ON 

INSERT [dbo].[Td_BrandMaker_Images] ([id], [images1], [Subtitle], [Title]) VALUES (1, N'bg2.jpg', N'Hình ảnh', NULL)
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Images] OFF
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Members] ON 

INSERT [dbo].[Td_BrandMaker_Members] ([id], [Title], [Subtitle], [Images]) VALUES (2, N'ĐOÀN THANH THẢO ( Jasmine Đoan )', N'CEO - Thunder Duck Groupa', N'team-2.jpg')
INSERT [dbo].[Td_BrandMaker_Members] ([id], [Title], [Subtitle], [Images]) VALUES (9, N'ĐOÀN THANH THẢO A ( Jasmine Đoan )', N'CEO - Thunder Duck Groupp', N'team-3.jpg')
INSERT [dbo].[Td_BrandMaker_Members] ([id], [Title], [Subtitle], [Images]) VALUES (10, N'ĐOÀN THANH THẢO ( Jasmine Đoan )', N'CEO - Thunder Duck Groupp', N'team-2.jpg')
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Members] OFF
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_News] ON 

INSERT [dbo].[Td_BrandMaker_News] ([id], [Title], [Images], [Description]) VALUES (2, N'Trải nghiệm mô hình du lịch mới tại Sa Pa', N'blog1.jpg', N'Sau một thời gian gây dựng mô hình du lịch sinh thái, vườn dâu tây của gia đình anh Trần Tuấn Nghĩa đã thu hút được rất nhiều khách du lịch')
INSERT [dbo].[Td_BrandMaker_News] ([id], [Title], [Images], [Description]) VALUES (3, N'Lên Đà Lạt một ngày làm nông dân thu hoạch dâu tây', N'blog2.jpg', N'Đến ĐL, một trải nghiệm rất thú vị mà bất kỳ khách du lịch nào cũng không thể bỏ qua là ghé tham quan và thu hoạch dâu tươi ngay tại vườn.')
INSERT [dbo].[Td_BrandMaker_News] ([id], [Title], [Images], [Description]) VALUES (4, N'Can thiệp quyết định mua hàng, lời nào cho Marketing?', N'blog3.jpg', N'Vâng, 5 bước đưa ra 1 quyết định mua hàng và quyết định có quay lại với bạn sau khi đã sử dụng sản phẩm, hoặc dịch vụ của bạn không!')
INSERT [dbo].[Td_BrandMaker_News] ([id], [Title], [Images], [Description]) VALUES (6, N'Trải nghiệm mô hình du lịch mới tại Nha Trang', N'blog3.jpg', N'Sau một thời gian gây dựng mô hình du lịch nghỉ mát kết hợp khu du lịch sinh thái ở Nha Trang đã thu hút được rất nhiều khách du lịch')
INSERT [dbo].[Td_BrandMaker_News] ([id], [Title], [Images], [Description]) VALUES (7, N'Lên Buôn Mê Thuột một ngày làm nông dân thu hoạch cà phê', N'blog-1.jpg', N'Đến Buôn Mê Thuột, một trải nghiệm rất thú vị mà bất kỳ khách du lịch nào cũng không thể bỏ qua là ghé tham quan và thu hoạch cà phê ngay tại vườn.')
INSERT [dbo].[Td_BrandMaker_News] ([id], [Title], [Images], [Description]) VALUES (9, N'Can thiệp quyết định mua hàng, lời nào cho Marketing?', N'blog-3.jpg', N'Vâng, 5 bước đưa ra 1 quyết định mua hàng và quyết định có quay lại với bạn sau khi đã sử dụng sản phẩm, hoặc dịch vụ của bạn không!')
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_News] OFF
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Slider] ON 

INSERT [dbo].[Td_BrandMaker_Slider] ([id], [Title], [Description], [Video], [Email], [Phone], [Logo]) VALUES (1, N'Chào mừng đến với', N'Thunder Duck Brand & Maker', N'https://www.youtube.com/watch?v=P_q3BdrFsLI', N'abc@thunderduckgroup.com.vn', N'+84 123 456 789', N'logo-main3.png')
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Slider] OFF
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Story] ON 

INSERT [dbo].[Td_BrandMaker_Story] ([id], [Title], [Description], [Signature], [Images], [Description1]) VALUES (1, N'Câu chuyện của chúng tôi', N'Hai con người cùng chung một chí hướng và đam mê, một người xây nhà một người tô điểm thêm nhiều sắc màu cho ngôi nhà chung mang tên THUNDER DUCK - CHÚ VỊT SẤM SÉT. Đó là câu chuyện về một ngày trời nắng gắt, bỗng trở nên dịu dàng hơn với vầng mây trôi ngang trên đầu hai cô gái, bất thình lình từ trong đám mây những tiếng SẤM vang trời như muốn xé toạt màn mây đánh dấu những tia SÉT đầy năng lượng và ánh sáng ', N'signature.png', N'home-about.png', N'mở lối cho hai cô gái bước vào hành trình cuộc đời, những ngã rẽ của sự nghiệp chỉ với 2 cô gái với 3 ngành nghề:
         1. Tư Vấn Thiết Kế - Thi Công Xây Dựng.
         2. Events - Marketing.
         3. Sản Xuất - Nhập Khẩu - Phân Phối Hóa Mỹ Phẩm.      
CHÚ VỊT SẤM SÉT - THUNDER DUCK GROUP')
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Story] OFF
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Tours] ON 

INSERT [dbo].[Td_BrandMaker_Tours] ([id], [Title], [Description], [Price], [Images]) VALUES (1, N'Trung Quốc - Hàn Quốc', N'Thưởng lãm những thắng cảnh nổi tiếng tại 2 quốc gia: Trung Quốc - Hàn Quốc', N'10.000.000/1 người', N'3.jpg')
INSERT [dbo].[Td_BrandMaker_Tours] ([id], [Title], [Description], [Price], [Images]) VALUES (2, N'Phượng Hoàng Cổ Trấn - Trung Quốc', N'Thưởng lãm phong cảnh cổ xưa ở Phượng Hoàng Cổ Trấn - Trung Quốc', N'15.000.000/2 người', N'5.jpg')
INSERT [dbo].[Td_BrandMaker_Tours] ([id], [Title], [Description], [Price], [Images]) VALUES (4, N'Đà Lạt - Việt Nam', N'Thưởng lãm phong cảnh nổi tiếng ở Đà Lạt - Việt Nam', N'7.000.000/4 người', N'1.jpg')
SET IDENTITY_INSERT [dbo].[Td_BrandMaker_Tours] OFF
SET IDENTITY_INSERT [dbo].[Td_Construction_Construction] ON 

INSERT [dbo].[Td_Construction_Construction] ([id], [Title], [Images], [Avatar], [Description]) VALUES (3, N'Công trình Quận 2', N'3.jpg,slide_2.jpg,slide_3.jpg', N'1.jpg', N'Công trình nhà liền kề')
INSERT [dbo].[Td_Construction_Construction] ([id], [Title], [Images], [Avatar], [Description]) VALUES (4, N'Công trình Quận 3', N'1.jpg,3.jpg,slide_3.jpg', N'slide_2.jpg', N'Công trình nhà liền kề')
INSERT [dbo].[Td_Construction_Construction] ([id], [Title], [Images], [Avatar], [Description]) VALUES (5, N'Công trình Quận 4', N'1.jpg,3.jpg,slide_2.jpg', N'slide_3.jpg', N'Công trình nhà liền kề')
INSERT [dbo].[Td_Construction_Construction] ([id], [Title], [Images], [Avatar], [Description]) VALUES (6, N'Công trình Quận 1', N'7.png,slide_2.jpg,slide_3.jpg', N'1.jpg', N'Công trình nhà liền kề')
INSERT [dbo].[Td_Construction_Construction] ([id], [Title], [Images], [Avatar], [Description]) VALUES (7, N'Công trình Quận Gò Vấp', N'5.jpg,6.jpg,slide_2.jpg', N'3.jpg', N'Công trình nhà liền kề')
INSERT [dbo].[Td_Construction_Construction] ([id], [Title], [Images], [Avatar], [Description]) VALUES (8, N'Công trình Quận Bình Thạnh', N'5.jpg,6.jpg,7.png', N'slide_3.jpg', N'Công trình nhà liền kề')
SET IDENTITY_INSERT [dbo].[Td_Construction_Construction] OFF
SET IDENTITY_INSERT [dbo].[Td_Construction_Contact] ON 

INSERT [dbo].[Td_Construction_Contact] ([id], [HeadAddress], [OfficeAddress], [Email], [Email1], [Email2], [Phone], [Phone1], [Hotline]) VALUES (1, N'Số 4, Nguyễn Đình Chiểu, Phường Đa Kao, Quận 1, Thành Phố Hồ Chí Minh', N'Số 100, Song Hành, Phường Anh Phú, Quận 2, Thành Phố Hồ Chí Minh', N'admin@thunderduck.com.vn', N'jasmine.doan@thunderduck.com.vn', N'lucynguyen@thunderduck.com.vn', N'(+8428) 6650 7678', N'+84 981 406 778', N'+84 961 404 441')
SET IDENTITY_INSERT [dbo].[Td_Construction_Contact] OFF
SET IDENTITY_INSERT [dbo].[Td_Construction_Images] ON 

INSERT [dbo].[Td_Construction_Images] ([id], [Title], [Images]) VALUES (2, N'Công trình văn phòng', N'3.jpg')
INSERT [dbo].[Td_Construction_Images] ([id], [Title], [Images]) VALUES (3, N'Công trình ở nhà', N'7.png')
INSERT [dbo].[Td_Construction_Images] ([id], [Title], [Images]) VALUES (4, N'Góc vui chơi', N'5.jpg')
INSERT [dbo].[Td_Construction_Images] ([id], [Title], [Images]) VALUES (5, N'Ngày mới', N'3.jpg')
INSERT [dbo].[Td_Construction_Images] ([id], [Title], [Images]) VALUES (6, N'Trung tâm thành phố', N'4.jpg')
INSERT [dbo].[Td_Construction_Images] ([id], [Title], [Images]) VALUES (7, N'Khu đô thị sang trọng', N'2.jpg')
INSERT [dbo].[Td_Construction_Images] ([id], [Title], [Images]) VALUES (8, N'Chung cư', N'5.jpg')
INSERT [dbo].[Td_Construction_Images] ([id], [Title], [Images]) VALUES (9, N'Công trình ở nhà', N'5.jpg')
SET IDENTITY_INSERT [dbo].[Td_Construction_Images] OFF
SET IDENTITY_INSERT [dbo].[Td_Construction_Member] ON 

INSERT [dbo].[Td_Construction_Member] ([id], [Title], [Subtitle], [Images], [Introduction]) VALUES (2, N'Doan Thanh Thao', N'CEO - Thunder Duck Group', N'team-1.jpg', N'CEO - Thunder Duck Construction')
INSERT [dbo].[Td_Construction_Member] ([id], [Title], [Subtitle], [Images], [Introduction]) VALUES (3, N'Doan Thanh Thao', N'CEO - Thunder Duck Group 2', N'team-2.jpg', N'CEO - Thunder Duck Construction 2')
INSERT [dbo].[Td_Construction_Member] ([id], [Title], [Subtitle], [Images], [Introduction]) VALUES (4, N'Doan Thanh Thao', N'CEO - Thunder Duck Group 3', N'team-3.jpg', N'CEO - Thunder Duck Construction 3')
INSERT [dbo].[Td_Construction_Member] ([id], [Title], [Subtitle], [Images], [Introduction]) VALUES (5, N'Doan Thanh Thao', N'CEO - Thunder Duck Group 4', N'team-4.jpg', N'CEO - Thunder Duck Construction 4')
INSERT [dbo].[Td_Construction_Member] ([id], [Title], [Subtitle], [Images], [Introduction]) VALUES (6, N'Đoàn Thanh Thảo', N'CEO - Thunder Duck Group 6', N'team-5.jpg', N'CEO - Thunder Duck Construction 6')
INSERT [dbo].[Td_Construction_Member] ([id], [Title], [Subtitle], [Images], [Introduction]) VALUES (7, N'Doan Thanh Thao', N'CEO - Thunder Duck Group 10', N'team-4.jpg', N'CEO - Thunder Duck Construction 10')
INSERT [dbo].[Td_Construction_Member] ([id], [Title], [Subtitle], [Images], [Introduction]) VALUES (8, N'Doan Thanh Thao 2', N'CEO - Thunder Duck Group 22', N'team-1.jpg', N'CEO - Thunder Duck Construction 22')
SET IDENTITY_INSERT [dbo].[Td_Construction_Member] OFF
SET IDENTITY_INSERT [dbo].[Td_Construction_New] ON 

INSERT [dbo].[Td_Construction_New] ([id], [Title], [Description], [Images]) VALUES (2, N'Trải nghiệm mô hình du lịch mới tại Sa Pa', N'Sau một thời gian gây dựng mô hình du lịch sinh thái, vườn dâu tây của gia đình anh Trần Tuấn Nghĩa ở Sa Pa đã thu hút nhiều du khách.', N'blog1.jpg')
INSERT [dbo].[Td_Construction_New] ([id], [Title], [Description], [Images]) VALUES (4, N'Can thiệp quyết định mua hàng, lời nào cho Marketing?', N'Vâng, 5 bước đưa ra 1 quyết định mua hàng và quyết định có quay lại với bạn sau khi đã sử dụng sản phẩm, hoặc dịch vụ của bạn không!', N'blog2.jpg')
INSERT [dbo].[Td_Construction_New] ([id], [Title], [Description], [Images]) VALUES (5, N'Trải nghiệm mô hình du lịch mới tại Đà Nẵng', N'Sau một thời gian gây dựng mô hình du lịch sinh thái, vườn dâu tây của gia đình anh Trần Tuấn Nghĩa ở Sa Pa đã thu hút nhiều du khách.', N'blog-1.jpg')
SET IDENTITY_INSERT [dbo].[Td_Construction_New] OFF
SET IDENTITY_INSERT [dbo].[Td_Construction_Slider] ON 

INSERT [dbo].[Td_Construction_Slider] ([id], [Email], [Phone], [Logo], [Title], [Subtitle], [Images], [Images1], [Images2], [Title1], [Subtitle1], [Title2], [Subtitle2]) VALUES (1, N'info@thunderduck.com.vn', N' +84 961 404 441', N'logo-main3.png', N'Chào mừng bạn đến vớii', N'THUNDER DUCK CONSTRUCTIONN', N'slide_2.jpg', N'slide_3.jpg', N'1.jpg', N'THUNDER DUCK DESIGN OFFICEE', N'Thiết Kế Văn Phòng Đa Năng, Tiện Dụng', N'THUNDER DUCK COSTRUCTION', N'Chúng tôi xây dựng văn phòng cho bạnn')
SET IDENTITY_INSERT [dbo].[Td_Construction_Slider] OFF
SET IDENTITY_INSERT [dbo].[Td_Constrution_Story] ON 

INSERT [dbo].[Td_Constrution_Story] ([id], [Title], [Description], [Signature], [Images], [Description1]) VALUES (1, N'Câu chuyện của chúng tôi ', N'Hai con người cùng chung một chí hướng và đam mê, một người xây nhà một người tô điểm thêm nhiều sắc màu cho ngôi nhà chung mang tên THUNDER DUCK - CHÚ VỊT SẤM SÉT. Đó là câu chuyện về một ngày trời nắng gắt, bỗng trở nên dịu dàng hơn với vầng mây trôi ngang trên đầu hai cô gái, bất thình lình từ trong đám mây những tiếng SẤM vang trời như muốn xé toạt màn mây đánh dấu những tia SÉT đầy năng lượng và ánh sáng mở lối cho hai cô gái bước vào hành trình cuộc đời', N'signature.png', N'home-about.png', N'những ngã rẽ của sự nghiệp chỉ với 2 cô gái cho 3 ngành nghề :
1. Tư Vấn Thiết Kế, Thi Công Xây Dựng
2. Events - Marketing
3. Sản Xuất - Nhập Khẩu - Phân Phối Hoá Mỹ Phẩm
CHÚ VỊT SẤM SÉT - THUNDER DUCK GROUP')
SET IDENTITY_INSERT [dbo].[Td_Constrution_Story] OFF
USE [master]
GO
ALTER DATABASE [ThunderDuck] SET  READ_WRITE 
GO
