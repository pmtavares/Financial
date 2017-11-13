/****** Object:  Table [dbo].[category]    Script Date: 28/04/2017  ******/

CREATE TABLE [dbo].[category](
	[idcategory] [nvarchar](5) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__category__8A3D240C1538A73E] PRIMARY KEY CLUSTERED 
(
	[idcategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clients]    Script Date: 28/04/2017  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[client](
	[idclient] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[address] [varchar](50) NOT NULL,
	[phone] [varchar](30) NOT NULL,
	[pps] [numeric](11, 0) NOT NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[idclient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[pps] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detailsale]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detailsale](
	[iddetail] [int] IDENTITY(1,1) NOT NULL,
	[numreceipt] [numeric](18, 0) NOT NULL,
	[idsale] [numeric](18, 0) NOT NULL,
	[subTotal] [real] NOT NULL,
	[idproduct] [nvarchar](5) NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_detailsale] PRIMARY KEY CLUSTERED 
(
	[iddetail] ASC,
	[numreceipt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[receipt]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[receipt](
	[numreceipt] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[data] [date] NOT NULL,
	[fee] [real] NOT NULL,
	[total] [real] NOT NULL,
	[numPag] [int] NOT NULL,
	[discount] [money] NULL,
 CONSTRAINT [PK__receipt__C989668BFDF3359B] PRIMARY KEY CLUSTERED 
(
	[numreceipt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[modoPag]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modoPag](
	[numPag] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](25) NOT NULL,
	[othersdetails] [nvarchar](50) NULL,
 CONSTRAINT [PK__modoPag__56E7C501338E87C8] PRIMARY KEY CLUSTERED 
(
	[numPag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[product]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[idproduct] [nvarchar](5) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[priceunit] [money] NOT NULL,
	[idcategory] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK__product__07F4A132F0C57D04] PRIMARY KEY CLUSTERED 
(
	[idproduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[saler]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[saler](
	[idsaler] [nvarchar](5) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[pps] [nvarchar](11) NOT NULL,
	[phone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__saler__A6693F936F5918BB] PRIMARY KEY CLUSTERED 
(
	[idsaler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sale]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale](
	[idsale] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[total] [real] NOT NULL,
	[idclient] [numeric](18, 0) NOT NULL,
	[idsaler] [nvarchar](5) NOT NULL,
	[data] [date] NOT NULL,
	[discount] [money] NULL,
	[fee] [money] NOT NULL,
 CONSTRAINT [PK__pedido__A9F619B72DC663B9] PRIMARY KEY CLUSTERED 
(
	[idsale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Relacionamentos   ******/

ALTER TABLE [dbo].[detailsale]  WITH CHECK ADD  CONSTRAINT [FK__detailFa__idPed__239E4DCF] FOREIGN KEY([idsale])
REFERENCES [dbo].[sale] ([idsale])
GO
ALTER TABLE [dbo].[detailsale] CHECK CONSTRAINT [FK__detailFa__idPed__239E4DCF]
GO
ALTER TABLE [dbo].[detailsale]  WITH CHECK ADD  CONSTRAINT [FK_detailreceipt_receipt] FOREIGN KEY([numreceipt])
REFERENCES [dbo].[receipt] ([numreceipt])
GO
ALTER TABLE [dbo].[detailsale] CHECK CONSTRAINT [FK_detailreceipt_receipt]
GO
ALTER TABLE [dbo].[detailsale]  WITH CHECK ADD  CONSTRAINT [FK_detailreceipt_product] FOREIGN KEY([idproduct])
REFERENCES [dbo].[product] ([idproduct])
GO
ALTER TABLE [dbo].[detailsale] CHECK CONSTRAINT [FK_detailreceipt_product]
GO
ALTER TABLE [dbo].[receipt]  WITH CHECK ADD  CONSTRAINT [FK_receipt_modoPag] FOREIGN KEY([numPag])
REFERENCES [dbo].[modoPag] ([numPag])
GO
ALTER TABLE [dbo].[receipt] CHECK CONSTRAINT [FK_receipt_modoPag]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK__product__idCate__164452B1] FOREIGN KEY([idcategory])
REFERENCES [dbo].[category] ([idcategory])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK__product__idCate__164452B1]
GO
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [FK_sale_client] FOREIGN KEY([idclient])
REFERENCES [dbo].[client] ([idclient])
GO
ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [FK_sale_client]
GO
ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [FK_sale_saler] FOREIGN KEY([idsaler])
REFERENCES [dbo].[saler] ([idsaler])
GO
ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [FK_sale_saler]
GO
USE [master]
GO
--ALTER DATABASE [financeiro] SET  READ_WRITE 
--GO
