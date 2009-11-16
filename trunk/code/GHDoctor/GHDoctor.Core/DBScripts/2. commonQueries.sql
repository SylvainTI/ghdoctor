/****** Object:  Table [dbo].[COMMONQUERIES]    Script Date: 11/15/2009 05:25:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMMONQUERIES](
	[CODE] [bigint] IDENTITY(1,1) NOT NULL,
	[CATEGORY_CODE] [int] NOT NULL,
	[SHORT_DESCRIPTION] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[DESCRIPTION] [varchar](500) COLLATE Modern_Spanish_CI_AS NULL,
	[SEARCH_STRING] [varchar](500) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_COMMONQUERIES] PRIMARY KEY CLUSTERED 
(
	[CODE] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[COMMONQUERIES]  WITH CHECK ADD  CONSTRAINT [FK_COMMONQUERIES_CATEGORY] FOREIGN KEY([CATEGORY_CODE])
REFERENCES [dbo].[CATEGORY] ([CODE])
GO
ALTER TABLE [dbo].[COMMONQUERIES] CHECK CONSTRAINT [FK_COMMONQUERIES_CATEGORY]