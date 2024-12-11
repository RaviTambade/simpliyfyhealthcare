/****** Object:  Table [dbo].[VsAccounts]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsAccounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Passcode] [varchar](20) NOT NULL,
	[UserId] [int] NOT NULL,
	[AccountNumber] [varchar](20) NOT NULL,
	[BankName] [varchar](255) NULL,
	[IFSCCode] [varchar](20) NULL,
	[Balance] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsCards]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [varchar](12) NOT NULL,
	[CVV] [varchar](50) NOT NULL,
	[CardType] [varchar](100) NOT NULL,
	[CreditLimit] [decimal](18, 2) NULL,
	[CardNumber] [varchar](12) NOT NULL,
	[ExpiryDate] [varchar](5) NOT NULL,
	[Pass] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsOrderItems]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsOrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsOrders]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalAmount] [decimal](10, 2) NULL,
	[Status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsPayments]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsPayments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentAmount] [decimal](10, 2) NOT NULL,
	[PaymentMode] [varchar](50) NOT NULL,
	[PaymentStatus] [varchar](50) NOT NULL,
	[TransactionId] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsPriceChanges]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsPriceChanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OldPrice] [decimal](10, 2) NOT NULL,
	[NewPrice] [decimal](10, 2) NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsProducts]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](max) NULL,
	[Brand] [varchar](50) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[LastModified] [datetime] NULL,
	[ImageUrl] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsReviews]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsReviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Rating] [int] NULL,
	[ReviewText] [varchar](max) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsShipments]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsShipments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShipmentDate] [datetime] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsTransactions]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ToAccountId] [varchar](20) NOT NULL,
	[FromAccountId] [varchar](20) NOT NULL,
	[Amount] [decimal](18, 2) NULL,
	[TransactionDate] [datetime] NULL,
	[TransactionId] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VsUsers]    Script Date: 12/11/2024 1:48:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VsUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[ContactNumber] [varchar](10) NOT NULL,
	[ImageUrl] [varchar](max) NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[VsAccounts] ON 

INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (53, N'ABC@123', 2, N'123456789101', N'HDFC', N'HDFGMAG', CAST(525003.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (54, N'ABC@123', 3, N'112233445566', N'ICICI', N'ICICIMAG', CAST(11000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (55, N'ABC@123', 4, N'223344556677', N'BankOfMaaharashra', N'BOMMAG', CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (56, N'ABC@123', 5, N'122334455667', N'ICICI', N'ICICIMAG', CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (57, N'BCD@123', 6, N'233445566778', N'HDFC ', N'HDFCMAG', CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (58, N'BCD@123', 7, N'344556677889', N'Kotak', N'KOTAKMAG', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (59, N'BCD@!23', 8, N'455667788990', N'BankOfMaharashtra', N'BOMMAG', CAST(21000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (60, N'CDE@123', 9, N'132435465768', N'HDFC ', N'HDFGMAG', CAST(29000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (61, N'CDE@123', 10, N'243546576879', N'BankOfMaharashra', N'BOMMAG', CAST(31000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (66, N'DEF@123', 12, N'354657687980', N'HDFC', N'HDFGMAG', CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (67, N'admin', 16, N'918888926475', N'KOTAK', N'KOTAKMAG', CAST(741008.00 AS Decimal(18, 2)))
INSERT [dbo].[VsAccounts] ([AccountId], [Passcode], [UserId], [AccountNumber], [BankName], [IFSCCode], [Balance]) VALUES (68, N'ABC@123', 10, N'2434354546455756', N'HDFC', N'HDFCMAG', CAST(200000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[VsAccounts] OFF
GO
SET IDENTITY_INSERT [dbo].[VsCards] ON 

INSERT [dbo].[VsCards] ([Id], [AccountNumber], [CVV], [CardType], [CreditLimit], [CardNumber], [ExpiryDate], [Pass]) VALUES (1, N'123456789101', N'123', N'Debit Card', CAST(-57000.00 AS Decimal(18, 2)), N'123456789101', N'10/28', N'ABC@123')
INSERT [dbo].[VsCards] ([Id], [AccountNumber], [CVV], [CardType], [CreditLimit], [CardNumber], [ExpiryDate], [Pass]) VALUES (3, N'123456789101', N'234', N'Credit Card', CAST(42999.00 AS Decimal(18, 2)), N'123456789102', N'10/28', N'ABC@123')
SET IDENTITY_INSERT [dbo].[VsCards] OFF
GO
SET IDENTITY_INSERT [dbo].[VsOrderItems] ON 

INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (58, 17, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (59, 17, 3, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (60, 18, 2, 3)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (61, 18, 4, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (62, 19, 1, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (63, 19, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (64, 19, 5, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (65, 20, 6, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (66, 20, 1, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (67, 21, 3, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (68, 21, 8, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (69, 21, 2, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (70, 22, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (71, 22, 10, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (72, 23, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (73, 23, 3, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (74, 23, 8, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (75, 24, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (76, 24, 5, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (77, 24, 10, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (78, 25, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (79, 25, 3, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (80, 25, 8, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (81, 26, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (82, 26, 5, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (130, 85, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (131, 85, 3, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (132, 86, 1, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (133, 86, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (134, 87, 1, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (135, 87, 2, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (136, 87, 3, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (137, 88, 1, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (144, 92, 2, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (145, 92, 1, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (151, 96, 1, 3)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (152, 96, 2, 2)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (153, 97, 1, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (154, 98, 41, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (155, 99, 1, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (156, 100, 1, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (157, 100, 2, 1)
INSERT [dbo].[VsOrderItems] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (158, 101, 9, 1)
SET IDENTITY_INSERT [dbo].[VsOrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[VsOrders] ON 

INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (17, 2, CAST(N'2024-11-30T18:30:00.000' AS DateTime), CAST(120000.00 AS Decimal(10, 2)), N'Completed')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (18, 2, CAST(N'2024-12-02T00:00:00.000' AS DateTime), CAST(34999.00 AS Decimal(10, 2)), N'Cancelled')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (19, 4, CAST(N'2024-12-02T18:30:00.000' AS DateTime), CAST(86000.00 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (20, 6, CAST(N'2024-12-03T18:30:00.000' AS DateTime), CAST(23999.00 AS Decimal(10, 2)), N'Completed')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (21, 8, CAST(N'2024-12-05T00:00:00.000' AS DateTime), CAST(74999.00 AS Decimal(10, 2)), N'Completed')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (22, 10, CAST(N'2024-12-06T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (23, 12, CAST(N'2024-12-07T00:00:00.000' AS DateTime), CAST(64999.00 AS Decimal(10, 2)), N'Completed')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (24, 2, CAST(N'2024-12-08T00:00:00.000' AS DateTime), CAST(23999.00 AS Decimal(10, 2)), N'Completed')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (25, 3, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(47999.00 AS Decimal(10, 2)), N'Cancelled')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (26, 3, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(129998.00 AS Decimal(10, 2)), N'Completed')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (82, 2, CAST(N'2024-12-11T06:14:18.750' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (85, 2, CAST(N'2024-12-11T06:33:24.857' AS DateTime), CAST(138980.50 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (86, 2, CAST(N'2024-12-11T06:38:21.500' AS DateTime), CAST(60880.50 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (87, 2, CAST(N'2024-12-11T06:53:10.983' AS DateTime), CAST(149880.50 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (88, 2, CAST(N'2024-12-11T07:18:31.723' AS DateTime), CAST(10900.00 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (92, 2, CAST(N'2024-12-11T09:45:23.073' AS DateTime), CAST(60880.50 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (96, 2, CAST(N'2024-12-11T11:42:44.963' AS DateTime), CAST(69980.50 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (97, 2, CAST(N'2024-12-11T12:35:29.000' AS DateTime), CAST(40000.00 AS Decimal(10, 2)), N'Completed')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (98, 2, CAST(N'2024-12-11T18:38:57.507' AS DateTime), CAST(500000.00 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (99, 2, CAST(N'2024-12-11T13:26:25.000' AS DateTime), CAST(40000.00 AS Decimal(10, 2)), N'Completed')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (100, 2, CAST(N'2024-12-11T19:15:50.110' AS DateTime), CAST(89980.50 AS Decimal(10, 2)), N'Pending')
INSERT [dbo].[VsOrders] ([Id], [CustomerId], [OrderDate], [TotalAmount], [Status]) VALUES (101, 2, CAST(N'2024-12-11T19:17:21.957' AS DateTime), CAST(23999.00 AS Decimal(10, 2)), N'Pending')
SET IDENTITY_INSERT [dbo].[VsOrders] OFF
GO
SET IDENTITY_INSERT [dbo].[VsPayments] ON 

INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (1, 23, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Credit', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (2, 23, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (3, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (4, 23, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (5, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (6, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (7, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (8, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (9, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (10, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (11, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (12, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (13, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (14, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (15, 22, CAST(N'2024-12-09T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'creditDebitCard', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (16, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (17, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (18, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (19, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (20, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (21, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (22, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (23, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (24, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Error: Message', N'')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (25, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (26, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (27, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (28, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Failed', N'202412100817')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (29, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (30, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412100831')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (31, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (32, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Failed', N'202412100841')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (33, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (34, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412100847')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (35, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Credit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (36, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Credit Card', N'Complete', N'202412100857')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (37, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Credit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (38, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Credit Card', N'Failed', N'202412101000')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (39, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (40, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412101010')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (41, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (42, 22, CAST(N'2024-12-10T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412101058')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (43, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (44, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412110954')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (45, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Credit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (46, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Credit Card', N'Failed', N'202412111056')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (47, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Credit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (48, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Credit Card', N'Failed', N'202412111109')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (49, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Credit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (50, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Credit Card', N'Failed', N'202412111124')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (51, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (52, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412111127')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (53, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Credit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (54, 22, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(56999.00 AS Decimal(10, 2)), N'Credit Card', N'Failed', N'202412111140')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (55, 17, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (56, 17, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(120000.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412111220')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (57, 17, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (58, 17, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(120000.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412111230')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (59, 97, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (60, 97, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(40000.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412111236')
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (61, 99, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(10, 2)), N'Debit Card', N'Pending', NULL)
INSERT [dbo].[VsPayments] ([Id], [OrderId], [PaymentDate], [PaymentAmount], [PaymentMode], [PaymentStatus], [TransactionId]) VALUES (62, 99, CAST(N'2024-12-11T00:00:00.000' AS DateTime), CAST(40000.00 AS Decimal(10, 2)), N'Debit Card', N'Complete', N'202412111328')
SET IDENTITY_INSERT [dbo].[VsPayments] OFF
GO
SET IDENTITY_INSERT [dbo].[VsPriceChanges] ON 

INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (2, 1, CAST(699.99 AS Decimal(10, 2)), CAST(649.99 AS Decimal(10, 2)), CAST(N'2024-08-01T10:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (3, 2, CAST(1199.99 AS Decimal(10, 2)), CAST(1149.99 AS Decimal(10, 2)), CAST(N'2024-08-01T11:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (4, 3, CAST(19.99 AS Decimal(10, 2)), CAST(17.99 AS Decimal(10, 2)), CAST(N'2024-08-02T09:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (5, 4, CAST(39.99 AS Decimal(10, 2)), CAST(34.99 AS Decimal(10, 2)), CAST(N'2024-08-02T10:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (6, 5, CAST(199.99 AS Decimal(10, 2)), CAST(179.99 AS Decimal(10, 2)), CAST(N'2024-08-03T14:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (7, 6, CAST(329.99 AS Decimal(10, 2)), CAST(299.99 AS Decimal(10, 2)), CAST(N'2024-08-03T15:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (8, 7, CAST(89.99 AS Decimal(10, 2)), CAST(79.99 AS Decimal(10, 2)), CAST(N'2024-08-04T12:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (9, 8, CAST(29.99 AS Decimal(10, 2)), CAST(24.99 AS Decimal(10, 2)), CAST(N'2024-08-04T13:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (10, 9, CAST(149.99 AS Decimal(10, 2)), CAST(139.99 AS Decimal(10, 2)), CAST(N'2024-08-05T16:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (11, 10, CAST(49.99 AS Decimal(10, 2)), CAST(44.99 AS Decimal(10, 2)), CAST(N'2024-08-05T17:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (12, 11, CAST(25.99 AS Decimal(10, 2)), CAST(22.99 AS Decimal(10, 2)), CAST(N'2024-08-06T10:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (13, 12, CAST(34.99 AS Decimal(10, 2)), CAST(29.99 AS Decimal(10, 2)), CAST(N'2024-08-06T11:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (14, 13, CAST(299.99 AS Decimal(10, 2)), CAST(279.99 AS Decimal(10, 2)), CAST(N'2024-08-07T12:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (15, 14, CAST(599.99 AS Decimal(10, 2)), CAST(569.99 AS Decimal(10, 2)), CAST(N'2024-08-07T13:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (16, 15, CAST(15.99 AS Decimal(10, 2)), CAST(14.99 AS Decimal(10, 2)), CAST(N'2024-08-08T14:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (17, 16, CAST(49.99 AS Decimal(10, 2)), CAST(44.99 AS Decimal(10, 2)), CAST(N'2024-08-08T15:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (18, 17, CAST(29.99 AS Decimal(10, 2)), CAST(24.99 AS Decimal(10, 2)), CAST(N'2024-08-09T16:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (19, 18, CAST(21.99 AS Decimal(10, 2)), CAST(19.99 AS Decimal(10, 2)), CAST(N'2024-08-09T17:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (20, 19, CAST(59.99 AS Decimal(10, 2)), CAST(54.99 AS Decimal(10, 2)), CAST(N'2024-08-10T18:00:00.000' AS DateTime))
INSERT [dbo].[VsPriceChanges] ([Id], [ProductId], [OldPrice], [NewPrice], [ChangeDate]) VALUES (21, 20, CAST(69.99 AS Decimal(10, 2)), CAST(64.99 AS Decimal(10, 2)), CAST(N'2024-08-10T19:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[VsPriceChanges] OFF
GO
SET IDENTITY_INSERT [dbo].[VsProducts] ON 

INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (1, N'Samsung Galaxy ', N'Latest model with high-resolution camera', N'Samsung', CAST(40000.00 AS Decimal(10, 2)), 1000, N'Smartphone', CAST(N'2024-12-07T06:37:57.857' AS DateTime), N'/images/products/smartphones/galaxy_M05.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (2, N'Samsung Galaxy S22', N'5G 8GB RAM 128GB', N'Samsung', CAST(49980.50 AS Decimal(10, 2)), 1000, N'SmartPhone', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/smartphones/galaxy_S22.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (3, N'Samsung Galaxy S23 Ultra', N'5G AI-Smartphone 12GB RAM 256GB ', N'Samsung', CAST(89000.00 AS Decimal(10, 2)), 500, N'SmartPhone', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/smartphones/galaxy_S23.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (4, N'iPhone 16', N'5G 128GB ', N'Apple', CAST(86000.00 AS Decimal(10, 2)), 1500, N'SmartPhone', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/smartphones/iphone_16.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (5, N'iPhone 14', N'5G 128GB ', N'Apple', CAST(55000.00 AS Decimal(10, 2)), 1300, N'SmartPhone', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/smartphones/iphone_14.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (6, N'iPhone 13', N'5G 256GB ', N'Apple', CAST(54999.00 AS Decimal(10, 2)), 1500, N'SmartPhone', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/smartphones/iphone_13.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (7, N'OnePlus 11', N'5G 12GB RAM 256GB', N'OnePlus', CAST(54999.00 AS Decimal(10, 2)), 800, N'SmartPhone', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/smartphones/oneplus_11.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (8, N'OnePlus 12', N'5G 16GB RAM 512GB', N'OnePlus', CAST(66999.00 AS Decimal(10, 2)), 600, N'SmartPhone', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/smartphones/oneplus_12.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (9, N'OnePlus Nord CE 4', N'5G 8GB RAM 128GB', N'OnePlus', CAST(23999.00 AS Decimal(10, 2)), 1000, N'SmartPhone', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/smartphones/oneplus_nord_ce4.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (10, N'Lenovo ThinkPad E14', N'Intel Core i5 8GB RAM 512GB SSD', N'Lenovo', CAST(47999.00 AS Decimal(10, 2)), 400, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/lenovo_e14.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (11, N'Lenovo ThinkPad E15', N'Intel Core i7 16GB RAM 512GB SSD', N'Lenovo', CAST(58999.00 AS Decimal(10, 2)), 350, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/lenovo_e15.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (12, N'Lenovo ThinkPad L14', N'Intel Core i3 8GB RAM 256GB SSD', N'Lenovo', CAST(36999.00 AS Decimal(10, 2)), 500, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/lenovo_l14.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (13, N'Dell Inspiron 5410', N'Intel Core i5 8GB RAM 512GB SSD', N'Dell', CAST(52999.00 AS Decimal(10, 2)), 450, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/dell_inspiron_5410.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (14, N'Dell Inspiron 5310', N'Intel Core i7 16GB RAM 512GB SSD', N'Dell', CAST(64999.00 AS Decimal(10, 2)), 300, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/dell_inspiron_5310.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (15, N'Dell Inspiron 3412', N'Intel Core i3 8GB RAM 256GB SSD', N'Dell', CAST(35999.00 AS Decimal(10, 2)), 600, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/dell_inspiron_3412.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (16, N'HP Pavilion x360', N'Intel Core i5 8GB RAM 512GB SSD', N'HP', CAST(56999.00 AS Decimal(10, 2)), 500, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/hp_pavilion_x360.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (17, N'HP Envy 13', N'Intel Core i7 16GB RAM 512GB SSD', N'HP', CAST(74999.00 AS Decimal(10, 2)), 400, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/hp_envy_13.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (18, N'HP Elite Dragonfly', N'Intel Core i5 8GB RAM 256GB SSD', N'HP', CAST(97999.00 AS Decimal(10, 2)), 350, N'Laptop', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/laptops/hp_elite_dragonfly.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (19, N'Samsung 55" 4K QLED TV', N'Samsung QLED 4K Smart TV with AI upscaling', N'Samsung', CAST(64999.00 AS Decimal(10, 2)), 200, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/samsung_qled_55.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (20, N'Samsung 65" 4K UHD TV', N'Samsung Crystal UHD 4K Smart TV', N'Samsung', CAST(74999.00 AS Decimal(10, 2)), 150, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/samsung_crystal_65.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (21, N'Samsung 75" 4K QLED TV', N'Samsung 4K QLED Smart TV with Ambient Mode', N'Samsung', CAST(89999.00 AS Decimal(10, 2)), 120, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/samsung_qled_75.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (22, N'LG 55" OLED TV', N'LG OLED Smart TV with 4K resolution', N'LG', CAST(89999.00 AS Decimal(10, 2)), 120, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/lg_oled_55.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (23, N'LG 65" 4K UHD Smart TV', N'LG 4K UHD Smart TV with ThinQ AI', N'LG', CAST(74999.00 AS Decimal(10, 2)), 180, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/lg_65_4k.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (24, N'LG 75" NanoCell TV', N'LG 75" 4K UHD NanoCell Smart TV', N'LG', CAST(84999.00 AS Decimal(10, 2)), 150, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/lg_nano_75.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (25, N'Vu 50" 4K LED TV', N'Vu Premium 4K LED Smart TV', N'Vu', CAST(39999.00 AS Decimal(10, 2)), 300, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/vu_50_4k.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (26, N'Vu 55" 4K LED TV', N'Vu 4K LED Smart TV with Android OS', N'Vu', CAST(44999.00 AS Decimal(10, 2)), 250, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/vu_55_4k.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (27, N'Vu 65" 4K LED TV', N'Vu 65" 4K LED Smart TV with HDR', N'Vu', CAST(59999.00 AS Decimal(10, 2)), 200, N'TV', CAST(N'2024-12-05T06:34:17.827' AS DateTime), N'/images/products/tvs/vu_65_4k.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (41, N' LCD TV', N' LED Smart TV with HDR', N'Vu', CAST(500000.00 AS Decimal(10, 2)), 20, N'TV', CAST(N'2024-12-07T06:35:25.087' AS DateTime), N'/images/products/tvs/vu_65_4k.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (42, N' LCD TV', N' LED Smart TV with HDR', N'Vu', CAST(500000.00 AS Decimal(10, 2)), 20, N'TV', CAST(N'2024-12-07T06:35:25.087' AS DateTime), N'/images/products/tvs/vu_65_4k.jpg')
INSERT [dbo].[VsProducts] ([Id], [Title], [Description], [Brand], [Price], [Stock], [Category], [LastModified], [ImageUrl]) VALUES (43, N'Samsung Galaxy ', N'5G 8GB RAM 128GB', N'Samsung', CAST(49980.50 AS Decimal(10, 2)), 1000, N'SmartPhone', CAST(N'2024-12-08T09:43:14.497' AS DateTime), N'/images/products/smartphones/galaxy_S22.jpg')
SET IDENTITY_INSERT [dbo].[VsProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[VsReviews] ON 

INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (2, 1, 2, 5, N'Fantastic smartphone with amazing features!', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (3, 1, 2, 3, N'Good', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (4, 2, 2, 4, N'Very powerful laptop, but a bit heavy.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (5, 3, 3, 5, N'Great book, could not put it down!', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (6, 4, 4, 3, N'Jeans are good, but the fit was not perfect.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (7, 5, 5, 5, N'Smartwatch with excellent features .', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (8, 6, 6, 4, N'Tablet is good but battery life could be better.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (9, 7, 7, 5, N'E-book reader is very convenient.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (10, 8, 8, 4, N'Shirt material is good but color faded after wash.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (11, 9, 9, 5, N'Headphones have great sound quality.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (12, 10, 10, 4, N'Bluetooth speaker is portable and has good bass.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (13, 11, 12, 5, N'Historical novel was very engaging.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (14, 12, 12, 3, N'Trousers are comfortable but the size was a bit off.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (15, 13, 13, 5, N'Camera quality is superb.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (16, 14, 14, 4, N'Smart TV has excellent picture quality.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (17, 15, 16, 5, N'Cookbook has some amazing recipes.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (18, 16, 16, 3, N'Dress is nice but fitting could be better.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (19, 17, 12, 5, N'Wireless charger is very convenient.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (20, 18, 19, 5, N'Mystery novel kept me hooked till the end.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (21, 19, 19, 4, N'Sneakers are comfortable for running.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
INSERT [dbo].[VsReviews] ([Id], [ProductId], [UserId], [Rating], [ReviewText], [created_at]) VALUES (22, 20, 19, 5, N'Bluetooth earbuds have excellent sound quality.', CAST(N'2024-12-10T10:39:27.927' AS DateTime))
SET IDENTITY_INSERT [dbo].[VsReviews] OFF
GO
SET IDENTITY_INSERT [dbo].[VsShipments] ON 

INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (1, CAST(N'2024-12-08T00:00:00.000' AS DateTime), 17, N'Cancelled')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (2, CAST(N'2024-12-09T00:00:00.000' AS DateTime), 18, N'Delivered')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (3, CAST(N'2024-12-10T00:00:00.000' AS DateTime), 19, N'Cancelled')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (4, CAST(N'2024-12-11T00:00:00.000' AS DateTime), 20, N'Delivered')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (5, CAST(N'2024-12-12T00:00:00.000' AS DateTime), 21, N'Dispatched')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (6, CAST(N'2024-12-13T00:00:00.000' AS DateTime), 22, N'Delivered')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (7, CAST(N'2024-12-14T00:00:00.000' AS DateTime), 23, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (8, CAST(N'2024-12-15T00:00:00.000' AS DateTime), 24, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (9, CAST(N'2024-12-16T00:00:00.000' AS DateTime), 25, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (10, CAST(N'2024-12-17T00:00:00.000' AS DateTime), 26, N'Dispatched')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (18, CAST(N'2024-12-18T11:09:51.860' AS DateTime), 22, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (19, CAST(N'2024-12-18T11:24:10.080' AS DateTime), 22, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (20, CAST(N'2024-12-18T11:27:43.040' AS DateTime), 22, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (21, CAST(N'2024-12-18T11:40:35.317' AS DateTime), 22, N'Delivered')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (22, CAST(N'2024-12-18T12:20:14.520' AS DateTime), 17, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (23, CAST(N'2024-12-18T12:30:39.563' AS DateTime), 17, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (24, CAST(N'2024-12-18T12:36:42.277' AS DateTime), 97, N'Pending')
INSERT [dbo].[VsShipments] ([Id], [ShipmentDate], [OrderId], [Status]) VALUES (25, CAST(N'2024-12-18T13:28:00.303' AS DateTime), 99, N'Pending')
SET IDENTITY_INSERT [dbo].[VsShipments] OFF
GO
SET IDENTITY_INSERT [dbo].[VsTransactions] ON 

INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (8, N'918888926475', N'123456789101', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2024-12-10T06:09:04.067' AS DateTime), N'202412100609')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (9, N'918888926475', N'123456789101', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2024-12-10T06:41:29.377' AS DateTime), NULL)
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (15, N'918888926475', N'123456789101', CAST(12000.00 AS Decimal(18, 2)), CAST(N'2024-12-10T07:14:59.077' AS DateTime), N'202412100714')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (16, N'918888926475', N'123456789101', CAST(56000.00 AS Decimal(18, 2)), CAST(N'2024-12-10T08:25:25.980' AS DateTime), N'202412100825')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (17, N'123456789101', N'918888926475', CAST(56999.00 AS Decimal(18, 2)), CAST(N'2024-12-10T08:31:44.177' AS DateTime), N'202412100831')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (18, N'918888926475', N'123456789101', CAST(59001.00 AS Decimal(18, 2)), CAST(N'2024-12-10T08:43:10.617' AS DateTime), N'202412100843')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (19, N'918888926475', N'123456789101', CAST(56999.00 AS Decimal(18, 2)), CAST(N'2024-12-10T08:47:07.203' AS DateTime), N'202412100847')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (20, N'918888926475', N'123456789101', CAST(56999.00 AS Decimal(18, 2)), CAST(N'2024-12-10T08:57:05.190' AS DateTime), N'202412100857')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (21, N'918888926475', N'123456789101', CAST(1.00 AS Decimal(18, 2)), CAST(N'2024-12-10T09:01:56.453' AS DateTime), N'202412100901')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (22, N'918888926475', N'123456789101', CAST(1.00 AS Decimal(18, 2)), CAST(N'2024-12-10T09:09:50.550' AS DateTime), N'202412100909')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (23, N'918888926475', N'123456789101', CAST(56999.00 AS Decimal(18, 2)), CAST(N'2024-12-10T10:10:49.113' AS DateTime), N'202412101010')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (24, N'918888926475', N'123456789101', CAST(56999.00 AS Decimal(18, 2)), CAST(N'2024-12-10T10:58:37.810' AS DateTime), N'202412101058')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (25, N'918888926475', N'123456789101', CAST(56999.00 AS Decimal(18, 2)), CAST(N'2024-12-11T09:54:09.163' AS DateTime), N'202412110954')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (26, N'918888926475', N'123456789101', CAST(56999.00 AS Decimal(18, 2)), CAST(N'2024-12-11T11:27:43.023' AS DateTime), N'202412111127')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (27, N'918888926475', N'123456789101', CAST(120000.00 AS Decimal(18, 2)), CAST(N'2024-12-11T12:20:14.490' AS DateTime), N'202412111220')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (28, N'918888926475', N'123456789101', CAST(120000.00 AS Decimal(18, 2)), CAST(N'2024-12-11T12:30:39.547' AS DateTime), N'202412111230')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (29, N'918888926475', N'123456789101', CAST(40000.00 AS Decimal(18, 2)), CAST(N'2024-12-11T12:36:42.250' AS DateTime), N'202412111236')
INSERT [dbo].[VsTransactions] ([Id], [ToAccountId], [FromAccountId], [Amount], [TransactionDate], [TransactionId]) VALUES (30, N'918888926475', N'123456789101', CAST(40000.00 AS Decimal(18, 2)), CAST(N'2024-12-11T13:28:00.280' AS DateTime), N'202412111328')
SET IDENTITY_INSERT [dbo].[VsTransactions] OFF
GO
SET IDENTITY_INSERT [dbo].[VsUsers] ON 

INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (2, N'Tejas', N'Waydande', N'$2a$10$Bkpk67XxnUwMK0VfqkDN1ONjgLJ/9KCI8QtQfb0x4ca2GS/hqmZ/y', N'amit.sharma@example.com', N'Street 1, City Delhi', N'sales', N'9876543210', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (3, N'Rahul', N'Waydande', N'$2a$10$vlqlzQTHFcWUtbJEFvoq7OfgSraSU6hh2qmoJKOmXGWt7FEad8SBW', N'rahul.gupta@example.com', N'Street 3, City Satara', N'vendor', N'9876543212', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (4, N'Neha', N'Verma', N'Password123!', N'neha.verma@example.com', N'Street 4, City Chennai', N'director', N'9876543213', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (5, N'Ravi', N'Singh', N'Password123!', N'ravi.singh@example.com', N'Street 5, City Delhi', N'sales', N'9876543214', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (6, N'Sita', N'Nair', N'Password123!', N'sita.nair@example.com', N'Street 6, City Mumbai', N'customer', N'9876543215', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (7, N'Vikas', N'Kumar', N'Password123!', N'vikas.kumar@example.com', N'Street 7, City Bengaluru', N'vendor', N'9876543216', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (8, N'Rita', N'Joshi', N'Password123!', N'rita.joshi@example.com', N'Street 8, City Chennai', N'director', N'9876543217', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (9, N'Ajay', N'Reddy', N'Password123!', N'ajay.reddy@example.com', N'Street 9, City Delhi', N'sales', N'9876543218', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (10, N'Anjali', N'Chaudhary', N'Password123!', N'anjali.chaudhary@example.com', N'Street 10, City Mumbai', N'customer', N'9876543219', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (12, N'Sunita', N'Gupta', N'Password123!', N'sunita.gupta@example.com', N'Street 12, City Chennai', N'director', N'9876543221', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (13, N'Manish', N'Yadav', N'Password123!', N'manish.yadav@example.com', N'Street 13, City Delhi', N'sales', N'9876543222', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (14, N'Shalini', N'Bose', N'Password123!', N'shalini.bose@example.com', N'Street 14, City Mumbai', N'customer', N'9876543223', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (16, N'Vijay', N'Sales', N'Password123!', N'admin@vijaysales.com', N'Vijay sales HQ, Magarpatta', N'admin', N'9970154890', N'/images/baseImage.png', CAST(N'2024-12-05T07:31:37.633' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (19, N'Swapnil', N'Patil', N'$2a$10$8EJRA47U29d523cMiTrv1Oquq.5QuqNhQ2myXA9KxK7jQmHow6ECm', N'swap@g.com', N'street 3, hadapsar', N'customer', N'8907651234', N'/image/cprofile.png', CAST(N'2024-12-05T18:14:03.093' AS DateTime))
INSERT [dbo].[VsUsers] ([Id], [FirstName], [LastName], [Password], [Email], [Address], [Role], [ContactNumber], [ImageUrl], [CreatedAt]) VALUES (26, N'Mohan', N'abcd', N'$2a$10$4sGApWKp3p/62RjlBLB3buf1wv4hX0JB/SCPSiBbcfSx.DCF8nHHC', N'liko@g.com', N'Street 4, City Nagpur', N'director', N'1234567890', N'/images/baseImage.png', CAST(N'2024-12-05T06:32:47.500' AS DateTime))
SET IDENTITY_INSERT [dbo].[VsUsers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_VsAccounts_AccountNumber]    Script Date: 12/11/2024 1:48:36 PM ******/
ALTER TABLE [dbo].[VsAccounts] ADD  CONSTRAINT [UQ_VsAccounts_AccountNumber] UNIQUE NONCLUSTERED 
(
	[AccountNumber] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VsCards__C1FE2241A59D0A27]    Script Date: 12/11/2024 1:48:36 PM ******/
