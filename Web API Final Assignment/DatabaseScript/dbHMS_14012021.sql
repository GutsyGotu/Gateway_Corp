USE [dbHMS]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 14-01-2021 02:25:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Booking_Id] [int] IDENTITY(1,1) NOT NULL,
	[Hotel_Id] [int] NULL,
	[Room_Id] [int] NULL,
	[StatusOfBooking] [nvarchar](50) NULL,
	[BookingDate] [datetime] NULL,
	[IsActive] [nvarchar](50) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Booking_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 14-01-2021 02:25:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[Hotel_Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](50) NULL,
	[Pincode] [nvarchar](50) NULL,
	[ContactNumer] [bigint] NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[Facebook] [nvarchar](50) NULL,
	[Twitter] [nvarchar](50) NULL,
	[IsActive] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Hotel_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 14-01-2021 02:25:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Room_Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[IsActive] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[Hotel_Id] [int] NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Room_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Hotel] FOREIGN KEY([Hotel_Id])
REFERENCES [dbo].[Hotel] ([Hotel_Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Hotel]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Room] FOREIGN KEY([Room_Id])
REFERENCES [dbo].[Room] ([Room_Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Room]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([Hotel_Id])
REFERENCES [dbo].[Hotel] ([Hotel_Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
