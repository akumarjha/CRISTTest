USE [CRISKAshutoshTest]
GO

/****** Object:  Table [dbo].[ExposureForecast]    Script Date: 23-05-2023 01:53:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExposureForecast](
	[ID] [int] NOT NULL,
	[Counterparty] [varchar](255) NOT NULL,
	[Businessdate] [datetime] NOT NULL,
	[Exposure] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