ALTER TABLE [dbo].[VsCards] ADD UNIQUE NONCLUSTERED 
(
	[CVV] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VsTransa__55433A6A20057CDC]    Script Date: 12/11/2024 1:48:36 PM ******/
ALTER TABLE [dbo].[VsTransactions] ADD UNIQUE NONCLUSTERED 
(
	[TransactionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VsUsers__570665C691563903]    Script Date: 12/11/2024 1:48:36 PM ******/
ALTER TABLE [dbo].[VsUsers] ADD UNIQUE NONCLUSTERED 
(
	[ContactNumber] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VsUsers__A9D105348B6024E5]    Script Date: 12/11/2024 1:48:36 PM ******/
ALTER TABLE [dbo].[VsUsers] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VsPayments] ADD  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[VsPayments] ADD  DEFAULT ('Pending') FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[VsProducts] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
ALTER TABLE [dbo].[VsReviews] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[VsUsers] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[VsAccounts]  WITH CHECK ADD  CONSTRAINT [FK_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[VsUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsAccounts] CHECK CONSTRAINT [FK_UserId]
GO
ALTER TABLE [dbo].[VsOrderItems]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[VsOrders] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsOrderItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[VsProducts] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsOrders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[VsUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsPayments]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[VsOrders] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsPriceChanges]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[VsProducts] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsReviews]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[VsProducts] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsReviews]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[VsUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsShipments]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[VsOrders] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsTransactions]  WITH CHECK ADD  CONSTRAINT [FK_VsTransactions_FromAccountId] FOREIGN KEY([FromAccountId])
REFERENCES [dbo].[VsAccounts] ([AccountNumber])
GO
ALTER TABLE [dbo].[VsTransactions] CHECK CONSTRAINT [FK_VsTransactions_FromAccountId]
GO
ALTER TABLE [dbo].[VsTransactions]  WITH CHECK ADD  CONSTRAINT [FK_VsTransactions_ToAccountId] FOREIGN KEY([ToAccountId])
REFERENCES [dbo].[VsAccounts] ([AccountNumber])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VsTransactions] CHECK CONSTRAINT [FK_VsTransactions_ToAccountId]
GO
ALTER TABLE [dbo].[VsCards]  WITH CHECK ADD CHECK  (([CardType]='Debit Card' OR [CardType]='Credit Card'))
GO
ALTER TABLE [dbo].[VsReviews]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
